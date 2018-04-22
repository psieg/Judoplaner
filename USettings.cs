using System;
using System.Windows.Forms;
using System.IO;
using UClass;
namespace USettings
{
    public partial class TSettingsForm: Form
    {
        public TSettingsForm()
        {
            InitializeComponent();
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.IniFileName = Path.GetDirectoryName(System.Environment.GetCommandLineArgs()[0]) + Units.Class.INIFILE + ".ini";
        }

        public void OKButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkForm.Enabled = true;
            if (Units.Settings.BacklinkSettings.SaveToIni)
            {
                Units.Settings.BacklinkSettings.WriteToFile(Units.Settings.IniFileName);
            }
            Units.Settings.SettingsForm.Hide();
        }

        // Note: the original parameters are Object Sender, ref TCloseAction Action
        public void FormClose(System.Object Sender, System.Windows.Forms.FormClosingEventArgs _e1)
        {
            Units.Settings.BacklinkForm.Enabled = true;
            if (Units.Settings.BacklinkSettings.SaveToIni)
            {
                Units.Settings.BacklinkSettings.WriteToFile(Units.Settings.IniFileName);
            }
            Units.Settings.SettingsForm.Hide();
            _e1.Cancel = true;
        }

        public void AutoResizeFormBoxClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.AutoResizeForm = AutoResizeFormBox.Checked;
        }

        public void UseRedForFirstPlayerBoxClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.UseRedForPlayerA = UseRedForFirstPlayerBox.Checked;
        }

        public void ShortLoseRound16ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.ShortLoseRound = 4;
        }

        public void ShortLoseRound32ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.ShortLoseRound = 5;
        }

        public void ShortLoseRound64ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.ShortLoseRound = 6;
        }

        public void ShortLoseRound128ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.ShortLoseRound = 7;
        }

        public void ShortLoseRoundNoneButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.ShortLoseRound =  -1;
        }

        public void FightDuration2ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            // BacklinkSettings.FightDuration := 120;
            FightDurationEdit.Text = 120.ToString();
        }

        public void FightDuration3ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            // BacklinkSettings.FightDuration := 180;
            FightDurationEdit.Text = 180.ToString();
        }

        public void FightDuration4ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            // BacklinkSettings.FightDuration := 240;
            FightDurationEdit.Text = 240.ToString();
        }

        public void FightDuration5ButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            // BacklinkSettings.FightDuration := 300;
            FightDurationEdit.Text = 300.ToString();
        }

        public void FightDurationEditChange(System.Object Sender, System.EventArgs _e1)
        {
            if (FightDurationEdit.Text == "")
            {
                Units.Settings.BacklinkSettings.FightDuration = 180;
            }
            else
            {
                try {
                    Units.Settings.BacklinkSettings.FightDuration = Convert.ToInt32(FightDurationEdit.Text);
                    switch(Units.Settings.BacklinkSettings.FightDuration)
                    {
                        case 120:
                            FightDuration2Button.Checked = true;
                            break;
                        case 180:
                            FightDuration3Button.Checked = true;
                            break;
                        case 240:
                            FightDuration4Button.Checked = true;
                            break;
                        case 300:
                            FightDuration5Button.Checked = true;
                            break;
                        default:
                            FightDurationCustomButton.Checked = true;
                            break;
                    }
                }
                catch {
                    MessageBox.Show('\'' + FightDurationEdit.Text + "\' ist keine gültige Sekundenzahl.", "Fehler", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                    FightDurationEdit.Text = (Units.Settings.BacklinkSettings.FightDuration).ToString();
                }
            }
        }

        public void SwitchStepsSystemAt32BoxClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.SwitchStepsSystemAt32 = SwitchStepsSystemAt32Box.Checked;
        }

        public void SwitchJumpSlotOrderAt32BoxClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.SwitchJumpSlotOrderAt32 = SwitchJumpSlotOrderAt32Box.Checked;
        }

        public void SaveToIniBoxClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.SaveToIni = SaveToIniBox.Checked;
            if (!SaveToIniBox.Checked)
            {
                // written autmatically on formclose/okclick
                if (File.Exists(Units.Settings.IniFileName))
                {
                    File.Delete(Units.Settings.IniFileName);
                }
            }
        }

        public void FormShow(object Sender, EventArgs e)
        {
            AutoResizeFormBox.Checked = Units.Settings.BacklinkSettings.AutoResizeForm;
            UseRedForFirstPlayerBox.Checked = Units.Settings.BacklinkSettings.UseRedForPlayerA;
            switch(Units.Settings.BacklinkSettings.ShortLoseRound)
            {
                case 4:
                    ShortLoseRound16Button.Checked = true;
                    break;
                case 5:
                    ShortLoseRound32Button.Checked = true;
                    break;
                case 6:
                    ShortLoseRound64Button.Checked = true;
                    break;
                case 7:
                    ShortLoseRound128Button.Checked = true;
                    break;
                default:
                    ShortLoseRoundNoneButton.Checked = true;
                    break;
            }
            FightDurationEdit.Text = (Units.Settings.BacklinkSettings.FightDuration).ToString();
            switch(Units.Settings.BacklinkSettings.FightDuration)
            {
                case 120:
                    FightDuration2Button.Checked = true;
                    break;
                case 180:
                    FightDuration3Button.Checked = true;
                    break;
                case 240:
                    FightDuration4Button.Checked = true;
                    break;
                case 300:
                    FightDuration5Button.Checked = true;
                    break;
                default:
                    FightDurationCustomButton.Checked = true;
                    break;
            }
            SwitchStepsSystemAt32Box.Checked = Units.Settings.BacklinkSettings.SwitchStepsSystemAt32;
            SwitchJumpSlotOrderAt32Box.Checked = Units.Settings.BacklinkSettings.SwitchJumpSlotOrderAt32;
            SaveToIniBox.Checked = Units.Settings.BacklinkSettings.SaveToIni;
            if (Units.Settings.BacklinkSettings.Logo == null)
            {
                LogoLabel.Text = "Kein Logo gefunden";
            }
            else
            {
                LogoLabel.Text = "Logo geladen";
            }
        }

        public void DefaultsButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.Reset();
            FormShow(this, null);
        }

        public void ReloadLogoButtonClick(System.Object Sender, System.EventArgs _e1)
        {
            Units.Settings.BacklinkSettings.LoadImageFromFile(Units.Class.LOGOFILE + ".bmp");
            if (Units.Settings.BacklinkSettings.Logo == null)
            {
                LogoLabel.Text = "Kein Logo gefunden";
            }
            else
            {
                LogoLabel.Text = "Logo geladen";
            }
        }

    } // end TSettingsForm

}

namespace Units
{
    public class Settings
    {
        public static USettings.TSettingsForm SettingsForm = null;
        public static Form BacklinkForm = null;
        public static TSettings BacklinkSettings = null;
        public static string IniFileName = String.Empty;
    } // end USettings

}

