using System;
using System.Windows.Forms;
using UClass;
using UHelpers;
using UGameRR;
using UGameDE;
using UDisplay;
namespace UFight
{
    public partial class TFightForm: Form
    {
        public TFightForm()
        {
            InitializeComponent();
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            Units.Fight.FightTime = 0;
            Units.Fight.HoldTime = 0;
            Units.Fight.HoldTimeMax = 25;
            Units.Fight.Holding = 0;
        }

        public void TimeTimerTimer(System.Object Sender, System.EventArgs _e1)
        {
            bool Player;
            Units.Fight.FightTime = Units.Fight.FightTime + 1;
            if (Units.Fight.Holding != 0)
            {
                Units.Fight.HoldTime = Units.Fight.HoldTime + 1;
            }
            Updater();
            if (Units.Fight.Holding != 0)
            {
                if (Units.Fight.Holding == 1)
                {
                    Player = Units.Fight.A;
                }
                else
                {
                    Player = Units.Fight.B;
                }
                if (Units.Fight.HoldTime == 20)
                {
                    Backup();
                    Give7Points(Player);
                }
                else if (Units.Fight.HoldTime == 25)
                {
                    Backup();
                    Revoke7Points(Player);
                    Give10Points(Player);
                }
            }
            if (Units.Fight.FightTime >= Math.Floor(Units.Fight.BacklinkSettings.FightDuration * 1.5))
            {
                // Schiedsrichterentscheidung
                MessageBox.Show("schiedsrichterentscheidung");
            }
            else if (Units.Fight.FightTime > Units.Fight.BacklinkSettings.FightDuration)
            {
                if (Result() == FIGHT_RESULT.FR_AWINS)
                {
                    Finish(PlayerAPoints(), Units.Fight.A);
                }
                else if (Result() == FIGHT_RESULT.FR_BWINS)
                {
                    Finish(PlayerBPoints(), Units.Fight.B);
                }
                else
                {
                    PauseButtonClick(this, null);
                    MessageBox.Show("Die Kampfzeit von " + UHelpers.UHelpers.TimeToStr(Units.Fight.BacklinkSettings.FightDuration) + " ist erreicht worden, ohne dass ein K�mpfer gesiegt hat." +
                        "Der Kampf wird unterbrochen (Fortsetzung mit Hajime), danach beginnt Golden Score." +
                        "Der erste K�mpfer, der eine beliebige Wertung erzielt, siegt.",
                    "Unentschieden",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
        }

        public void GoButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            GoButton.Visible = false;
            PauseButton.Visible = true;
            TimeTimer.Enabled = true;
            TimeLabel.Text = UHelpers.UHelpers.TimeToStr(Units.Fight.FightTime);
        }

        public void PauseButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            TimeTimer.Enabled = false;
            if (Units.Fight.Holding != 0)
            {
                UnHold();
            }
            GoButton.Visible = true;
            PauseButton.Visible = false;
        }

        // Revoke procedures do not care about consequences, use Backup() and Restore()
        // Revoke procedures do not update nor backup, only call internally!
        public void Give7Points(bool PlayerA, bool direct, bool checkwin)
        {
            int PlayerX7Points;
            if (direct)
            {
                Backup();
            }
            if (PlayerA)
            {
                Units.Fight.PlayerA7Points = Units.Fight.PlayerA7Points + 1;
            }
            else
            {
                Units.Fight.PlayerB7Points = Units.Fight.PlayerB7Points + 1;
            }
            Updater();
            if (PlayerA)
            {
                PlayerX7Points = Units.Fight.PlayerA7Points;
            }
            else
            {
                PlayerX7Points = Units.Fight.PlayerB7Points;
            }
            if (checkwin)
            {
                if (PlayerX7Points == 2)
                {
                    Finish(10, PlayerA);
                }
                else if (Units.Fight.FightTime >= Units.Fight.BacklinkSettings.FightDuration)
                {
                    Finish(7, PlayerA);
                }
            }
        }

        public void Give7Points(bool PlayerA)
        {
            Give7Points(PlayerA, false);
        }

        public void Give7Points(bool PlayerA, bool direct)
        {
            Give7Points(PlayerA, direct, true);
        }

        public void Revoke7Points(bool PlayerA)
        {
            if (PlayerA)
            {
                Units.Fight.PlayerA7Points = Units.Fight.PlayerA7Points - 1;
            }
            else
            {
                Units.Fight.PlayerB7Points = Units.Fight.PlayerB7Points - 1;
            }
        }

        public void Give10Points(bool PlayerA, bool direct, bool checkwin)
        {
            if (direct)
            {
                Backup();
            }
            if (PlayerA)
            {
                Units.Fight.PlayerA10Points = Units.Fight.PlayerA10Points + 1;
            }
            else
            {
                Units.Fight.PlayerB10Points = Units.Fight.PlayerB10Points + 1;
            }
            Updater();
            if (checkwin)
            {
                Finish(10, PlayerA);
            }
        }

        public void Give10Points(bool PlayerA)
        {
            Give10Points(PlayerA, false);
        }

        public void Give10Points(bool PlayerA, bool direct)
        {
            Give10Points(PlayerA, direct, true);
        }

        public void Revoke10Points(bool PlayerA)
        {
            if (PlayerA)
            {
                Units.Fight.PlayerA10Points = Units.Fight.PlayerA10Points - 1;
            }
            else
            {
                Units.Fight.PlayerB10Points = Units.Fight.PlayerB10Points - 1;
            }
        }

        public void Punish(bool PlayerA, bool direct, bool checkwin)
        {
            int PlayerXPunish;
            int PlayerX7Points;
            // TODO:
            // - neu aufsetzen
            if (direct)
            {
                Backup();
            }
            if (PlayerA)
            {
                Units.Fight.PlayerAPunish = Units.Fight.PlayerAPunish + 1;
                PlayerXPunish = Units.Fight.PlayerAPunish;
                PlayerX7Points = Units.Fight.PlayerA7Points;
            }
            else
            {
                Units.Fight.PlayerBPunish = Units.Fight.PlayerBPunish + 1;
                PlayerXPunish = Units.Fight.PlayerBPunish;
                PlayerX7Points = Units.Fight.PlayerB7Points;
            }
            if (PlayerXPunish == 3)
            {
                Give10Points(!PlayerA, false, true);
            }
            Updater();
        }

        public void Punish(bool PlayerA)
        {
            Punish(PlayerA, false);
        }

        public void Punish(bool PlayerA, bool direct)
        {
            Punish(PlayerA, direct, true);
        }

        public void RevokePunish(bool PlayerA)
        {
            if (PlayerA)
            {
                Units.Fight.PlayerAPunish = Units.Fight.PlayerAPunish - 1;
            }
            else
            {
                Units.Fight.PlayerBPunish = Units.Fight.PlayerBPunish - 1;
            }
        }

        public void Hold(bool PlayerA)
        {
            if (PlayerA)
            {
                PlayerBHoldButton.Enabled = false;
                PlayerAHoldButton.Text = "Toketa";
                Units.Fight.Holding = 1;
            }
            else
            {
                PlayerAHoldButton.Enabled = false;
                PlayerBHoldButton.Text = "Toketa";
                Units.Fight.Holding = 2;
            }
            Units.Fight.HoldTimeMax = TimeToHold();
            PlayerA10Button.Enabled = false;
            PlayerB10Button.Enabled = false;
            PlayerA7Button.Enabled = false;
            PlayerB7Button.Enabled = false;
            PlayerAPunishButton.Enabled = false;
            PlayerBPunishButton.Enabled = false;
        }

        public void UnHold()
        {
            PlayerAHoldButton.Enabled = true;
            PlayerBHoldButton.Enabled = true;
            PlayerAHoldButton.Text = "Osae-komi";
            PlayerBHoldButton.Text = "Osae-komi";
            Units.Fight.Holding = 0;
            Units.Fight.HoldTime = 0;
            PlayerA10Button.Enabled = true;
            PlayerB10Button.Enabled = true;
            PlayerA7Button.Enabled = true;
            PlayerB7Button.Enabled = true;
            PlayerAPunishButton.Enabled = true;
            PlayerBPunishButton.Enabled = true;
        }

        public void Backup()
        {
            Units.Fight._PlayerA7Points = Units.Fight.PlayerA7Points;
            Units.Fight._PlayerA10Points = Units.Fight.PlayerA10Points;
            Units.Fight._PlayerAPunish = Units.Fight.PlayerAPunish;
            Units.Fight._PlayerB7Points = Units.Fight.PlayerB7Points;
            Units.Fight._PlayerB10Points = Units.Fight.PlayerB10Points;
            Units.Fight._PlayerBPunish = Units.Fight.PlayerBPunish;
        }

        public void Restore()
        {
            Units.Fight.PlayerA7Points = Units.Fight._PlayerA7Points;
            Units.Fight.PlayerA10Points = Units.Fight._PlayerA10Points;
            Units.Fight.PlayerAPunish = Units.Fight._PlayerAPunish;
            Units.Fight.PlayerB7Points = Units.Fight._PlayerB7Points;
            Units.Fight.PlayerB10Points = Units.Fight._PlayerB10Points;
            Units.Fight.PlayerBPunish = Units.Fight._PlayerBPunish;
        }

        public int TimeToHold()
        {
            int result;
            int PlayerX7Points;
            if (Units.Fight.Holding == 1)
            {
                PlayerX7Points = Units.Fight.PlayerA7Points;
            }
            else
            {
                PlayerX7Points = Units.Fight.PlayerB7Points;
            }
            if (Units.Fight.FightTime >= Units.Fight.BacklinkSettings.FightDuration)
            {
                result = 15;
            }
            else if (PlayerX7Points >= 1)
            {
                result = 20;
            }
            else
            {
                result = 25;
            }
            return result;
        }

        public int PlayerAPoints()
        {
            int result;
            // TODO: 1 Point by decision / golden score
            if (Units.Fight.PlayerA10Points != 0)
            {
                result = 10;
            }
            else if (Units.Fight.PlayerA7Points != 0)
            {
                result = 7;
            }
            else
            {
                result =  -1;
            }
            // should not happen, call only when A has won

            return result;
        }

        public int PlayerBPoints()
        {
            int result;
            if (Units.Fight.PlayerB10Points != 0)
            {
                result = 10;
            }
            else if (Units.Fight.PlayerB7Points != 0)
            {
                result = 7;
            }
            else
            {
                result =  -1;
            }
            // should not happen, call only when B has won

            return result;
        }

        public FIGHT_RESULT Result()
        {
            FIGHT_RESULT result;
            if (Units.Fight.PlayerA10Points > Units.Fight.PlayerB10Points)
            {
                result = FIGHT_RESULT.FR_AWINS;
            }
            else if (Units.Fight.PlayerB10Points > Units.Fight.PlayerA10Points)
            {
                result = FIGHT_RESULT.FR_BWINS;
            }
            // both none (both > 0 impossible)
            else if (Units.Fight.PlayerA7Points > Units.Fight.PlayerB7Points)
            {
                result = FIGHT_RESULT.FR_AWINS;
            }
            else if (Units.Fight.PlayerB7Points > Units.Fight.PlayerA7Points)
            {
                result = FIGHT_RESULT.FR_BWINS;
            }
            // both equal
            else
            {
                result = FIGHT_RESULT.FR_TIE;
            }
            return result;
        }

        public void Updater(bool includeDisplay)
        {
            if (Units.Fight.FightTime > Units.Fight.BacklinkSettings.FightDuration)
            {
                TimeLabel.Text = UHelpers.UHelpers.TimeToStr(Units.Fight.FightTime - Units.Fight.BacklinkSettings.FightDuration);
            }
            else
            {
                TimeLabel.Text = UHelpers.UHelpers.TimeToStr(Units.Fight.FightTime);
            }
            if (Units.Fight.Holding == 0)
            {
                HoldTimeLabel.Text = "";
            }
            else
            {
                HoldTimeLabel.Text = UHelpers.UHelpers.TimeToStr(Units.Fight.HoldTimeMax - Units.Fight.HoldTime, UClass.TIMEFORMAT.TIMEFMT_S);
            }
            PlayerA7Label.Text = (Units.Fight.PlayerA7Points).ToString();
            PlayerA10Label.Text = (Units.Fight.PlayerA10Points).ToString();
            PlayerAPunishLabel.Text = (Units.Fight.PlayerAPunish).ToString();
            PlayerB7Label.Text = (Units.Fight.PlayerB7Points).ToString();
            PlayerB10Label.Text = (Units.Fight.PlayerB10Points).ToString();
            PlayerBPunishLabel.Text = (Units.Fight.PlayerBPunish).ToString();
            if (includeDisplay)
            {
                Units.Display.DisplayForm.TimeLabel.Text = TimeLabel.Text;
                Units.Display.DisplayForm.HoldTimeLabel.Text = HoldTimeLabel.Text;
                Units.Display.DisplayForm.HoldTimeLabel.Visible = HoldTimeLabel.Text != "";
                Units.Display.DisplayForm.PlayerA7Label.Text = PlayerA7Label.Text;
                Units.Display.DisplayForm.PlayerA10Label.Text = PlayerA10Label.Text;
                Units.Display.DisplayForm.PlayerAPunishLabel.Text = PlayerAPunishLabel.Text;
                Units.Display.DisplayForm.PlayerB7Label.Text = PlayerB7Label.Text;
                Units.Display.DisplayForm.PlayerB10Label.Text = PlayerB10Label.Text;
                Units.Display.DisplayForm.PlayerBPunishLabel.Text = PlayerBPunishLabel.Text;
            }
        }

        public void Updater()
        {
            Updater(true);
        }

        public void Finish(int PlayerXPoints, bool PlayerA)
        {
            PauseButtonClick(null, null);
            bool undo = MessageBox.Show((PlayerA ? (Units.Fight.BacklinkSettings.UseRedForPlayerA ? "Rot" : "Blau") : "Wei�") + " hat gewonnen.\n" +
            "Abbrechen f�r r�ckg�ngig.",
            "Kampfende",
            System.Windows.Forms.MessageBoxButtons.OK | System.Windows.Forms.MessageBoxButtons.OKCancel,
            System.Windows.Forms.MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.OK;

            if (undo)
            {
                UndoButtonClick(null, null);
            }
            else
            {
                if (Units.Fight.BacklinkGameDE != null)
                {
                    if (PlayerA)
                    {
                        Units.Fight.BacklinkGameDE.FinishCurrentMatch(PlayerXPoints, 0, Units.Fight.FightTime);
                    }
                    else
                    {
                        Units.Fight.BacklinkGameDE.FinishCurrentMatch(0, PlayerXPoints, Units.Fight.FightTime);
                    }
                }
                else if (PlayerA)
                {
                    Units.Fight.BacklinkGameRR.FinishCurrentMatch(PlayerXPoints, 0, Units.Fight.FightTime);
                }
                else
                {
                    Units.Fight.BacklinkGameRR.FinishCurrentMatch(0, PlayerXPoints, Units.Fight.FightTime);
                }
                TimeTimer.Enabled = false;
                Units.Fight.FightTime = 0;
                Units.Fight.HoldTime = 0;
                Units.Fight.Holding = 0;
                Units.Fight.PlayerA7Points = 0;
                Units.Fight.PlayerA10Points = 0;
                Units.Fight.PlayerAPunish = 0;
                Units.Fight.PlayerB7Points = 0;
                Units.Fight.PlayerB10Points = 0;
                Units.Fight.PlayerBPunish = 0;
                Backup();
                GoButton.Visible = true;
                PauseButton.Visible = false;
                PlayerALabel.Text = "";
                PlayerBLabel.Text = "";
                UnHold();
                Updater(false);
                Units.Fight.BacklinkForm.Enabled = true;
                Units.Fight.BacklinkUpdater();
                Units.Fight.FightForm.Hide();
            }
        }

        // the following handlers are only links to the gamelogic above
        public void PlayerA10ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Give10Points(Units.Fight.A, true);
        }

        public void PlayerB10ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Give10Points(Units.Fight.B, true);
        }

        public void PlayerA7ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Give7Points(Units.Fight.A, true);
        }

        public void PlayerB7ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Give7Points(Units.Fight.B, true);
        }

        public void PlayerAPunishButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Punish(Units.Fight.A, true);
        }

        public void PlayerBPunishButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Punish(Units.Fight.B, true);
        }

        public void PlayerAHoldButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            if (Units.Fight.Holding == 0)
            {
                Hold(Units.Fight.A);
            }
            else
            {
                UnHold();
            }
        }

        public void PlayerBHoldButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            if (Units.Fight.Holding == 0)
            {
                Hold(Units.Fight.B);
            }
            else
            {
                UnHold();
            }
        }

        public void UndoButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Restore();
            Updater();
        }

        // Note: the original parameters are Object Sender, ref bool CanClose
        public void FormCloseQuery(System.Object Sender, System.ComponentModel.CancelEventArgs _e1)
        {
            _e1.Cancel = true;
        }

    } // end TFightForm

    public enum FIGHT_RESULT
    {
        FR_AWINS,
        FR_BWINS,
        FR_TIE
    } // end FIGHT_RESULT

}

namespace Units
{
    public class Fight
    {
        public static UFight.TFightForm FightForm = null;
        public static int FightTime = 0;
        public static int HoldTime = 0;
        public static int HoldTimeMax = 0;
        public static int Holding = 0;
        public static int PlayerA7Points = 0;
        public static int PlayerA10Points = 0;
        public static int PlayerAPunish = 0;
        public static int PlayerB7Points = 0;
        public static int PlayerB10Points = 0;
        public static int PlayerBPunish = 0;
        public static int _PlayerA7Points = 0;
        public static int _PlayerA10Points = 0;
        public static int _PlayerAPunish = 0;
        public static int _PlayerB7Points = 0;
        public static int _PlayerB10Points = 0;
        public static int _PlayerBPunish = 0;
    // SpecialDecision: integer;
    // _SpecialDecision: integer;
        public static Form BacklinkForm = null;
        public static Action BacklinkUpdater = null;
        public static TSettings BacklinkSettings = null;
        public static TGameDE BacklinkGameDE = null;
        public static TGameRR BacklinkGameRR = null;
        public const bool A = true;
        public const bool B = false;
    } // end UFight

}

