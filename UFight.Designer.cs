namespace UFight
{
  partial class TFightForm
    {
        public System.Windows.Forms.Label PlayerALabel;
        public System.Windows.Forms.Label PlayerBLabel;
        public System.Windows.Forms.Label TimeLabel;
        public System.Windows.Forms.Label PlayerB7Label;
        public System.Windows.Forms.Label PlayerB10Label;
        public System.Windows.Forms.Label PlayerA7Label;
        public System.Windows.Forms.Label PlayerA10Label;
        public System.Windows.Forms.Label PlayerAPunishLabel;
        public System.Windows.Forms.Label PlayerBPunishLabel;
        public System.Windows.Forms.Label HoldTimeLabel;
        public System.Windows.Forms.Button PlayerB10Button;
        public System.Windows.Forms.Button PauseButton;
        public System.Windows.Forms.Button PlayerA7Button;
        public System.Windows.Forms.Button PlayerB7Button;
        public System.Windows.Forms.Button PlayerAPunishButton;
        public System.Windows.Forms.Button PlayerBPunishButton;
        public System.Windows.Forms.Button PlayerA10Button;
        public System.Windows.Forms.Button PlayerBHoldButton;
        public System.Windows.Forms.Button PlayerAHoldButton;
        public System.Windows.Forms.Button GoButton;
        public System.Windows.Forms.Button UndoButton;
        public System.Windows.Forms.Timer TimeTimer;
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
            this.PlayerALabel = new System.Windows.Forms.Label();
            this.PlayerBLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.PlayerB7Label = new System.Windows.Forms.Label();
            this.PlayerB10Label = new System.Windows.Forms.Label();
            this.PlayerA7Label = new System.Windows.Forms.Label();
            this.PlayerA10Label = new System.Windows.Forms.Label();
            this.PlayerAPunishLabel = new System.Windows.Forms.Label();
            this.PlayerBPunishLabel = new System.Windows.Forms.Label();
            this.HoldTimeLabel = new System.Windows.Forms.Label();
            this.PlayerB10Button = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.PlayerA7Button = new System.Windows.Forms.Button();
            this.PlayerB7Button = new System.Windows.Forms.Button();
            this.PlayerAPunishButton = new System.Windows.Forms.Button();
            this.PlayerBPunishButton = new System.Windows.Forms.Button();
            this.PlayerA10Button = new System.Windows.Forms.Button();
            this.PlayerBHoldButton = new System.Windows.Forms.Button();
            this.PlayerAHoldButton = new System.Windows.Forms.Button();
            this.GoButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.TimeTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayerAShape = new System.Windows.Forms.Label();
            this.PlayerBShape = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayerALabel
            // 
            this.PlayerALabel.Location = new System.Drawing.Point(8, 8);
            this.PlayerALabel.Name = "PlayerALabel";
            this.PlayerALabel.Size = new System.Drawing.Size(217, 13);
            this.PlayerALabel.TabIndex = 0;
            this.PlayerALabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerBLabel
            // 
            this.PlayerBLabel.Location = new System.Drawing.Point(351, 8);
            this.PlayerBLabel.Name = "PlayerBLabel";
            this.PlayerBLabel.Size = new System.Drawing.Size(217, 13);
            this.PlayerBLabel.TabIndex = 1;
            this.PlayerBLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TimeLabel
            // 
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TimeLabel.Location = new System.Drawing.Point(232, 112);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(113, 25);
            this.TimeLabel.TabIndex = 4;
            this.TimeLabel.Text = "0:00";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerB7Label
            // 
            this.PlayerB7Label.Location = new System.Drawing.Point(438, 256);
            this.PlayerB7Label.Name = "PlayerB7Label";
            this.PlayerB7Label.Size = new System.Drawing.Size(49, 13);
            this.PlayerB7Label.TabIndex = 7;
            this.PlayerB7Label.Text = "0";
            this.PlayerB7Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerB10Label
            // 
            this.PlayerB10Label.Location = new System.Drawing.Point(357, 256);
            this.PlayerB10Label.Name = "PlayerB10Label";
            this.PlayerB10Label.Size = new System.Drawing.Size(49, 13);
            this.PlayerB10Label.TabIndex = 8;
            this.PlayerB10Label.Text = "0";
            this.PlayerB10Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerA7Label
            // 
            this.PlayerA7Label.Location = new System.Drawing.Point(115, 256);
            this.PlayerA7Label.Name = "PlayerA7Label";
            this.PlayerA7Label.Size = new System.Drawing.Size(49, 13);
            this.PlayerA7Label.TabIndex = 9;
            this.PlayerA7Label.Text = "0";
            this.PlayerA7Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerA10Label
            // 
            this.PlayerA10Label.Location = new System.Drawing.Point(34, 256);
            this.PlayerA10Label.Name = "PlayerA10Label";
            this.PlayerA10Label.Size = new System.Drawing.Size(49, 13);
            this.PlayerA10Label.TabIndex = 10;
            this.PlayerA10Label.Text = "0";
            this.PlayerA10Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerAPunishLabel
            // 
            this.PlayerAPunishLabel.Location = new System.Drawing.Point(196, 256);
            this.PlayerAPunishLabel.Name = "PlayerAPunishLabel";
            this.PlayerAPunishLabel.Size = new System.Drawing.Size(49, 13);
            this.PlayerAPunishLabel.TabIndex = 11;
            this.PlayerAPunishLabel.Text = "0";
            this.PlayerAPunishLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerBPunishLabel
            // 
            this.PlayerBPunishLabel.Location = new System.Drawing.Point(520, 256);
            this.PlayerBPunishLabel.Name = "PlayerBPunishLabel";
            this.PlayerBPunishLabel.Size = new System.Drawing.Size(48, 13);
            this.PlayerBPunishLabel.TabIndex = 12;
            this.PlayerBPunishLabel.Text = "0";
            this.PlayerBPunishLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HoldTimeLabel
            // 
            this.HoldTimeLabel.Location = new System.Drawing.Point(232, 168);
            this.HoldTimeLabel.Name = "HoldTimeLabel";
            this.HoldTimeLabel.Size = new System.Drawing.Size(113, 13);
            this.HoldTimeLabel.TabIndex = 13;
            this.HoldTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerB10Button
            // 
            this.PlayerB10Button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayerB10Button.Location = new System.Drawing.Point(331, 272);
            this.PlayerB10Button.Name = "PlayerB10Button";
            this.PlayerB10Button.Size = new System.Drawing.Size(75, 23);
            this.PlayerB10Button.TabIndex = 6;
            this.PlayerB10Button.Text = "Ippon";
            this.PlayerB10Button.UseVisualStyleBackColor = false;
            this.PlayerB10Button.Click += new System.EventHandler(this.PlayerB10ButtonClick);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PauseButton.Location = new System.Drawing.Point(251, 262);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(74, 33);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.Text = "Mat(t)e";
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Visible = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButtonClick);
            // 
            // PlayerA7Button
            // 
            this.PlayerA7Button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayerA7Button.Location = new System.Drawing.Point(89, 272);
            this.PlayerA7Button.Name = "PlayerA7Button";
            this.PlayerA7Button.Size = new System.Drawing.Size(75, 23);
            this.PlayerA7Button.TabIndex = 3;
            this.PlayerA7Button.Text = "Waza-ari";
            this.PlayerA7Button.UseVisualStyleBackColor = false;
            this.PlayerA7Button.Click += new System.EventHandler(this.PlayerA7ButtonClick);
            // 
            // PlayerB7Button
            // 
            this.PlayerB7Button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayerB7Button.Location = new System.Drawing.Point(412, 272);
            this.PlayerB7Button.Name = "PlayerB7Button";
            this.PlayerB7Button.Size = new System.Drawing.Size(75, 23);
            this.PlayerB7Button.TabIndex = 7;
            this.PlayerB7Button.Text = "Waza-ari";
            this.PlayerB7Button.UseVisualStyleBackColor = false;
            this.PlayerB7Button.Click += new System.EventHandler(this.PlayerB7ButtonClick);
            // 
            // PlayerAPunishButton
            // 
            this.PlayerAPunishButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayerAPunishButton.Location = new System.Drawing.Point(170, 272);
            this.PlayerAPunishButton.Name = "PlayerAPunishButton";
            this.PlayerAPunishButton.Size = new System.Drawing.Size(75, 23);
            this.PlayerAPunishButton.TabIndex = 5;
            this.PlayerAPunishButton.Text = "Shido";
            this.PlayerAPunishButton.UseVisualStyleBackColor = false;
            this.PlayerAPunishButton.Click += new System.EventHandler(this.PlayerAPunishButtonClick);
            // 
            // PlayerBPunishButton
            // 
            this.PlayerBPunishButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayerBPunishButton.Location = new System.Drawing.Point(493, 272);
            this.PlayerBPunishButton.Name = "PlayerBPunishButton";
            this.PlayerBPunishButton.Size = new System.Drawing.Size(75, 23);
            this.PlayerBPunishButton.TabIndex = 9;
            this.PlayerBPunishButton.Text = "Shido";
            this.PlayerBPunishButton.UseVisualStyleBackColor = false;
            this.PlayerBPunishButton.Click += new System.EventHandler(this.PlayerBPunishButtonClick);
            // 
            // PlayerA10Button
            // 
            this.PlayerA10Button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayerA10Button.Location = new System.Drawing.Point(8, 272);
            this.PlayerA10Button.Name = "PlayerA10Button";
            this.PlayerA10Button.Size = new System.Drawing.Size(75, 23);
            this.PlayerA10Button.TabIndex = 2;
            this.PlayerA10Button.Text = "Ippon";
            this.PlayerA10Button.UseVisualStyleBackColor = false;
            this.PlayerA10Button.Click += new System.EventHandler(this.PlayerA10ButtonClick);
            // 
            // PlayerBHoldButton
            // 
            this.PlayerBHoldButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayerBHoldButton.Location = new System.Drawing.Point(331, 301);
            this.PlayerBHoldButton.Name = "PlayerBHoldButton";
            this.PlayerBHoldButton.Size = new System.Drawing.Size(237, 23);
            this.PlayerBHoldButton.TabIndex = 11;
            this.PlayerBHoldButton.Text = "Osae-komi";
            this.PlayerBHoldButton.UseVisualStyleBackColor = false;
            this.PlayerBHoldButton.Click += new System.EventHandler(this.PlayerBHoldButtonClick);
            // 
            // PlayerAHoldButton
            // 
            this.PlayerAHoldButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayerAHoldButton.Location = new System.Drawing.Point(8, 301);
            this.PlayerAHoldButton.Name = "PlayerAHoldButton";
            this.PlayerAHoldButton.Size = new System.Drawing.Size(237, 23);
            this.PlayerAHoldButton.TabIndex = 10;
            this.PlayerAHoldButton.Text = "Osae-komi";
            this.PlayerAHoldButton.UseVisualStyleBackColor = false;
            this.PlayerAHoldButton.Click += new System.EventHandler(this.PlayerAHoldButtonClick);
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GoButton.Location = new System.Drawing.Point(251, 262);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(74, 33);
            this.GoButton.TabIndex = 0;
            this.GoButton.Text = "Hajime";
            this.GoButton.UseVisualStyleBackColor = false;
            this.GoButton.Click += new System.EventHandler(this.GoButtonClick);
            // 
            // UndoButton
            // 
            this.UndoButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.UndoButton.Location = new System.Drawing.Point(251, 301);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(74, 23);
            this.UndoButton.TabIndex = 12;
            this.UndoButton.Text = "rückgängig";
            this.UndoButton.UseVisualStyleBackColor = false;
            this.UndoButton.Click += new System.EventHandler(this.UndoButtonClick);
            // 
            // TimeTimer
            // 
            this.TimeTimer.Interval = 1000;
            this.TimeTimer.Tick += new System.EventHandler(this.TimeTimerTimer);
            // 
            // PlayerAShape
            // 
            this.PlayerAShape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerAShape.Location = new System.Drawing.Point(8, 24);
            this.PlayerAShape.Name = "PlayerAShape";
            this.PlayerAShape.Size = new System.Drawing.Size(217, 217);
            this.PlayerAShape.TabIndex = 2;
            // 
            // PlayerBShape
            // 
            this.PlayerBShape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerBShape.Location = new System.Drawing.Point(351, 24);
            this.PlayerBShape.Name = "PlayerBShape";
            this.PlayerBShape.Size = new System.Drawing.Size(217, 217);
            this.PlayerBShape.TabIndex = 3;
            // 
            // TFightForm
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(575, 329);
            this.ControlBox = false;
            this.Controls.Add(this.PlayerALabel);
            this.Controls.Add(this.PlayerBLabel);
            this.Controls.Add(this.PlayerAShape);
            this.Controls.Add(this.PlayerBShape);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.PlayerB7Label);
            this.Controls.Add(this.PlayerB10Label);
            this.Controls.Add(this.PlayerA7Label);
            this.Controls.Add(this.PlayerA10Label);
            this.Controls.Add(this.PlayerAPunishLabel);
            this.Controls.Add(this.PlayerBPunishLabel);
            this.Controls.Add(this.HoldTimeLabel);
            this.Controls.Add(this.PlayerB10Button);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayerA7Button);
            this.Controls.Add(this.PlayerB7Button);
            this.Controls.Add(this.PlayerAPunishButton);
            this.Controls.Add(this.PlayerBPunishButton);
            this.Controls.Add(this.PlayerA10Button);
            this.Controls.Add(this.PlayerBHoldButton);
            this.Controls.Add(this.PlayerAHoldButton);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.UndoButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(408, 402);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFightForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FightForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormCloseQuery);
            this.Load += new System.EventHandler(this.FormCreate);
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.Label PlayerAShape;
        public System.Windows.Forms.Label PlayerBShape;

    }
}
