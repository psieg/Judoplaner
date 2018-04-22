namespace ULoad
{
  partial class TLoadForm
  {
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.PictureBox Image1;
        public System.Windows.Forms.Timer Timer1;
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
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Gray;
            this.Label1.Location = new System.Drawing.Point(82, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(266, 41);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "%Appname %V";
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1Timer);
            // 
            // Image1
            // 
            this.Image1.Image = global::Judoplaner2.Properties.Resources.logo;
            this.Image1.Location = new System.Drawing.Point(12, 12);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(64, 64);
            this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image1.TabIndex = 3;
            this.Image1.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 70);
            this.label3.TabIndex = 5;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.White;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(20, 0);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.Label2.Size = new System.Drawing.Size(320, 90);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "loading...";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TLoadForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(360, 90);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(525, 425);
            this.Name = "TLoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadForm";
            this.Load += new System.EventHandler(this.FormCreate);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label Label2;

    }
}
