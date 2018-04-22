namespace UPrint
{
  partial class TPrintForm
    {
        public System.Windows.Forms.ProgressBar ProgressBar;
        public System.Windows.Forms.Label StatusLabel;
        public System.Windows.Forms.PrintDialog PrintDialog;
        private System.ComponentModel.Container components = null;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(this.GetType());
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PrintDialog = new System.Windows.Forms.PrintDialog();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(365, 270);
            this.ClientSize  = new System.Drawing.Size(353, 65);
            this.Font  = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(1)));
            this.AutoScroll = true;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormCloseQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PrintForm";
            this.Text = "PrintForm";
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StatusLabel.Size  = new System.Drawing.Size(56, 13);
            this.StatusLabel.Location  = new System.Drawing.Point(16, 48);
            this.StatusLabel.Text = "StatusLabel";
            this.StatusLabel.Enabled = true;
            this.StatusLabel.Name = "StatusLabel";
            this.Controls.Add(StatusLabel);
            this.ResumeLayout(false);
        }
#endregion

    }
}
