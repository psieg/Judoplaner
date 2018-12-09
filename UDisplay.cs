using System;
using System.Windows.Forms;
using System.Drawing.Text;

namespace UDisplay
{
    public partial class TDisplayForm: Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        System.Drawing.Font myFont;
        System.Drawing.FontFamily myFontFamily;

        public TDisplayForm()
        {
            InitializeComponent();

            byte[] fontData = Judoplaner2.Properties.Resources.MachineStd;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Judoplaner2.Properties.Resources.MachineStd.Length);
            AddFontMemResourceEx(fontPtr, (uint)Judoplaner2.Properties.Resources.MachineStd.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFontFamily = fonts.Families[0];
            myFont = new System.Drawing.Font(fonts.Families[0], 16.0F);
        }

        public void FormResize(System.Object Sender, System.EventArgs _e1)
        {
            var TimeFont = new System.Drawing.Font(this.TimeLabel.Font.Name, (int)Math.Round(this.Height / 10.0),
                this.Font.Style, this.Font.Unit);
            var HoldTimeFont = new System.Drawing.Font(this.HoldTimeLabel.Font.Name, (int)Math.Round(this.Height / 20.0),
                this.Font.Style, this.Font.Unit);
            var PlayersFont = new System.Drawing.Font(this.PlayerALabel.Font.Name, (int)Math.Round(this.Height / 40.0),
                this.Font.Style, this.Font.Unit);
            var CaptionFont = new System.Drawing.Font(myFontFamily, (int)Math.Round(this.Height / 30.0),
                this.Font.Style, this.Font.Unit);
            var NumbersFont = new System.Drawing.Font(myFontFamily, (int)Math.Round(this.Height / 20.0),
                this.Font.Style, this.Font.Unit);
            var BottomFont = new System.Drawing.Font(this.PrepareLabel.Font.Name, (int)Math.Round(this.Height / 55.0),
                this.Font.Style, this.Font.Unit);

            this.TimeLabel.Font = TimeFont;
            this.HoldTimeLabel.Font = HoldTimeFont;
            this.PlayerALabel.Font = PlayersFont;
            this.PlayerBLabel.Font = PlayersFont;



            this.PlayerA7Caption.Font = CaptionFont;
            this.PlayerA10Caption.Font = CaptionFont;
            this.PlayerAPunishCaption.Font = CaptionFont;
            this.PlayerB7Caption.Font = CaptionFont;
            this.PlayerB10Caption.Font = CaptionFont;
            this.PlayerBPunishCaption.Font = CaptionFont;

            this.PlayerA7Label.Font = NumbersFont;
            this.PlayerA10Label.Font = NumbersFont;
            this.PlayerAPunishLabel.Font = NumbersFont;
            this.PlayerB7Label.Font = NumbersFont;
            this.PlayerB10Label.Font = NumbersFont;
            this.PlayerBPunishLabel.Font = NumbersFont;

            this.StatsLabel.Font = BottomFont;
            this.PrepareLabel.Font = BottomFont;

        }

    } // end TDisplayForm

}

namespace Units
{
    public class Display
    {
        public static UDisplay.TDisplayForm DisplayForm = null;
    } // end UDisplay

}

