using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using UGameRR;
using UGameDE;
using UClass;
using UHelpers;
using UFight;
using USettings;
using UDisplay;
using UPrint;

namespace UGroup
{
    // TODO: nextstepbutton -> ergebniserkennung neu strukturieren
    public partial class TGroupForm: Form
    {
        public TGroupForm()
        {
            InitializeComponent();
        }

        public void Updater(bool includeDisplay)
        {
            TGameStats stats;
            if (Units.Group.isDE)
            {
                stats = Units.Group.GameDE.GetStats();
                PrintImage.Image = Units.Group.GameDE.ToBitmap();
            }
            else
            {
                stats = Units.Group.GameRR.GetStats();
                if (Units.Group.GameRRStore != null)
                {
                    PrintImage.Image = Units.Group.GameRR.ToBitmap(Units.Group.GameRRStore);
                }
                else
                {
                    PrintImage.Image = Units.Group.GameRR.ToBitmap();
                }
            }
            if (stats.FightsTotal != 0)
            {
                ProgressBar.Value = (int)Math.Round((stats.FightsDone * 100.0) / stats.FightsTotal);
                StatsLabel.Text = (stats.FightsDone).ToString() + '/' + (stats.FightsTotal).ToString();
                if ((stats.TimeTotalAssumed != 0) && (stats.TimeDone != stats.TimeTotalAssumed))
                {
                    StatsLabel.Text = StatsLabel.Text + ", ca. " + UHelpers.UHelpers.TimeToStr(stats.TimeTotalAssumed - stats.TimeDone, UClass.TIMEFORMAT.TIMEFMT_HM) + " verbleibend";
                }
            // ShowMessage(inttostr(stats.FightsDone) + '/' + inttostr(stats.FightsTotal) + chr(13) +
            // inttostr(stats.TimeDone) + '/' + inttostr(stats.TimeTotalAssumed) + chr(13) +
            // inttostr(stats.FightTimeDone) + '/' + inttostr(stats.FightTimeTotalAssumed) + chr(13));
            }
            else
            {
                ProgressBar.Value = 0;
                StatsLabel.Text = "-/-";
            }
            if (includeDisplay)
            {
                Units.Display.DisplayForm.ProgressBar.Value = ProgressBar.Value;
                Units.Display.DisplayForm.StatsLabel.Text = StatsLabel.Text;
            }
            BackupRunning();
        }

        public void Updater()
        {
            Updater(true);
        }

        public void AutoResize()
        {
            this.Height = ScrollBox.Top + PrintImage.Height + 4 + 13 + 10 + 35 + 8;
            this.Width = ScrollBox.Left + PrintImage.Width + 4 + 5 + 16;
            if ((this.Height > Screen.PrimaryScreen.Bounds.Height - 100) || (this.Width > Screen.PrimaryScreen.Bounds.Width - 100))
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            else
            {
                this.Top = (int)Math.Round(Convert.ToDouble((Screen.PrimaryScreen.Bounds.Height - this.Height) / 2));
                this.Left = (int)Math.Round(Convert.ToDouble((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2));
            }
        }

        public void SwitchToGameView()
        {
            PlayersBox.Visible = false;
            PrenameEdit.Visible = false;
            LastnameEdit.Visible = false;
            ClubEdit.Visible = false;
            AddPlayerButton.Visible = false;
            DelPlayerButton.Visible = false;
            PrintGameButton.Visible = true;
            NextStepButton.Text = "Nächster Kampf";
        }

        public void BackupRunning()
        {
            List<string> list;
            list = new List<string>();
            if (Units.Group.isDE)
            {
                System.IO.File.WriteAllText(Units.Class.BACKUPFILE + Units.Class.FILEEXT, Units.Group.GameDE.ToString());
            }
            else
            {
                list.Add(Units.Group.GameRR.ToString());
                if (Units.Group.GameRRStore != null)
                {
                    list.Add(Units.Group.GameRRStore.ToString());
                }
                System.IO.File.WriteAllLines(Units.Class.BACKUPFILE + Units.Class.FILEEXT, list.ToArray());
            }
        }

        public bool RestoreBackup()
        {
            bool result;
            List<string> list;
            if (File.Exists(Units.Class.BACKUPFILE + Units.Class.FILEEXT))
            {
                LoadGame(Units.Class.BACKUPFILE + Units.Class.FILEEXT);
                if (Units.Group.GameDE != null)
                {
                    Units.Group.isDE = true;
                }
                else if (Units.Group.GameRR != null)
                {
                    Units.Group.isDE = false;
                }
                SwitchToGameView();
                Updater();
                AutoResize();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public void LoadGame(string FileName)
        {
            if (File.Exists(FileName))
            {
                string[] list = System.IO.File.ReadAllLines(FileName);
                if (list.Length > 0)
                {
                    if (list[0].StartsWith("DE"))
                    {
                        Units.Group.GameDE = new TGameDE(list[0], Units.Group.Settings);
                    }
                    else
                    {
                        Units.Group.GameRR = new TGameRR(list[0], Units.Group.Settings);
                        Units.Group.GameRRStore = null;
                        if (list.Length > 1)
                        {
                            Units.Group.GameRRStore = new TGameRR(list[1], Units.Group.Settings);
                        }
                    }
                }
            }
        }

        public void Button1Click(System.Object Sender, System.EventArgs _e1)
        {
            int i;
            Units.Group.Players = new List<TPlayer>();
            PlayerBox.Items.Clear();
            for (i = 0; i < Convert.ToInt32(Edit1.Text); i++)
            {
                Units.Group.Players.Add(new TPlayer());
                Units.Group.Players[i].Prename = "Name";
                Units.Group.Players[i].Lastname = "Test" + (i).ToString();
                Units.Group.Players[i].Club = "Club";
                Units.Group.Players[i].ID = i;
                PlayerBox.Items.Add(UHelpers.UHelpers.PlayerToStr(Units.Group.Players[i]));
            // PlayerLabel.Caption := PlayerLabel.Caption  + Players[i].Prename + ' ' + Players[i].Lastname + chr(13);
            }
        }

        public void NextStepButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            TMatch NextMatch;
            TMatch tmpmatch;
            List<TGameRR.TGameRRResultLine> tmp;
            int i;
            int bad;
            string s;
            List<TPlayer> playersforfinal = new List<TPlayer>();
            s = "";
            if ((Units.Group.GameDE == null) && (Units.Group.GameRR == null))
            {
                // no game yet
                if (Units.Group.Players.Count == 0)
                {
                    MessageBox.Show(("Keine Kämpfer eingetragen!" as string), ("Fehler" as string), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
                else
                {
                    SwitchToGameView();
                    Units.Group.isDE = Units.Group.Players.Count > 6;
                    if (Units.Group.isDE)
                    {
                        Units.Group.GameDE = new TGameDE(Units.Group.Players.ToArray(), Units.Group.Settings);
                        // GameDE.FromString(GameDE.ToString,@Settings);
                        PrintImage.Image = Units.Group.GameDE.ToBitmap();
                    }
                    else
                    {
                        Units.Group.GameRR = new TGameRR(Units.Group.Players.ToArray(), Units.Group.Settings);
                        // GameRR.FromString(GameRR.ToString(),@Settings);
                        PrintImage.Image = Units.Group.GameRR.ToBitmap();
                    }
                    Units.Group.Players = new List<TPlayer>();
                    if (Units.Group.Settings.AutoResizeForm)
                    {
                        AutoResize();
                    }
                    BackupRunning();
                }
            }
            else
            {
                if (Units.Group.isDE)
                {
                    NextMatch = Units.Group.GameDE.GetNextMatch();
                }
                else
                {
                    NextMatch = Units.Group.GameRR.GetNextMatch();
                }
                if (NextMatch != null)
                {
                    Units.Fight.FightForm.PlayerALabel.Text = NextMatch.PlayerA.Lastname + ", " + NextMatch.PlayerA.Prename;
                    Units.Fight.FightForm.PlayerBLabel.Text = NextMatch.PlayerB.Lastname + ", " + NextMatch.PlayerB.Prename;
                    Units.Display.DisplayForm.PlayerALabel.Text = Units.Fight.FightForm.PlayerALabel.Text;
                    Units.Display.DisplayForm.PlayerBLabel.Text = Units.Fight.FightForm.PlayerBLabel.Text;
                    //TODO use global settings object
                    if (Units.Group.isDE)
                    {
                        if (Units.Group.GameDE.Settings.UseRedForPlayerA)
                        {
                            Units.Fight.FightForm.PlayerAShape.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            Units.Fight.FightForm.PlayerAShape.BackColor = System.Drawing.Color.Blue;
                        }
                    }
                    else if (Units.Group.GameRR.Settings.UseRedForPlayerA)
                    {
                        Units.Fight.FightForm.PlayerAShape.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        Units.Fight.FightForm.PlayerAShape.BackColor = System.Drawing.Color.Blue;
                    }
                    Units.Display.DisplayForm.PlayerAShape.BackColor = Units.Fight.FightForm.PlayerAShape.BackColor;
                    Units.Fight.BacklinkForm = Units.Group.GroupForm;
                    Units.Fight.BacklinkUpdater = Updater;
                    Units.Fight.BacklinkSettings = Units.Group.Settings;
                    if (Units.Group.isDE)
                    {
                        Units.Fight.BacklinkGameDE = Units.Group.GameDE;
                        Units.Fight.BacklinkGameRR = null;
                    }
                    else
                    {
                        Units.Fight.BacklinkGameDE = null;
                        Units.Fight.BacklinkGameRR = Units.Group.GameRR;
                    }
                    Units.Group.GroupForm.Enabled = false;
                    Units.Fight.FightForm.ShowDialog(this);
                    if (Units.Group.isDE)
                    {
                        tmpmatch = Units.Group.GameDE.GetPreparingMatch();
                    }
                    else
                    {
                        tmpmatch = Units.Group.GameRR.GetPreparingMatch();
                    }
                    if (tmpmatch != null)
                    {
                        PrepareLabel.Text = "Vorbereitung: " + UHelpers.UHelpers.PlayerToStr(tmpmatch.PlayerA, true, false) + " vs " + UHelpers.UHelpers.PlayerToStr(tmpmatch.PlayerB, true, false);
                    }
                    else
                    {
                        PrepareLabel.Text = "Vorbereitung: -";
                        NextStepButton.Text = "Ergebnisliste";
                    }
                    Units.Display.DisplayForm.PrepareLabel.Text = PrepareLabel.Text;
                }
                else
                {
                    // showmessage('Game is over');
                    if (Units.Group.isDE)
                    {
                        List<KeyValuePair<int, TPlayer>>  tmpDE = Units.Group.GameDE.ResultList();
                        for (i = 0; i < tmpDE.Count; i ++ )
                        {
                            s = s + tmpDE[i].Key.ToString() + ". " + UHelpers.UHelpers.PlayerToStr(tmpDE[i].Value) + "\n";
                        }
                    }
                    else
                    {
                        if (Units.Group.GameRRStore == null)
                        {
                            tmp = Units.Group.GameRR.ResultList();
                        }
                        else
                        {
                            tmp = Units.Group.GameRR.ResultList(Units.Group.GameRRStore);
                        }
                        for (i = 0; i < tmp.Count; i ++ )
                        {
                            if (tmp[i].player != null)
                            {
                                s = s + (tmp[i].position).ToString() + ". " + UHelpers.UHelpers.PlayerToStr(tmp[i].player) + " [" + (tmp[i].winPoints).ToString() + '/' + (tmp[i].lossPoints).ToString() + ']' + (char)(13);
                            }
                            else
                            {
                                s = s + (tmp[i].position).ToString() + ". ?" + (char)(13);
                            }
                        }
                        // showmessage(s);
                        // undefined positions (-1) -> additional round
                        bad =  -1;
                        for (i = 0; i < tmp.Count; i ++ )
                        {
                            if (tmp[i].position ==  -1)
                            {
                                bad = i;
                                break;
                            }
                        }
                        if (bad !=  -1)
                        {
                            // zweiter ist auch erster platz
                            if (Units.Group.GameRRStore == null)
                            {
                                i = bad;
                                bad = 0;
                                while (i < tmp.Count)
                                {
                                    if (tmp[i].position ==  -1)
                                    {
                                        playersforfinal.Add(tmp[i].player);
                                        bad = bad + 1;
                                    }
                                    i = i + 1;
                                }
                                if (playersforfinal.Count == tmp.Count)
                                {
                                    // all players -1
                                    Units.Group.GameRR = new TGameRR(Units.Group.GameRR.Players, Units.Group.Settings);
                                    MessageBox.Show(("Alle Kämpfer sind gleich gut." + (char)(13) + "Das Turnier wird neu gestartet." as string), ("Neustart" as string), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                                }
                                else
                                {
                                    Units.Group.GameRRStore = Units.Group.GameRR;
                                    Units.Group.GameRR = new TGameRR(playersforfinal.ToArray(), Units.Group.Settings);
                                    MessageBox.Show(("Mehr als zwei Kämpfer sind in der Hauptrunde" + (char)(13) + "gleich gut. Alle gleich guten Kämpfer" + (char)(13) + "werden in der Zusatzrunde plaziert, die nun beginnt." as string), ("Zusätzliche Runde" as string), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                Units.Group.GameRR = new TGameRR(Units.Group.GameRR.Players, Units.Group.Settings);
                                MessageBox.Show(("Mehr als zwei Kämpfer sind in der Zusatzrunde" + (char)(13) + "gleich gut. Die Zusatzrunde wird neu gestartet." as string), ("Neustart" as string), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            }
                            Updater();
                            NextStepButton.Text = "Nächster Kampf";
                            // NextStepButtonClick(self);
                            s = "";
                        }
                    }
                }
                if (s != "")
                {
                    MessageBox.Show(s);
                    PrintResultButton.Visible = true;
                }
            }
        }

        public void SettingsButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkForm = Units.Group.GroupForm;
            Units.Settings.BacklinkSettings = Units.Group.Settings;
            Units.Group.GroupForm.Enabled = false;
            Units.Settings.SettingsForm.ShowDialog(this);
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            Units.Group.Settings = new TSettings(); // Defaults in constructor
            this.Text = Units.Class.APPNAME + ' ' + Units.Class.VERSION;
            Units.Group.Settings.ReadFromFile(Path.GetDirectoryName(System.Environment.GetCommandLineArgs()[0]) + Units.Class.INIFILE + ".ini");
            Units.Group.Settings.LoadImageFromFile(Units.Class.LOGOFILE + ".bmp");
        }

        public void AddPlayerButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            int i;
            // SEP_MATCH = SEP_PLAYER
            PrenameEdit.Text = PrenameEdit.Text.Replace(Units.Class.SEP_PLAYER, '_');
            // PrenameEdit.Text := StringReplace(PrenameEdit.Text,SEP_MATCH,'_',[rfReplaceAll]);
            PrenameEdit.Text = PrenameEdit.Text.Replace(Units.Class.SEP_LIST, '_');
            PrenameEdit.Text = PrenameEdit.Text.Replace(Units.Class.SEP_GAME, '_');
            LastnameEdit.Text = LastnameEdit.Text.Replace(Units.Class.SEP_PLAYER, '_');
            // LastnameEdit.Text := StringReplace(LastnameEdit.Text,SEP_MATCH,'_',[rfReplaceAll]);
            LastnameEdit.Text = LastnameEdit.Text.Replace(Units.Class.SEP_LIST, '_');
            LastnameEdit.Text = LastnameEdit.Text.Replace(Units.Class.SEP_GAME, '_');
            ClubEdit.Text = ClubEdit.Text.Replace(Units.Class.SEP_PLAYER, '_');
            // ClubEdit.Text := StringReplace(ClubEdit.Text,SEP_MATCH,'_',[rfReplaceAll]);
            ClubEdit.Text = ClubEdit.Text.Replace(Units.Class.SEP_LIST, '_');
            ClubEdit.Text = ClubEdit.Text.Replace(Units.Class.SEP_GAME, '_');
            for (i = 0; i < Units.Group.Players.Count; i ++ )
            {
                if ((Units.Group.Players[i].Lastname == LastnameEdit.Text) && (Units.Group.Players[i].Prename == PrenameEdit.Text))
                {
                    MessageBox.Show((PrenameEdit.Text + ' ' + LastnameEdit.Text + " ist bereits eingetragen!" as string), ("Fehler" as string), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
            }
            Units.Group.Players.Add(new TPlayer());
            Units.Group.Players[Units.Group.Players.Count - 1].Prename = PrenameEdit.Text;
            Units.Group.Players[Units.Group.Players.Count - 1].Lastname = LastnameEdit.Text;
            if (ClubEdit.Text == "Verein")
            {
                Units.Group.Players[Units.Group.Players.Count - 1].Club = "";
            }
            else
            {
                Units.Group.Players[Units.Group.Players.Count - 1].Club = ClubEdit.Text;
            }
            PlayerBox.Items.Add(UHelpers.UHelpers.PlayerToStr(Units.Group.Players[Units.Group.Players.Count - 1]));
            PrenameEdit.Text = "Vorname";
            LastnameEdit.Text = "Nachname";
            ClubEdit.Text = "Verein";
            PrenameEdit.Focus();
        }

        public void PrenameEditEnter(System.Object Sender, System.EventArgs _e1)
        {
            if (this.Text == "Vorname")
            {
                this.Text = "";
            }
        }

        public void LastnameEditEnter(System.Object Sender, System.EventArgs _e1)
        {
            if (this.Text == "Nachname")
            {
                this.Text = "";
            }
        }

        public void ClubEditEnter(System.Object Sender, System.EventArgs _e1)
        {
            if (this.Text == "Verein")
            {
                this.Text = "";
            }
        }

        public void DelPlayerButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            int i;
            i = PlayerBox.SelectedIndex;
            if (i ==  -1)
            {
                MessageBox.Show(("Bitte wählen Sie einen Kämpfer zum Löschen aus." as string), ("Fehler" as string), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
            else
            {
                Units.Group.Players.RemoveAt(PlayerBox.SelectedIndex);
                PlayerBox.Items.RemoveAt(PlayerBox.SelectedIndex);
            }
        }

        // Note: the original parameters are Object Sender, ref TCloseAction Action
        public void FormClose(object sender, FormClosedEventArgs e)
        {
            File.Delete(Units.Class.BACKUPFILE + Units.Class.FILEEXT);
            Application.Exit();
        }

        public void FormResize(System.Object Sender, System.EventArgs _e1)
        {
            ScrollBox.Width = this.Width - ScrollBox.Left - 16 - 5;
            PlayersBox.Width = this.Width - PlayersBox.Left - 16 - 5;
            ProgressBar.Width = this.Width - ProgressBar.Left - (5 + StatsLabel.Width + 5) - 16;
            ScrollBox.Height = this.Height - ScrollBox.Top - 36 - 23;
            PlayersBox.Height = this.Height - PlayersBox.Top - 36 - 23;
            PrintResultButton.Left = this.Width - PrintResultButton.Width - 5 - SettingsButton.Width - 5 - 16;
            PrintGameButton.Left = PrintResultButton.Left;
            SettingsButton.Left = this.Width - SettingsButton.Width - 16 - 5;
            StatsLabel.Left = this.Width - StatsLabel.Width - 16 - 5;
            // height: 9 vs labels 13	  StatsLabel.Top := Height-StatsLabel.Height-36-5;

        }

        // Note: the original parameters are Object Sender, Keys Shift, int WheelDelta, Point MousePos, ref bool Handled
        public void FormMouseWheel(System.Object Sender, System.Windows.Forms.MouseEventArgs _e1)
        {
            //@ Unsupported property or method(C): 'VertScrollBar'
            //@ Unsupported property or method(D): 'Position'
            //@ Unsupported property or method(C): 'VertScrollBar'
            //@ Unsupported property or method(D): 'Position'
            //TODO: ScrollBox.VertScrollBar.Position = ScrollBox.VertScrollBar.Position - Math.Round(WheelDelta / 2);
        }

        public void PrintGameButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Bitmap tmpbitmap;
            if (Units.Group.isDE)
            {
                Units.Print.Printing.Print(this, Units.Group.GameDE.ToBitmap(20), "Spielplan Doppel-KO", true, UPrint.PRINTSCALE.PRINTSCL_SCALE_X);
            }
            else
            {
                if (Units.Group.GameRRStore != null)
                {
                    tmpbitmap = Units.Group.GameRR.ToBitmap(Units.Group.GameRRStore, 20);
                    Units.Print.Printing.Print(this, tmpbitmap, "Spielplan Jeder gegen Jeden", false, UPrint.PRINTSCALE.PRINTSCL_GLUE);
                }
                else
                {
                    Units.Print.Printing.Print(this, Units.Group.GameRR.ToBitmap(null, 20), "Spielplan Jeder gegen Jeden", false, UPrint.PRINTSCALE.PRINTSCL_GLUE);
                }
            }
        }

        public void PrintResultButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            if (Units.Group.isDE)
            {
                Units.Print.Printing.Print(this, Units.Group.GameDE.ToBitmapResult(Units.Group.Settings.Logo, 20), "Spielplan Doppel-KO", true, UPrint.PRINTSCALE.PRINTSCL_SCALE_X);
            }
            else
            {
                if (Units.Group.GameRRStore != null)
                {
                    Units.Print.Printing.Print(this, Units.Group.GameRR.ToBitmapResult(Units.Group.GameRRStore, Units.Group.Settings.Logo, 20), "Spielplan Jeder gegen Jeden", false, UPrint.PRINTSCALE.PRINTSCL_GLUE);
                }
                else
                {
                    Units.Print.Printing.Print(this, Units.Group.GameRR.ToBitmapResult(null, Units.Group.Settings.Logo, 20), "Spielplan Jeder gegen Jeden", false, UPrint.PRINTSCALE.PRINTSCL_GLUE);
                }
            }
        }

        public void FormShow(object sender, EventArgs e)
        {
            if (Units.Group.TryRestore && RestoreBackup())
            {
                MessageBox.Show(("Es wurde ein Backup-Abbild gefunden und versucht, das Spiel wiederherzustellen." + (char)(13) + "Bitte nimm dir die Zeit, mir zu berichten, wo und wann (und warum) das Programm abgestürzt ist." as string), ("Absturz" as string), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
            Units.Group.TryRestore = false;
        }

        public void FormCloseQuery(object sender, FormClosingEventArgs e)
        {
            bool ask;
            ask = false;
            if (Units.Group.GameDE != null)
            {
                if (Units.Group.GameDE.GetNextMatch() != null)
                {
                    ask = true;
                }
            }
            else if (Units.Group.GameRR != null)
            {
                if (Units.Group.GameRR.GetNextMatch() != null)
                {
                    ask = true;
                }
            }
            if (ask && (MessageBox.Show(("Wirklich beenden? Im Moment ist ein Spiel aktiv!" as string), ("Beenden" as string), System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Exclamation ) == System.Windows.Forms.DialogResult.Cancel))
            {
                e.Cancel = true;
            }
        }
    } // end TGroupForm

}

namespace Units
{
    public class Group
    {
        public static UGroup.TGroupForm GroupForm = null;
        public static TGameDE GameDE = null;
        public static TGameRR GameRR = null;
        public static TGameRR GameRRStore = null;
        public static TSettings Settings = null;
        public static List<TPlayer> Players = new List<TPlayer>();
        public static bool isDE = false;
        public static bool TryRestore = true;
    } // end UGroup

}

