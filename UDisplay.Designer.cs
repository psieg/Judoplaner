namespace UDisplay
{
  partial class TDisplayForm
  {
      public System.Windows.Forms.Label PlayerBLabel;
        public System.Windows.Forms.Label TimeLabel;
        public System.Windows.Forms.Label PlayerB7Label;
        public System.Windows.Forms.Label PlayerB10Label;
        public System.Windows.Forms.Label PlayerBPunishLabel;
        public System.Windows.Forms.Label HoldTimeLabel;
        public System.Windows.Forms.Label PlayerB7Caption;
        public System.Windows.Forms.Label PlayerB10Caption;
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
            this.PlayerBLabel = new System.Windows.Forms.Label();
            this.PlayerB10Caption = new System.Windows.Forms.Label();
            this.PlayerBPunishCaption = new System.Windows.Forms.Label();
            this.PlayerB7Caption = new System.Windows.Forms.Label();
            this.PlayerBPunishLabel = new System.Windows.Forms.Label();
            this.PlayerB7Label = new System.Windows.Forms.Label();
            this.PlayerB10Label = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.HoldTimeLabel = new System.Windows.Forms.Label();
            this.StatsLabel = new System.Windows.Forms.Label();
            this.PrepareLabel = new System.Windows.Forms.Label();
            this.TimeTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayerA7Label = new System.Windows.Forms.Label();
            this.PlayerA10Label = new System.Windows.Forms.Label();
            this.PlayerAPunishLabel = new System.Windows.Forms.Label();
            this.PlayerA10Caption = new System.Windows.Forms.Label();
            this.PlayerAPunishCaption = new System.Windows.Forms.Label();
            this.PlayerALabel = new System.Windows.Forms.Label();
            this.PlayerA7Caption = new System.Windows.Forms.Label();
            this.PlayerAShape = new System.Windows.Forms.TableLayoutPanel();
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerBShape = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BottomBarLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProgressBar = new Judoplaner2.ProgressBar();
            this.PlayerAShape.SuspendLayout();
            this.MainLayoutPanel.SuspendLayout();
            this.PlayerBShape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BottomBarLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerBLabel
            // 
            this.PlayerBLabel.AutoSize = true;
            this.PlayerBShape.SetColumnSpan(this.PlayerBLabel, 2);
            this.PlayerBLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerBLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerBLabel.Location = new System.Drawing.Point(24, 0);
            this.PlayerBLabel.Name = "PlayerBLabel";
            this.PlayerBLabel.Size = new System.Drawing.Size(167, 67);
            this.PlayerBLabel.TabIndex = 1;
            this.PlayerBLabel.Text = "Nachname, Vorname";
            this.PlayerBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlayerB10Caption
            // 
            this.PlayerB10Caption.BackColor = System.Drawing.Color.White;
            this.PlayerB10Caption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerB10Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerB10Caption.Location = new System.Drawing.Point(24, 234);
            this.PlayerB10Caption.Name = "PlayerB10Caption";
            this.PlayerB10Caption.Size = new System.Drawing.Size(124, 33);
            this.PlayerB10Caption.TabIndex = 17;
            this.PlayerB10Caption.Text = "Ippon";
            this.PlayerB10Caption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlayerBPunishCaption
            // 
            this.PlayerBPunishCaption.AutoSize = true;
            this.PlayerBPunishCaption.BackColor = System.Drawing.Color.White;
            this.PlayerBPunishCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerBPunishCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerBPunishCaption.Location = new System.Drawing.Point(24, 134);
            this.PlayerBPunishCaption.Name = "PlayerBPunishCaption";
            this.PlayerBPunishCaption.Size = new System.Drawing.Size(124, 33);
            this.PlayerBPunishCaption.TabIndex = 21;
            this.PlayerBPunishCaption.Text = "Shido";
            this.PlayerBPunishCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlayerB7Caption
            // 
            this.PlayerB7Caption.BackColor = System.Drawing.Color.White;
            this.PlayerB7Caption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerB7Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerB7Caption.Location = new System.Drawing.Point(24, 267);
            this.PlayerB7Caption.Name = "PlayerB7Caption";
            this.PlayerB7Caption.Size = new System.Drawing.Size(124, 33);
            this.PlayerB7Caption.TabIndex = 16;
            this.PlayerB7Caption.Text = "Waza-Ari";
            this.PlayerB7Caption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlayerBPunishLabel
            // 
            this.PlayerBPunishLabel.AutoSize = true;
            this.PlayerBPunishLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerBPunishLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerBPunishLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerBPunishLabel.ForeColor = System.Drawing.Color.Red;
            this.PlayerBPunishLabel.Location = new System.Drawing.Point(154, 134);
            this.PlayerBPunishLabel.Name = "PlayerBPunishLabel";
            this.PlayerBPunishLabel.Size = new System.Drawing.Size(37, 33);
            this.PlayerBPunishLabel.TabIndex = 12;
            this.PlayerBPunishLabel.Text = "0";
            this.PlayerBPunishLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerB7Label
            // 
            this.PlayerB7Label.AutoSize = true;
            this.PlayerB7Label.BackColor = System.Drawing.Color.White;
            this.PlayerB7Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerB7Label.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerB7Label.Location = new System.Drawing.Point(154, 267);
            this.PlayerB7Label.Name = "PlayerB7Label";
            this.PlayerB7Label.Size = new System.Drawing.Size(37, 33);
            this.PlayerB7Label.TabIndex = 7;
            this.PlayerB7Label.Text = "0";
            this.PlayerB7Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerB10Label
            // 
            this.PlayerB10Label.AutoSize = true;
            this.PlayerB10Label.BackColor = System.Drawing.Color.White;
            this.PlayerB10Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerB10Label.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerB10Label.Location = new System.Drawing.Point(154, 234);
            this.PlayerB10Label.Name = "PlayerB10Label";
            this.PlayerB10Label.Size = new System.Drawing.Size(37, 33);
            this.PlayerB10Label.TabIndex = 8;
            this.PlayerB10Label.Text = "0";
            this.PlayerB10Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeLabel
            // 
            this.MainLayoutPanel.SetColumnSpan(this.TimeLabel, 4);
            this.TimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeLabel.Font = new System.Drawing.Font("Digital-7 Mono", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.ForeColor = System.Drawing.Color.Red;
            this.TimeLabel.Location = new System.Drawing.Point(217, 56);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(162, 85);
            this.TimeLabel.TabIndex = 4;
            this.TimeLabel.Text = "0:00";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HoldTimeLabel
            // 
            this.HoldTimeLabel.AutoSize = true;
            this.HoldTimeLabel.BackColor = System.Drawing.Color.Yellow;
            this.MainLayoutPanel.SetColumnSpan(this.HoldTimeLabel, 2);
            this.HoldTimeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HoldTimeLabel.Font = new System.Drawing.Font("Digital-7 Mono", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoldTimeLabel.Location = new System.Drawing.Point(259, 141);
            this.HoldTimeLabel.Name = "HoldTimeLabel";
            this.HoldTimeLabel.Size = new System.Drawing.Size(78, 38);
            this.HoldTimeLabel.TabIndex = 13;
            this.HoldTimeLabel.Text = "00";
            this.HoldTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatsLabel
            // 
            this.StatsLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StatsLabel.AutoSize = true;
            this.StatsLabel.ForeColor = System.Drawing.Color.White;
            this.StatsLabel.Location = new System.Drawing.Point(579, 0);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(18, 13);
            this.StatsLabel.TabIndex = 22;
            this.StatsLabel.Text = "-/-";
            this.StatsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PrepareLabel
            // 
            this.PrepareLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PrepareLabel.AutoSize = true;
            this.PrepareLabel.ForeColor = System.Drawing.Color.White;
            this.PrepareLabel.Location = new System.Drawing.Point(3, 0);
            this.PrepareLabel.Name = "PrepareLabel";
            this.PrepareLabel.Size = new System.Drawing.Size(76, 13);
            this.PrepareLabel.TabIndex = 23;
            this.PrepareLabel.Text = "Vorbereitung: -";
            // 
            // PlayerA7Label
            // 
            this.PlayerA7Label.AutoSize = true;
            this.PlayerA7Label.BackColor = System.Drawing.Color.Transparent;
            this.PlayerA7Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerA7Label.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerA7Label.Location = new System.Drawing.Point(24, 267);
            this.PlayerA7Label.Name = "PlayerA7Label";
            this.PlayerA7Label.Size = new System.Drawing.Size(36, 33);
            this.PlayerA7Label.TabIndex = 9;
            this.PlayerA7Label.Text = "0";
            this.PlayerA7Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerA10Label
            // 
            this.PlayerA10Label.AutoSize = true;
            this.PlayerA10Label.BackColor = System.Drawing.Color.Transparent;
            this.PlayerA10Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerA10Label.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerA10Label.Location = new System.Drawing.Point(24, 234);
            this.PlayerA10Label.Name = "PlayerA10Label";
            this.PlayerA10Label.Size = new System.Drawing.Size(36, 33);
            this.PlayerA10Label.TabIndex = 10;
            this.PlayerA10Label.Text = "0";
            this.PlayerA10Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerAPunishLabel
            // 
            this.PlayerAPunishLabel.AutoSize = true;
            this.PlayerAPunishLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerAPunishLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerAPunishLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerAPunishLabel.ForeColor = System.Drawing.Color.Red;
            this.PlayerAPunishLabel.Location = new System.Drawing.Point(24, 134);
            this.PlayerAPunishLabel.Name = "PlayerAPunishLabel";
            this.PlayerAPunishLabel.Size = new System.Drawing.Size(36, 33);
            this.PlayerAPunishLabel.TabIndex = 11;
            this.PlayerAPunishLabel.Text = "0";
            this.PlayerAPunishLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerA10Caption
            // 
            this.PlayerA10Caption.AutoSize = true;
            this.PlayerA10Caption.BackColor = System.Drawing.Color.Transparent;
            this.PlayerA10Caption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerA10Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerA10Caption.Location = new System.Drawing.Point(66, 234);
            this.PlayerA10Caption.Name = "PlayerA10Caption";
            this.PlayerA10Caption.Size = new System.Drawing.Size(122, 33);
            this.PlayerA10Caption.TabIndex = 19;
            this.PlayerA10Caption.Text = "Ippon";
            this.PlayerA10Caption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerAPunishCaption
            // 
            this.PlayerAPunishCaption.AutoSize = true;
            this.PlayerAPunishCaption.BackColor = System.Drawing.Color.Transparent;
            this.PlayerAPunishCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerAPunishCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerAPunishCaption.Location = new System.Drawing.Point(66, 134);
            this.PlayerAPunishCaption.Name = "PlayerAPunishCaption";
            this.PlayerAPunishCaption.Size = new System.Drawing.Size(122, 33);
            this.PlayerAPunishCaption.TabIndex = 20;
            this.PlayerAPunishCaption.Text = "Shido";
            this.PlayerAPunishCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerALabel
            // 
            this.PlayerALabel.AutoSize = true;
            this.PlayerAShape.SetColumnSpan(this.PlayerALabel, 2);
            this.PlayerALabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerALabel.Location = new System.Drawing.Point(24, 0);
            this.PlayerALabel.Name = "PlayerALabel";
            this.PlayerALabel.Size = new System.Drawing.Size(164, 67);
            this.PlayerALabel.TabIndex = 0;
            this.PlayerALabel.Text = "Nachname, Vorname";
            this.PlayerALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerA7Caption
            // 
            this.PlayerA7Caption.AutoSize = true;
            this.PlayerA7Caption.BackColor = System.Drawing.Color.Transparent;
            this.PlayerA7Caption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerA7Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerA7Caption.Location = new System.Drawing.Point(66, 267);
            this.PlayerA7Caption.Name = "PlayerA7Caption";
            this.PlayerA7Caption.Size = new System.Drawing.Size(122, 33);
            this.PlayerA7Caption.TabIndex = 18;
            this.PlayerA7Caption.Text = "Waza-Ari";
            this.PlayerA7Caption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerAShape
            // 
            this.PlayerAShape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.PlayerAShape.ColumnCount = 4;
            this.PlayerAShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerAShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PlayerAShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.PlayerAShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerAShape.Controls.Add(this.PlayerA7Label, 1, 5);
            this.PlayerAShape.Controls.Add(this.PlayerA10Label, 1, 4);
            this.PlayerAShape.Controls.Add(this.PlayerAPunishLabel, 1, 2);
            this.PlayerAShape.Controls.Add(this.PlayerA7Caption, 2, 5);
            this.PlayerAShape.Controls.Add(this.PlayerA10Caption, 2, 4);
            this.PlayerAShape.Controls.Add(this.PlayerAPunishCaption, 2, 2);
            this.PlayerAShape.Controls.Add(this.PlayerALabel, 1, 0);
            this.PlayerAShape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerAShape.Location = new System.Drawing.Point(0, 0);
            this.PlayerAShape.Margin = new System.Windows.Forms.Padding(0);
            this.PlayerAShape.Name = "PlayerAShape";
            this.PlayerAShape.RowCount = 7;
            this.MainLayoutPanel.SetRowSpan(this.PlayerAShape, 4);
            this.PlayerAShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PlayerAShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PlayerAShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerAShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PlayerAShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerAShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerAShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerAShape.Size = new System.Drawing.Size(214, 336);
            this.PlayerAShape.TabIndex = 2;
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.ColumnCount = 6;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.MainLayoutPanel.Controls.Add(this.PlayerAShape, 0, 0);
            this.MainLayoutPanel.Controls.Add(this.TimeLabel, 1, 1);
            this.MainLayoutPanel.Controls.Add(this.HoldTimeLabel, 2, 2);
            this.MainLayoutPanel.Controls.Add(this.PlayerBShape, 5, 0);
            this.MainLayoutPanel.Controls.Add(this.pictureBox1, 1, 3);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 4;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.95139F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.42201F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.95139F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.67521F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(600, 336);
            this.MainLayoutPanel.TabIndex = 28;
            // 
            // PlayerBShape
            // 
            this.PlayerBShape.BackColor = System.Drawing.Color.White;
            this.PlayerBShape.ColumnCount = 4;
            this.PlayerBShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerBShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.PlayerBShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PlayerBShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerBShape.Controls.Add(this.PlayerBPunishLabel, 2, 2);
            this.PlayerBShape.Controls.Add(this.PlayerB7Label, 2, 5);
            this.PlayerBShape.Controls.Add(this.PlayerBLabel, 1, 0);
            this.PlayerBShape.Controls.Add(this.PlayerB7Caption, 1, 5);
            this.PlayerBShape.Controls.Add(this.PlayerB10Caption, 1, 4);
            this.PlayerBShape.Controls.Add(this.PlayerB10Label, 2, 4);
            this.PlayerBShape.Controls.Add(this.PlayerBPunishCaption, 1, 2);
            this.PlayerBShape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerBShape.Location = new System.Drawing.Point(382, 0);
            this.PlayerBShape.Margin = new System.Windows.Forms.Padding(0);
            this.PlayerBShape.Name = "PlayerBShape";
            this.PlayerBShape.RowCount = 7;
            this.MainLayoutPanel.SetRowSpan(this.PlayerBShape, 4);
            this.PlayerBShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PlayerBShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PlayerBShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerBShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PlayerBShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerBShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerBShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PlayerBShape.Size = new System.Drawing.Size(218, 336);
            this.PlayerBShape.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.MainLayoutPanel.SetColumnSpan(this.pictureBox1, 4);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Judoplaner2.Properties.Resources.shidosha_white;
            this.pictureBox1.Location = new System.Drawing.Point(217, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // BottomBarLayoutPanel
            // 
            this.BottomBarLayoutPanel.AutoSize = true;
            this.BottomBarLayoutPanel.ColumnCount = 3;
            this.BottomBarLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.BottomBarLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BottomBarLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BottomBarLayoutPanel.Controls.Add(this.StatsLabel, 2, 0);
            this.BottomBarLayoutPanel.Controls.Add(this.ProgressBar, 1, 0);
            this.BottomBarLayoutPanel.Controls.Add(this.PrepareLabel, 0, 0);
            this.BottomBarLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomBarLayoutPanel.Location = new System.Drawing.Point(0, 336);
            this.BottomBarLayoutPanel.Name = "BottomBarLayoutPanel";
            this.BottomBarLayoutPanel.RowCount = 1;
            this.BottomBarLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomBarLayoutPanel.Size = new System.Drawing.Size(600, 14);
            this.BottomBarLayoutPanel.TabIndex = 14;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.ProgressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressBar.Location = new System.Drawing.Point(242, 2);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(296, 10);
            this.ProgressBar.TabIndex = 24;
            this.ProgressBar.Value = 0;
            // 
            // TDisplayForm
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.MainLayoutPanel);
            this.Controls.Add(this.BottomBarLayoutPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Location = new System.Drawing.Point(145, 95);
            this.Name = "TDisplayForm";
            this.Text = "DisplayForm";
            this.Resize += new System.EventHandler(this.FormResize);
            this.PlayerAShape.ResumeLayout(false);
            this.PlayerAShape.PerformLayout();
            this.MainLayoutPanel.ResumeLayout(false);
            this.MainLayoutPanel.PerformLayout();
            this.PlayerBShape.ResumeLayout(false);
            this.PlayerBShape.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BottomBarLayoutPanel.ResumeLayout(false);
            this.BottomBarLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
#endregion

        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.Label PlayerA7Label;
        public System.Windows.Forms.Label PlayerA10Label;
        public System.Windows.Forms.Label PlayerAPunishLabel;
        public System.Windows.Forms.Label PlayerA10Caption;
        public System.Windows.Forms.Label PlayerAPunishCaption;
        public System.Windows.Forms.Label PlayerALabel;
        public System.Windows.Forms.Label PlayerA7Caption;
        public System.Windows.Forms.TableLayoutPanel PlayerAShape;
        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel BottomBarLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel PlayerBShape;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}
