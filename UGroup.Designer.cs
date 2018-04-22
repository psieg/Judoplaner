namespace UGroup
{
  partial class TGroupForm
    {
      public System.Windows.Forms.Label StatsLabel;
        public System.Windows.Forms.Label PrepareLabel;
        public System.Windows.Forms.Button NextStepButton;
        public System.Windows.Forms.Panel ScrollBox;
        public System.Windows.Forms.PictureBox PrintImage;
        public System.Windows.Forms.Button SettingsButton;
        public System.Windows.Forms.GroupBox PlayersBox;
        public System.Windows.Forms.Button AddPlayerButton;
        public System.Windows.Forms.TextBox PrenameEdit;
        public System.Windows.Forms.TextBox LastnameEdit;
        public System.Windows.Forms.Button DelPlayerButton;
        public System.Windows.Forms.TextBox ClubEdit;
        public System.Windows.Forms.ListBox PlayerBox;
        public System.Windows.Forms.TextBox Edit1;
        public System.Windows.Forms.Button Button1;
        public System.Windows.Forms.Button PrintGameButton;
        public System.Windows.Forms.Button PrintResultButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TGroupForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.StatsLabel = new System.Windows.Forms.Label();
            this.PrepareLabel = new System.Windows.Forms.Label();
            this.NextStepButton = new System.Windows.Forms.Button();
            this.ScrollBox = new System.Windows.Forms.Panel();
            this.PrintImage = new System.Windows.Forms.PictureBox();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.PlayersBox = new System.Windows.Forms.GroupBox();
            this.AddPlayerButton = new System.Windows.Forms.Button();
            this.PrenameEdit = new System.Windows.Forms.TextBox();
            this.LastnameEdit = new System.Windows.Forms.TextBox();
            this.DelPlayerButton = new System.Windows.Forms.Button();
            this.ClubEdit = new System.Windows.Forms.TextBox();
            this.PlayerBox = new System.Windows.Forms.ListBox();
            this.Edit1 = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.PrintGameButton = new System.Windows.Forms.Button();
            this.PrintResultButton = new System.Windows.Forms.Button();
            this.ProgressBar = new Judoplaner2.ProgressBar();
            this.ScrollBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintImage)).BeginInit();
            this.PlayersBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatsLabel
            // 
            this.StatsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StatsLabel.Location = new System.Drawing.Point(642, 541);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(137, 13);
            this.StatsLabel.TabIndex = 0;
            this.StatsLabel.Text = "-/-";
            this.StatsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PrepareLabel
            // 
            this.PrepareLabel.Location = new System.Drawing.Point(5, 540);
            this.PrepareLabel.Name = "PrepareLabel";
            this.PrepareLabel.Size = new System.Drawing.Size(280, 13);
            this.PrepareLabel.TabIndex = 1;
            this.PrepareLabel.Text = "Vorbereitung: -";
            // 
            // NextStepButton
            // 
            this.NextStepButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NextStepButton.Location = new System.Drawing.Point(5, 5);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(145, 25);
            this.NextStepButton.TabIndex = 1;
            this.NextStepButton.Text = "Start";
            this.NextStepButton.UseVisualStyleBackColor = false;
            this.NextStepButton.Click += new System.EventHandler(this.NextStepButtonClick);
            // 
            // ScrollBox
            // 
            this.ScrollBox.AutoScroll = true;
            this.ScrollBox.Controls.Add(this.PrintImage);
            this.ScrollBox.Location = new System.Drawing.Point(5, 35);
            this.ScrollBox.Name = "ScrollBox";
            this.ScrollBox.Size = new System.Drawing.Size(775, 500);
            this.ScrollBox.TabIndex = 2;
            // 
            // PrintImage
            // 
            this.PrintImage.Location = new System.Drawing.Point(0, 0);
            this.PrintImage.Name = "PrintImage";
            this.PrintImage.Size = new System.Drawing.Size(753, 345);
            this.PrintImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PrintImage.TabIndex = 0;
            this.PrintImage.TabStop = false;
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SettingsButton.Location = new System.Drawing.Point(634, 5);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(145, 25);
            this.SettingsButton.TabIndex = 3;
            this.SettingsButton.Text = "Einstellungen";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButtonClick);
            // 
            // PlayersBox
            // 
            this.PlayersBox.Controls.Add(this.AddPlayerButton);
            this.PlayersBox.Controls.Add(this.PrenameEdit);
            this.PlayersBox.Controls.Add(this.LastnameEdit);
            this.PlayersBox.Controls.Add(this.DelPlayerButton);
            this.PlayersBox.Controls.Add(this.ClubEdit);
            this.PlayersBox.Controls.Add(this.PlayerBox);
            this.PlayersBox.Controls.Add(this.Edit1);
            this.PlayersBox.Controls.Add(this.Button1);
            this.PlayersBox.Location = new System.Drawing.Point(5, 30);
            this.PlayersBox.Name = "PlayersBox";
            this.PlayersBox.Size = new System.Drawing.Size(775, 505);
            this.PlayersBox.TabIndex = 0;
            this.PlayersBox.TabStop = false;
            // 
            // AddPlayerButton
            // 
            this.AddPlayerButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AddPlayerButton.Location = new System.Drawing.Point(328, 112);
            this.AddPlayerButton.Name = "AddPlayerButton";
            this.AddPlayerButton.Size = new System.Drawing.Size(145, 25);
            this.AddPlayerButton.TabIndex = 3;
            this.AddPlayerButton.Text = "Kämpfer hinzufügen";
            this.AddPlayerButton.UseVisualStyleBackColor = false;
            this.AddPlayerButton.Click += new System.EventHandler(this.AddPlayerButtonClick);
            // 
            // PrenameEdit
            // 
            this.PrenameEdit.Location = new System.Drawing.Point(328, 16);
            this.PrenameEdit.Name = "PrenameEdit";
            this.PrenameEdit.Size = new System.Drawing.Size(145, 20);
            this.PrenameEdit.TabIndex = 0;
            this.PrenameEdit.Text = "Vorname";
            this.PrenameEdit.Enter += new System.EventHandler(this.PrenameEditEnter);
            // 
            // LastnameEdit
            // 
            this.LastnameEdit.Location = new System.Drawing.Point(328, 48);
            this.LastnameEdit.Name = "LastnameEdit";
            this.LastnameEdit.Size = new System.Drawing.Size(145, 20);
            this.LastnameEdit.TabIndex = 1;
            this.LastnameEdit.Text = "Nachname";
            this.LastnameEdit.Enter += new System.EventHandler(this.LastnameEditEnter);
            // 
            // DelPlayerButton
            // 
            this.DelPlayerButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DelPlayerButton.Location = new System.Drawing.Point(328, 144);
            this.DelPlayerButton.Name = "DelPlayerButton";
            this.DelPlayerButton.Size = new System.Drawing.Size(145, 25);
            this.DelPlayerButton.TabIndex = 5;
            this.DelPlayerButton.Text = "Kämpfer löschen";
            this.DelPlayerButton.UseVisualStyleBackColor = false;
            this.DelPlayerButton.Click += new System.EventHandler(this.DelPlayerButtonClick);
            // 
            // ClubEdit
            // 
            this.ClubEdit.Location = new System.Drawing.Point(328, 80);
            this.ClubEdit.Name = "ClubEdit";
            this.ClubEdit.Size = new System.Drawing.Size(145, 20);
            this.ClubEdit.TabIndex = 2;
            this.ClubEdit.Text = "Verein";
            this.ClubEdit.Enter += new System.EventHandler(this.ClubEditEnter);
            // 
            // PlayerBox
            // 
            this.PlayerBox.Location = new System.Drawing.Point(9, 16);
            this.PlayerBox.Name = "PlayerBox";
            this.PlayerBox.Size = new System.Drawing.Size(313, 459);
            this.PlayerBox.TabIndex = 4;
            // 
            // Edit1
            // 
            this.Edit1.Location = new System.Drawing.Point(344, 176);
            this.Edit1.Name = "Edit1";
            this.Edit1.Size = new System.Drawing.Size(33, 20);
            this.Edit1.TabIndex = 6;
            this.Edit1.Text = "16";
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Button1.Location = new System.Drawing.Point(384, 176);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(89, 25);
            this.Button1.TabIndex = 7;
            this.Button1.Text = "CreatePlayers";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // PrintGameButton
            // 
            this.PrintGameButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PrintGameButton.Location = new System.Drawing.Point(464, 5);
            this.PrintGameButton.Name = "PrintGameButton";
            this.PrintGameButton.Size = new System.Drawing.Size(161, 25);
            this.PrintGameButton.TabIndex = 4;
            this.PrintGameButton.Text = "Zwischenstand drucken";
            this.PrintGameButton.UseVisualStyleBackColor = false;
            this.PrintGameButton.Visible = false;
            this.PrintGameButton.Click += new System.EventHandler(this.PrintGameButtonClick);
            // 
            // PrintResultButton
            // 
            this.PrintResultButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PrintResultButton.Location = new System.Drawing.Point(464, 5);
            this.PrintResultButton.Name = "PrintResultButton";
            this.PrintResultButton.Size = new System.Drawing.Size(161, 25);
            this.PrintResultButton.TabIndex = 5;
            this.PrintResultButton.Text = "Plan und Ergebnis drucken";
            this.PrintResultButton.UseVisualStyleBackColor = false;
            this.PrintResultButton.Visible = false;
            this.PrintResultButton.Click += new System.EventHandler(this.PrintResultButtonClick);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.ProgressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressBar.Location = new System.Drawing.Point(302, 544);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(382, 10);
            this.ProgressBar.TabIndex = 6;
            this.ProgressBar.Value = 0;
            // 
            // TGroupForm
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.StatsLabel);
            this.Controls.Add(this.PrepareLabel);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.PlayersBox);
            this.Controls.Add(this.PrintGameButton);
            this.Controls.Add(this.PrintResultButton);
            this.Controls.Add(this.ScrollBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(256, 297);
            this.Name = "TGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Judoplaner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCloseQuery);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.FormCreate);
            this.Shown += new System.EventHandler(this.FormShow);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FormMouseWheel);
            this.Resize += new System.EventHandler(this.FormResize);
            this.ScrollBox.ResumeLayout(false);
            this.ScrollBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintImage)).EndInit();
            this.PlayersBox.ResumeLayout(false);
            this.PlayersBox.PerformLayout();
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;
        private Judoplaner2.ProgressBar ProgressBar;

    }
}
