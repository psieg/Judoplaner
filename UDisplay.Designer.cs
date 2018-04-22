namespace UDisplay
{
  partial class TDisplayForm
    {
        public System.Windows.Forms.Label PlayerALabel;
        public System.Windows.Forms.Label PlayerBLabel;
        public System.Windows.Forms.GroupBox PlayerAShape;
        public System.Windows.Forms.GroupBox PlayerBShape;
        public System.Windows.Forms.Label TimeLabel;
        public System.Windows.Forms.Label PlayerA5Label;
        public System.Windows.Forms.Label PlayerB5Label;
        public System.Windows.Forms.Label PlayerB7Label;
        public System.Windows.Forms.Label PlayerB10Label;
        public System.Windows.Forms.Label PlayerA7Label;
        public System.Windows.Forms.Label PlayerA10Label;
        public System.Windows.Forms.Label PlayerAPunishLabel;
        public System.Windows.Forms.Label PlayerBPunishLabel;
        public System.Windows.Forms.Label HoldTimeLabel;
        public System.Windows.Forms.Label PlayerA5Caption;
        public System.Windows.Forms.Label PlayerB5Caption;
        public System.Windows.Forms.Label PlayerB7Caption;
        public System.Windows.Forms.Label PlayerB10Caption;
        public System.Windows.Forms.Label PlayerA7Caption;
        public System.Windows.Forms.Label PlayerA10Caption;
        public System.Windows.Forms.Label PlayerAPunishCaption;
        public System.Windows.Forms.Label PlayerBPunishCaption;
        public System.Windows.Forms.Label StatsLabel;
        public System.Windows.Forms.Label PrepareLabel;
        public System.Windows.Forms.Timer TimeTimer;
        public Judoplaner2.ProgressBar ProgressBar;
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
            this.PlayerAShape = new System.Windows.Forms.GroupBox();
            this.PlayerBShape = new System.Windows.Forms.GroupBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.PlayerA5Label = new System.Windows.Forms.Label();
            this.PlayerB5Label = new System.Windows.Forms.Label();
            this.PlayerB7Label = new System.Windows.Forms.Label();
            this.PlayerB10Label = new System.Windows.Forms.Label();
            this.PlayerA7Label = new System.Windows.Forms.Label();
            this.PlayerA10Label = new System.Windows.Forms.Label();
            this.PlayerAPunishLabel = new System.Windows.Forms.Label();
            this.PlayerBPunishLabel = new System.Windows.Forms.Label();
            this.HoldTimeLabel = new System.Windows.Forms.Label();
            this.PlayerA5Caption = new System.Windows.Forms.Label();
            this.PlayerB5Caption = new System.Windows.Forms.Label();
            this.PlayerB7Caption = new System.Windows.Forms.Label();
            this.PlayerB10Caption = new System.Windows.Forms.Label();
            this.PlayerA7Caption = new System.Windows.Forms.Label();
            this.PlayerA10Caption = new System.Windows.Forms.Label();
            this.PlayerAPunishCaption = new System.Windows.Forms.Label();
            this.PlayerBPunishCaption = new System.Windows.Forms.Label();
            this.StatsLabel = new System.Windows.Forms.Label();
            this.PrepareLabel = new System.Windows.Forms.Label();
            this.TimeTimer = new System.Windows.Forms.Timer(this.components);
            this.ProgressBar = new Judoplaner2.ProgressBar();
            this.SuspendLayout();
            // 
            // PlayerALabel
            // 
            this.PlayerALabel.Location = new System.Drawing.Point(0, 0);
            this.PlayerALabel.Name = "PlayerALabel";
            this.PlayerALabel.Size = new System.Drawing.Size(217, 13);
            this.PlayerALabel.TabIndex = 0;
            this.PlayerALabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerBLabel
            // 
            this.PlayerBLabel.Location = new System.Drawing.Point(296, 0);
            this.PlayerBLabel.Name = "PlayerBLabel";
            this.PlayerBLabel.Size = new System.Drawing.Size(217, 13);
            this.PlayerBLabel.TabIndex = 1;
            this.PlayerBLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerAShape
            // 
            this.PlayerAShape.Location = new System.Drawing.Point(0, 16);
            this.PlayerAShape.Name = "PlayerAShape";
            this.PlayerAShape.Size = new System.Drawing.Size(217, 217);
            this.PlayerAShape.TabIndex = 2;
            this.PlayerAShape.TabStop = false;
            // 
            // PlayerBShape
            // 
            this.PlayerBShape.Location = new System.Drawing.Point(296, 16);
            this.PlayerBShape.Name = "PlayerBShape";
            this.PlayerBShape.Size = new System.Drawing.Size(217, 217);
            this.PlayerBShape.TabIndex = 3;
            this.PlayerBShape.TabStop = false;
            // 
            // TimeLabel
            // 
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TimeLabel.Location = new System.Drawing.Point(224, 104);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(35, 24);
            this.TimeLabel.TabIndex = 4;
            this.TimeLabel.Text = "0:00";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerA5Label
            // 
            this.PlayerA5Label.Location = new System.Drawing.Point(112, 248);
            this.PlayerA5Label.Name = "PlayerA5Label";
            this.PlayerA5Label.Size = new System.Drawing.Size(6, 13);
            this.PlayerA5Label.TabIndex = 5;
            this.PlayerA5Label.Text = "0";
            this.PlayerA5Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerB5Label
            // 
            this.PlayerB5Label.Location = new System.Drawing.Point(408, 248);
            this.PlayerB5Label.Name = "PlayerB5Label";
            this.PlayerB5Label.Size = new System.Drawing.Size(6, 13);
            this.PlayerB5Label.TabIndex = 6;
            this.PlayerB5Label.Text = "0";
            this.PlayerB5Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerB7Label
            // 
            this.PlayerB7Label.Location = new System.Drawing.Point(352, 248);
            this.PlayerB7Label.Name = "PlayerB7Label";
            this.PlayerB7Label.Size = new System.Drawing.Size(6, 13);
            this.PlayerB7Label.TabIndex = 7;
            this.PlayerB7Label.Text = "0";
            this.PlayerB7Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerB10Label
            // 
            this.PlayerB10Label.Location = new System.Drawing.Point(296, 248);
            this.PlayerB10Label.Name = "PlayerB10Label";
            this.PlayerB10Label.Size = new System.Drawing.Size(6, 13);
            this.PlayerB10Label.TabIndex = 8;
            this.PlayerB10Label.Text = "0";
            this.PlayerB10Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerA7Label
            // 
            this.PlayerA7Label.Location = new System.Drawing.Point(56, 248);
            this.PlayerA7Label.Name = "PlayerA7Label";
            this.PlayerA7Label.Size = new System.Drawing.Size(6, 13);
            this.PlayerA7Label.TabIndex = 9;
            this.PlayerA7Label.Text = "0";
            this.PlayerA7Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerA10Label
            // 
            this.PlayerA10Label.Location = new System.Drawing.Point(0, 248);
            this.PlayerA10Label.Name = "PlayerA10Label";
            this.PlayerA10Label.Size = new System.Drawing.Size(6, 13);
            this.PlayerA10Label.TabIndex = 10;
            this.PlayerA10Label.Text = "0";
            this.PlayerA10Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerAPunishLabel
            // 
            this.PlayerAPunishLabel.Location = new System.Drawing.Point(168, 248);
            this.PlayerAPunishLabel.Name = "PlayerAPunishLabel";
            this.PlayerAPunishLabel.Size = new System.Drawing.Size(6, 13);
            this.PlayerAPunishLabel.TabIndex = 11;
            this.PlayerAPunishLabel.Text = "0";
            this.PlayerAPunishLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerBPunishLabel
            // 
            this.PlayerBPunishLabel.Location = new System.Drawing.Point(464, 248);
            this.PlayerBPunishLabel.Name = "PlayerBPunishLabel";
            this.PlayerBPunishLabel.Size = new System.Drawing.Size(6, 13);
            this.PlayerBPunishLabel.TabIndex = 12;
            this.PlayerBPunishLabel.Text = "0";
            this.PlayerBPunishLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HoldTimeLabel
            // 
            this.HoldTimeLabel.Location = new System.Drawing.Point(224, 160);
            this.HoldTimeLabel.Name = "HoldTimeLabel";
            this.HoldTimeLabel.Size = new System.Drawing.Size(3, 13);
            this.HoldTimeLabel.TabIndex = 13;
            this.HoldTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerA5Caption
            // 
            this.PlayerA5Caption.Location = new System.Drawing.Point(112, 264);
            this.PlayerA5Caption.Name = "PlayerA5Caption";
            this.PlayerA5Caption.Size = new System.Drawing.Size(25, 13);
            this.PlayerA5Caption.TabIndex = 14;
            this.PlayerA5Caption.Text = "Yuko";
            this.PlayerA5Caption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerB5Caption
            // 
            this.PlayerB5Caption.Location = new System.Drawing.Point(408, 264);
            this.PlayerB5Caption.Name = "PlayerB5Caption";
            this.PlayerB5Caption.Size = new System.Drawing.Size(25, 13);
            this.PlayerB5Caption.TabIndex = 15;
            this.PlayerB5Caption.Text = "Yuko";
            this.PlayerB5Caption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerB7Caption
            // 
            this.PlayerB7Caption.Location = new System.Drawing.Point(352, 264);
            this.PlayerB7Caption.Name = "PlayerB7Caption";
            this.PlayerB7Caption.Size = new System.Drawing.Size(43, 13);
            this.PlayerB7Caption.TabIndex = 16;
            this.PlayerB7Caption.Text = "Waza-Ari";
            this.PlayerB7Caption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerB10Caption
            // 
            this.PlayerB10Caption.Location = new System.Drawing.Point(296, 264);
            this.PlayerB10Caption.Name = "PlayerB10Caption";
            this.PlayerB10Caption.Size = new System.Drawing.Size(27, 13);
            this.PlayerB10Caption.TabIndex = 17;
            this.PlayerB10Caption.Text = "Ippon";
            this.PlayerB10Caption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerA7Caption
            // 
            this.PlayerA7Caption.Location = new System.Drawing.Point(56, 264);
            this.PlayerA7Caption.Name = "PlayerA7Caption";
            this.PlayerA7Caption.Size = new System.Drawing.Size(43, 13);
            this.PlayerA7Caption.TabIndex = 18;
            this.PlayerA7Caption.Text = "Waza-Ari";
            this.PlayerA7Caption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerA10Caption
            // 
            this.PlayerA10Caption.Location = new System.Drawing.Point(0, 264);
            this.PlayerA10Caption.Name = "PlayerA10Caption";
            this.PlayerA10Caption.Size = new System.Drawing.Size(27, 13);
            this.PlayerA10Caption.TabIndex = 19;
            this.PlayerA10Caption.Text = "Ippon";
            this.PlayerA10Caption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerAPunishCaption
            // 
            this.PlayerAPunishCaption.Location = new System.Drawing.Point(168, 264);
            this.PlayerAPunishCaption.Name = "PlayerAPunishCaption";
            this.PlayerAPunishCaption.Size = new System.Drawing.Size(27, 13);
            this.PlayerAPunishCaption.TabIndex = 20;
            this.PlayerAPunishCaption.Text = "Shido";
            this.PlayerAPunishCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerBPunishCaption
            // 
            this.PlayerBPunishCaption.Location = new System.Drawing.Point(464, 264);
            this.PlayerBPunishCaption.Name = "PlayerBPunishCaption";
            this.PlayerBPunishCaption.Size = new System.Drawing.Size(27, 13);
            this.PlayerBPunishCaption.TabIndex = 21;
            this.PlayerBPunishCaption.Text = "Shido";
            this.PlayerBPunishCaption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // StatsLabel
            // 
            this.StatsLabel.Location = new System.Drawing.Point(370, 284);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(137, 13);
            this.StatsLabel.TabIndex = 22;
            this.StatsLabel.Text = "-/-";
            this.StatsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PrepareLabel
            // 
            this.PrepareLabel.Location = new System.Drawing.Point(5, 284);
            this.PrepareLabel.Name = "PrepareLabel";
            this.PrepareLabel.Size = new System.Drawing.Size(244, 13);
            this.PrepareLabel.TabIndex = 23;
            this.PrepareLabel.Text = "Vorbereitung: -";
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.ProgressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressBar.Location = new System.Drawing.Point(232, 284);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(234, 10);
            this.ProgressBar.TabIndex = 24;
            this.ProgressBar.Value = 0;
            // 
            // TDisplayForm
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(513, 297);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.PlayerALabel);
            this.Controls.Add(this.PlayerBLabel);
            this.Controls.Add(this.PlayerAShape);
            this.Controls.Add(this.PlayerBShape);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.PlayerA5Label);
            this.Controls.Add(this.PlayerB5Label);
            this.Controls.Add(this.PlayerB7Label);
            this.Controls.Add(this.PlayerB10Label);
            this.Controls.Add(this.PlayerA7Label);
            this.Controls.Add(this.PlayerA10Label);
            this.Controls.Add(this.PlayerAPunishLabel);
            this.Controls.Add(this.PlayerBPunishLabel);
            this.Controls.Add(this.HoldTimeLabel);
            this.Controls.Add(this.PlayerA5Caption);
            this.Controls.Add(this.PlayerB5Caption);
            this.Controls.Add(this.PlayerB7Caption);
            this.Controls.Add(this.PlayerB10Caption);
            this.Controls.Add(this.PlayerA7Caption);
            this.Controls.Add(this.PlayerA10Caption);
            this.Controls.Add(this.PlayerAPunishCaption);
            this.Controls.Add(this.PlayerBPunishCaption);
            this.Controls.Add(this.StatsLabel);
            this.Controls.Add(this.PrepareLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(145, 95);
            this.Name = "TDisplayForm";
            this.Text = "DisplayForm";
            this.Resize += new System.EventHandler(this.FormResize);
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;

    }
}
