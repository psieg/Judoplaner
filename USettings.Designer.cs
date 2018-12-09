namespace USettings
{
  partial class TSettingsForm
    {
        public System.Windows.Forms.Button OKButton;
        public System.Windows.Forms.GroupBox EasyBox;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Label LogoLabel;
        public System.Windows.Forms.CheckBox UseRedForFirstPlayerBox;
        public System.Windows.Forms.CheckBox AutoResizeFormBox;
        public System.Windows.Forms.Panel ShortLoseRoundPanel;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.RadioButton ShortLoseRound64Button;
        public System.Windows.Forms.RadioButton ShortLoseRound128Button;
        public System.Windows.Forms.RadioButton ShortLoseRound16Button;
        public System.Windows.Forms.RadioButton ShortLoseRound32Button;
        public System.Windows.Forms.RadioButton ShortLoseRoundNoneButton;
        public System.Windows.Forms.Panel FightDurationPanel;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.RadioButton FightDurationCustomButton;
        public System.Windows.Forms.RadioButton FightDuration2Button;
        public System.Windows.Forms.RadioButton FightDuration3Button;
        public System.Windows.Forms.RadioButton FightDuration4Button;
        public System.Windows.Forms.RadioButton FightDuration5Button;
        public System.Windows.Forms.TextBox FightDurationEdit;
        public System.Windows.Forms.Button ReloadLogoButton;
        public System.Windows.Forms.GroupBox ExtendedBox;
        public System.Windows.Forms.CheckBox SwitchStepsSystemAt32Box;
        public System.Windows.Forms.CheckBox SwitchJumpSlotOrderAt32Box;
        public System.Windows.Forms.Button DefaultsButton;
        public System.Windows.Forms.CheckBox SaveToIniBox;
        private System.Windows.Forms.ToolTip toolTip1 = null;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

#region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.UseRedForFirstPlayerBox = new System.Windows.Forms.CheckBox();
            this.AutoResizeFormBox = new System.Windows.Forms.CheckBox();
            this.ShortLoseRoundPanel = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.ShortLoseRound64Button = new System.Windows.Forms.RadioButton();
            this.ShortLoseRound128Button = new System.Windows.Forms.RadioButton();
            this.ShortLoseRound16Button = new System.Windows.Forms.RadioButton();
            this.ShortLoseRound32Button = new System.Windows.Forms.RadioButton();
            this.ShortLoseRoundNoneButton = new System.Windows.Forms.RadioButton();
            this.FightDurationPanel = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.FightDurationCustomButton = new System.Windows.Forms.RadioButton();
            this.FightDuration2Button = new System.Windows.Forms.RadioButton();
            this.FightDuration3Button = new System.Windows.Forms.RadioButton();
            this.FightDuration4Button = new System.Windows.Forms.RadioButton();
            this.FightDuration5Button = new System.Windows.Forms.RadioButton();
            this.FightDurationEdit = new System.Windows.Forms.TextBox();
            this.SwitchStepsSystemAt32Box = new System.Windows.Forms.CheckBox();
            this.SwitchJumpSlotOrderAt32Box = new System.Windows.Forms.CheckBox();
            this.SaveToIniBox = new System.Windows.Forms.CheckBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.EasyBox = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.LogoLabel = new System.Windows.Forms.Label();
            this.ReloadLogoButton = new System.Windows.Forms.Button();
            this.ExtendedBox = new System.Windows.Forms.GroupBox();
            this.DefaultsButton = new System.Windows.Forms.Button();
            this.ShortLoseRoundPanel.SuspendLayout();
            this.FightDurationPanel.SuspendLayout();
            this.EasyBox.SuspendLayout();
            this.ExtendedBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 89);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(66, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Kampfzeit";
            this.toolTip1.SetToolTip(this.Label1, "Diese Einstellung wirkt sich sofort aus");
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 65);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(247, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Verzürzte Trostrunde (ab Viertelfinale) verwenden ab";
            this.toolTip1.SetToolTip(this.Label2, "Diese Einstellung hat nur Auswirkungen auf die Erstellung eines neuen Turniers");
            // 
            // UseRedForFirstPlayerBox
            // 
            this.UseRedForFirstPlayerBox.Location = new System.Drawing.Point(6, 40);
            this.UseRedForFirstPlayerBox.Name = "UseRedForFirstPlayerBox";
            this.UseRedForFirstPlayerBox.Size = new System.Drawing.Size(521, 17);
            this.UseRedForFirstPlayerBox.TabIndex = 0;
            this.UseRedForFirstPlayerBox.Text = "Rot statt Blau für den ersten Kämpfer verwenden";
            this.toolTip1.SetToolTip(this.UseRedForFirstPlayerBox, "Diese Einstellung wird beim nächsten Kampf übernommen");
            this.UseRedForFirstPlayerBox.Click += new System.EventHandler(this.UseRedForFirstPlayerBoxClick);
            // 
            // AutoResizeFormBox
            // 
            this.AutoResizeFormBox.Location = new System.Drawing.Point(6, 19);
            this.AutoResizeFormBox.Name = "AutoResizeFormBox";
            this.AutoResizeFormBox.Size = new System.Drawing.Size(521, 17);
            this.AutoResizeFormBox.TabIndex = 1;
            this.AutoResizeFormBox.Text = "Fenster automatisch vergrößern, um ganzes Turnier anzuzeigen";
            this.toolTip1.SetToolTip(this.AutoResizeFormBox, "Diese Einstellung hat nur Auswirkungen auf die Erstellung eines neuen Turniers");
            this.AutoResizeFormBox.Click += new System.EventHandler(this.AutoResizeFormBoxClick);
            // 
            // ShortLoseRoundPanel
            // 
            this.ShortLoseRoundPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ShortLoseRoundPanel.Controls.Add(this.Label3);
            this.ShortLoseRoundPanel.Controls.Add(this.ShortLoseRound64Button);
            this.ShortLoseRoundPanel.Controls.Add(this.ShortLoseRound128Button);
            this.ShortLoseRoundPanel.Controls.Add(this.ShortLoseRound16Button);
            this.ShortLoseRoundPanel.Controls.Add(this.ShortLoseRound32Button);
            this.ShortLoseRoundPanel.Controls.Add(this.ShortLoseRoundNoneButton);
            this.ShortLoseRoundPanel.Location = new System.Drawing.Point(264, 64);
            this.ShortLoseRoundPanel.Name = "ShortLoseRoundPanel";
            this.ShortLoseRoundPanel.Size = new System.Drawing.Size(265, 17);
            this.ShortLoseRoundPanel.TabIndex = 2;
            this.toolTip1.SetToolTip(this.ShortLoseRoundPanel, "Diese Einstellung hat nur Auswirkungen auf die Erstellung eines neuen Turniers");
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(162, 1);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(22, 13);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "TN";
            // 
            // ShortLoseRound64Button
            // 
            this.ShortLoseRound64Button.Location = new System.Drawing.Point(80, 0);
            this.ShortLoseRound64Button.Name = "ShortLoseRound64Button";
            this.ShortLoseRound64Button.Size = new System.Drawing.Size(33, 17);
            this.ShortLoseRound64Button.TabIndex = 0;
            this.ShortLoseRound64Button.Text = "64";
            this.ShortLoseRound64Button.Click += new System.EventHandler(this.ShortLoseRound64ButtonClick);
            // 
            // ShortLoseRound128Button
            // 
            this.ShortLoseRound128Button.Location = new System.Drawing.Point(120, 0);
            this.ShortLoseRound128Button.Name = "ShortLoseRound128Button";
            this.ShortLoseRound128Button.Size = new System.Drawing.Size(41, 17);
            this.ShortLoseRound128Button.TabIndex = 1;
            this.ShortLoseRound128Button.Text = "128";
            this.ShortLoseRound128Button.Click += new System.EventHandler(this.ShortLoseRound128ButtonClick);
            // 
            // ShortLoseRound16Button
            // 
            this.ShortLoseRound16Button.Location = new System.Drawing.Point(0, 0);
            this.ShortLoseRound16Button.Name = "ShortLoseRound16Button";
            this.ShortLoseRound16Button.Size = new System.Drawing.Size(33, 17);
            this.ShortLoseRound16Button.TabIndex = 2;
            this.ShortLoseRound16Button.Text = "16";
            this.ShortLoseRound16Button.Click += new System.EventHandler(this.ShortLoseRound16ButtonClick);
            // 
            // ShortLoseRound32Button
            // 
            this.ShortLoseRound32Button.Location = new System.Drawing.Point(40, 0);
            this.ShortLoseRound32Button.Name = "ShortLoseRound32Button";
            this.ShortLoseRound32Button.Size = new System.Drawing.Size(33, 17);
            this.ShortLoseRound32Button.TabIndex = 3;
            this.ShortLoseRound32Button.Text = "32";
            this.ShortLoseRound32Button.Click += new System.EventHandler(this.ShortLoseRound32ButtonClick);
            // 
            // ShortLoseRoundNoneButton
            // 
            this.ShortLoseRoundNoneButton.Location = new System.Drawing.Point(192, -1);
            this.ShortLoseRoundNoneButton.Name = "ShortLoseRoundNoneButton";
            this.ShortLoseRoundNoneButton.Size = new System.Drawing.Size(65, 17);
            this.ShortLoseRoundNoneButton.TabIndex = 4;
            this.ShortLoseRoundNoneButton.Text = "garnicht";
            this.ShortLoseRoundNoneButton.Click += new System.EventHandler(this.ShortLoseRoundNoneButtonClick);
            // 
            // FightDurationPanel
            // 
            this.FightDurationPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FightDurationPanel.Controls.Add(this.Label5);
            this.FightDurationPanel.Controls.Add(this.FightDurationCustomButton);
            this.FightDurationPanel.Controls.Add(this.FightDuration2Button);
            this.FightDurationPanel.Controls.Add(this.FightDuration3Button);
            this.FightDurationPanel.Controls.Add(this.FightDuration4Button);
            this.FightDurationPanel.Controls.Add(this.FightDuration5Button);
            this.FightDurationPanel.Controls.Add(this.FightDurationEdit);
            this.FightDurationPanel.Location = new System.Drawing.Point(80, 88);
            this.FightDurationPanel.Name = "FightDurationPanel";
            this.FightDurationPanel.Size = new System.Drawing.Size(449, 45);
            this.FightDurationPanel.TabIndex = 3;
            this.toolTip1.SetToolTip(this.FightDurationPanel, "Diese Einstellung wirkt sich sofort aus");
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(103, 24);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(56, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Sekunden";
            // 
            // FightDurationCustomButton
            // 
            this.FightDurationCustomButton.AutoSize = true;
            this.FightDurationCustomButton.Location = new System.Drawing.Point(0, 22);
            this.FightDurationCustomButton.Name = "FightDurationCustomButton";
            this.FightDurationCustomButton.Size = new System.Drawing.Size(58, 17);
            this.FightDurationCustomButton.TabIndex = 0;
            this.FightDurationCustomButton.Text = "Eigene";
            // 
            // FightDuration2Button
            // 
            this.FightDuration2Button.AutoSize = true;
            this.FightDuration2Button.Location = new System.Drawing.Point(0, 1);
            this.FightDuration2Button.Name = "FightDuration2Button";
            this.FightDuration2Button.Size = new System.Drawing.Size(76, 17);
            this.FightDuration2Button.TabIndex = 1;
            this.FightDuration2Button.Text = "U11 (2min)";
            this.FightDuration2Button.Click += new System.EventHandler(this.FightDuration2ButtonClick);
            // 
            // FightDuration3Button
            // 
            this.FightDuration3Button.AutoSize = true;
            this.FightDuration3Button.Location = new System.Drawing.Point(82, 1);
            this.FightDuration3Button.Name = "FightDuration3Button";
            this.FightDuration3Button.Size = new System.Drawing.Size(76, 17);
            this.FightDuration3Button.TabIndex = 2;
            this.FightDuration3Button.Text = "U12 (3min)";
            this.FightDuration3Button.Click += new System.EventHandler(this.FightDuration3ButtonClick);
            // 
            // FightDuration4Button
            // 
            this.FightDuration4Button.AutoSize = true;
            this.FightDuration4Button.Location = new System.Drawing.Point(164, 1);
            this.FightDuration4Button.Name = "FightDuration4Button";
            this.FightDuration4Button.Size = new System.Drawing.Size(102, 17);
            this.FightDuration4Button.TabIndex = 3;
            this.FightDuration4Button.Text = "U17, U20 (4min)";
            this.FightDuration4Button.Click += new System.EventHandler(this.FightDuration4ButtonClick);
            // 
            // FightDuration5Button
            // 
            this.FightDuration5Button.AutoSize = true;
            this.FightDuration5Button.Location = new System.Drawing.Point(272, 1);
            this.FightDuration5Button.Name = "FightDuration5Button";
            this.FightDuration5Button.Size = new System.Drawing.Size(84, 17);
            this.FightDuration5Button.TabIndex = 4;
            this.FightDuration5Button.Text = "Ab 17 (5min)";
            this.FightDuration5Button.Click += new System.EventHandler(this.FightDuration5ButtonClick);
            // 
            // FightDurationEdit
            // 
            this.FightDurationEdit.Location = new System.Drawing.Point(64, 21);
            this.FightDurationEdit.Name = "FightDurationEdit";
            this.FightDurationEdit.Size = new System.Drawing.Size(33, 20);
            this.FightDurationEdit.TabIndex = 5;
            this.FightDurationEdit.Text = "180";
            this.FightDurationEdit.ModifiedChanged += new System.EventHandler(this.FightDurationEditChange);
            // 
            // SwitchStepsSystemAt32Box
            // 
            this.SwitchStepsSystemAt32Box.Location = new System.Drawing.Point(6, 19);
            this.SwitchStepsSystemAt32Box.Name = "SwitchStepsSystemAt32Box";
            this.SwitchStepsSystemAt32Box.Size = new System.Drawing.Size(521, 17);
            this.SwitchStepsSystemAt32Box.TabIndex = 0;
            this.SwitchStepsSystemAt32Box.Text = "Reihenfolge ab 32 Teilnehmern ändern und vor dem Finale 4 Trostrunden-Schritte ma" +
    "chen";
            this.toolTip1.SetToolTip(this.SwitchStepsSystemAt32Box, "Diese Einstellung hat nur Auswirkungen auf die Erstellung eines neuen Turniers");
            this.SwitchStepsSystemAt32Box.Click += new System.EventHandler(this.SwitchStepsSystemAt32BoxClick);
            // 
            // SwitchJumpSlotOrderAt32Box
            // 
            this.SwitchJumpSlotOrderAt32Box.Location = new System.Drawing.Point(6, 42);
            this.SwitchJumpSlotOrderAt32Box.Name = "SwitchJumpSlotOrderAt32Box";
            this.SwitchJumpSlotOrderAt32Box.Size = new System.Drawing.Size(521, 17);
            this.SwitchJumpSlotOrderAt32Box.TabIndex = 1;
            this.SwitchJumpSlotOrderAt32Box.Text = "Ab 32 Teilnehmern die erste Trostrunde blockweise sortieren anstatt von oben zu f" +
    "üllen";
            this.toolTip1.SetToolTip(this.SwitchJumpSlotOrderAt32Box, "Diese Einstellung hat nur Auswirkungen auf die Erstellung eines neuen Turniers");
            this.SwitchJumpSlotOrderAt32Box.Click += new System.EventHandler(this.SwitchJumpSlotOrderAt32BoxClick);
            // 
            // SaveToIniBox
            // 
            this.SaveToIniBox.Location = new System.Drawing.Point(12, 252);
            this.SaveToIniBox.Name = "SaveToIniBox";
            this.SaveToIniBox.Size = new System.Drawing.Size(521, 17);
            this.SaveToIniBox.TabIndex = 4;
            this.SaveToIniBox.Text = "Einstellungen dauerhaft merken (in INI-Datei speichern)";
            this.toolTip1.SetToolTip(this.SaveToIniBox, "Diese Einstellung hat nur Auswirkungen auf die Erstellung eines neuen Turniers");
            this.SaveToIniBox.Click += new System.EventHandler(this.SaveToIniBoxClick);
            // 
            // OKButton
            // 
            this.OKButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OKButton.Location = new System.Drawing.Point(12, 275);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(169, 25);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButtonClick);
            // 
            // EasyBox
            // 
            this.EasyBox.Controls.Add(this.Label1);
            this.EasyBox.Controls.Add(this.Label2);
            this.EasyBox.Controls.Add(this.Label4);
            this.EasyBox.Controls.Add(this.LogoLabel);
            this.EasyBox.Controls.Add(this.UseRedForFirstPlayerBox);
            this.EasyBox.Controls.Add(this.AutoResizeFormBox);
            this.EasyBox.Controls.Add(this.ShortLoseRoundPanel);
            this.EasyBox.Controls.Add(this.FightDurationPanel);
            this.EasyBox.Controls.Add(this.ReloadLogoButton);
            this.EasyBox.Location = new System.Drawing.Point(12, 12);
            this.EasyBox.Name = "EasyBox";
            this.EasyBox.Size = new System.Drawing.Size(537, 163);
            this.EasyBox.TabIndex = 1;
            this.EasyBox.TabStop = false;
            this.EasyBox.Text = "Einfache Einstellungen ";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(5, 136);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(348, 13);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Vereinslogo: logo.bmp ins Verzeichnis des Programms kopieren. Status:";
            this.Label4.Visible = false;
            // 
            // LogoLabel
            // 
            this.LogoLabel.Location = new System.Drawing.Point(349, 136);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Size = new System.Drawing.Size(96, 13);
            this.LogoLabel.TabIndex = 3;
            this.LogoLabel.Text = "Kein Logo gefunden";
            this.LogoLabel.Visible = false;
            // 
            // ReloadLogoButton
            // 
            this.ReloadLogoButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ReloadLogoButton.Location = new System.Drawing.Point(456, 132);
            this.ReloadLogoButton.Name = "ReloadLogoButton";
            this.ReloadLogoButton.Size = new System.Drawing.Size(75, 20);
            this.ReloadLogoButton.TabIndex = 4;
            this.ReloadLogoButton.Text = "neu laden";
            this.ReloadLogoButton.UseVisualStyleBackColor = false;
            this.ReloadLogoButton.Visible = false;
            this.ReloadLogoButton.Click += new System.EventHandler(this.ReloadLogoButtonClick);
            // 
            // ExtendedBox
            // 
            this.ExtendedBox.Controls.Add(this.SwitchStepsSystemAt32Box);
            this.ExtendedBox.Controls.Add(this.SwitchJumpSlotOrderAt32Box);
            this.ExtendedBox.Location = new System.Drawing.Point(12, 181);
            this.ExtendedBox.Name = "ExtendedBox";
            this.ExtendedBox.Size = new System.Drawing.Size(537, 65);
            this.ExtendedBox.TabIndex = 2;
            this.ExtendedBox.TabStop = false;
            this.ExtendedBox.Text = "Erweiterte Einstellungen ";
            // 
            // DefaultsButton
            // 
            this.DefaultsButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DefaultsButton.Location = new System.Drawing.Point(364, 275);
            this.DefaultsButton.Name = "DefaultsButton";
            this.DefaultsButton.Size = new System.Drawing.Size(185, 25);
            this.DefaultsButton.TabIndex = 3;
            this.DefaultsButton.Text = "Standardwerte";
            this.DefaultsButton.UseVisualStyleBackColor = false;
            this.DefaultsButton.Click += new System.EventHandler(this.DefaultsButtonClick);
            // 
            // TSettingsForm
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(559, 311);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.EasyBox);
            this.Controls.Add(this.ExtendedBox);
            this.Controls.Add(this.DefaultsButton);
            this.Controls.Add(this.SaveToIniBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(1047, 330);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.FormCreate);
            this.Shown += new System.EventHandler(this.FormShow);
            this.ShortLoseRoundPanel.ResumeLayout(false);
            this.FightDurationPanel.ResumeLayout(false);
            this.FightDurationPanel.PerformLayout();
            this.EasyBox.ResumeLayout(false);
            this.ExtendedBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;

    }
}
