namespace UPrint
{
  partial class TPrintForm
    {
        public System.Windows.Forms.ProgressBar ProgressBar;
        public System.Windows.Forms.Label StatusLabel;
        public System.Windows.Forms.PrintDialog PrintDialog;
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
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PrintDialog = new System.Windows.Forms.PrintDialog();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(0, 0);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 23);
            this.ProgressBar.TabIndex = 0;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new System.Drawing.Point(16, 48);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(56, 13);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "StatusLabel";
            // 
            // TPrintForm
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(353, 65);
            this.Controls.Add(this.StatusLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(365, 270);
            this.Name = "TPrintForm";
            this.ShowInTaskbar = false;
            this.Text = "PrintForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormCloseQuery);
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;

    }
}
