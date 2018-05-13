using System;
using System.Windows.Forms;
namespace UDisplay
{
    public partial class TDisplayForm: Form
    {
        public TDisplayForm()
        {
            InitializeComponent();
        }

        public void FormResize(System.Object Sender, System.EventArgs _e1)
        {
            int endl;
            int begr;
            int col;
            int cwidth;
            int lwidth;
            int th;
            col = 5;
            cwidth = (int)Math.Round(this.Width / 6.0);
            endl = (int)Math.Round((this.Width - cwidth) / 2.0);
            begr = endl + cwidth;
            lwidth = (int)Math.Round(endl / 4.0);
            this.Font = new System.Drawing.Font(this.Font.Name, (int)Math.Round(this.Height / 50.0),
                this.Font.Style, this.Font.Unit);
            TimeLabel.Font = new System.Drawing.Font(TimeLabel.Font.Name, (int)Math.Round(this.Height / 25.0),
                TimeLabel.Font.Style, TimeLabel.Font.Unit);
            //@ Unsupported property or method(C): 'Canvas'
            //@ Unsupported property or method(B): 'TextHeight'
            th = (int)Math.Round(this.Height / 50.0 * 1.2); //this.Canvas.TextHeight("ABCDEFGHIJKLMOPQRSTUVWXYZ1234567890!\"§$%&/()=?²³{[]}\\,.;:<>|^°ß´`-#+_\'*~");
            TimeLabel.Height = th * 2;
            HoldTimeLabel.Height = th;
            PrepareLabel.Height = th;
            StatsLabel.Height = th;
            //@ Unsupported property or method(C): 'Height'
            ProgressBar.Height = 2 * (int)Math.Round(th / 5.0);
            PlayerALabel.Height = th;
            PlayerA10Label.Height = th;
            PlayerA7Label.Height = th;
            //PlayerA5Label.Height = th;
            PlayerAPunishLabel.Height = th;
            PlayerA10Caption.Height = th;
            PlayerA7Caption.Height = th;
            //PlayerA5Caption.Height = th;
            PlayerAPunishCaption.Height = th;
            PlayerALabel.Top = col;
            PlayerALabel.Left = col;
            PlayerALabel.Width = endl - 2 * col;
            PlayerAShape.Left = col;
            PlayerAShape.Top = PlayerALabel.Top + PlayerALabel.Height + col;
            PlayerAShape.Width = endl - 2 * col;
            PlayerAShape.Height = this.Height - PlayerAShape.Top - col - PlayerA10Label.Height - col - PlayerA10Caption.Height - col - PrepareLabel.Height - col;
            PlayerA10Label.Top = PlayerAShape.Top + PlayerAShape.Height + col;
            PlayerA10Label.Left = col;
            PlayerA10Label.Width = lwidth;
            PlayerA7Label.Top = PlayerAShape.Top + PlayerAShape.Height + col;
            PlayerA7Label.Left = PlayerA10Label.Left + PlayerA10Label.Width + col;
            PlayerA7Label.Width = lwidth;
            //PlayerA5Label.Top = PlayerAShape.Top + PlayerAShape.Height + col;
            //PlayerA5Label.Left = PlayerA7Label.Left + PlayerA7Label.Width + col;
            //PlayerA5Label.Width = lwidth;
            PlayerAPunishLabel.Top = PlayerAShape.Top + PlayerAShape.Height + col;
            //PlayerAPunishLabel.Left = PlayerA5Label.Left + PlayerA5Label.Width + col;
            PlayerAPunishLabel.Width = lwidth;
            PlayerA10Caption.Top = PlayerA10Label.Top + PlayerA10Label.Height + col;
            PlayerA10Caption.Left = col;
            PlayerA10Caption.Width = lwidth;
            PlayerA7Caption.Top = PlayerA7Label.Top + PlayerA7Label.Height + col;
            PlayerA7Caption.Left = PlayerA10Caption.Left + PlayerA10Caption.Width + col;
            PlayerA7Caption.Width = lwidth;
            //PlayerA5Caption.Top = PlayerA5Label.Top + PlayerA5Label.Height + col;
            //PlayerA5Caption.Left = PlayerA7Caption.Left + PlayerA7Caption.Width + col;
            //PlayerA5Caption.Width = lwidth;
            PlayerAPunishCaption.Top = PlayerAPunishLabel.Top + PlayerAPunishLabel.Height + col;
            //PlayerAPunishCaption.Left = PlayerA5Caption.Left + PlayerA5Caption.Width + col;
            PlayerAPunishCaption.Width = lwidth;
            PlayerBLabel.Height = th;
            PlayerB10Label.Height = th;
            PlayerB7Label.Height = th;
            //PlayerB5Label.Height = th;
            PlayerBPunishLabel.Height = th;
            PlayerB10Caption.Height = th;
            PlayerB7Caption.Height = th;
            //PlayerB5Caption.Height = th;
            PlayerBPunishCaption.Height = th;
            PlayerBLabel.Top = col;
            PlayerBLabel.Left = begr + col;
            PlayerBLabel.Width = endl - 2 * col;
            PlayerBShape.Left = begr + col;
            PlayerBShape.Top = PlayerBLabel.Top + PlayerBLabel.Height + col;
            PlayerBShape.Width = endl - 2 * col;
            PlayerBShape.Height = this.Height - PlayerBShape.Top - col - PlayerB10Label.Height - col - PlayerB10Caption.Height - col - StatsLabel.Height - col;
            PlayerB10Label.Top = PlayerBShape.Top + PlayerBShape.Height + col;
            PlayerB10Label.Left = begr + col;
            PlayerB10Label.Width = lwidth;
            PlayerB7Label.Top = PlayerBShape.Top + PlayerBShape.Height + col;
            PlayerB7Label.Left = PlayerB10Label.Left + PlayerB10Label.Width + col;
            PlayerB7Label.Width = lwidth;
            //PlayerB5Label.Top = PlayerBShape.Top + PlayerBShape.Height + col;
            //PlayerB5Label.Left = PlayerB7Label.Left + PlayerB7Label.Width + col;
            //PlayerB5Label.Width = lwidth;
            PlayerBPunishLabel.Top = PlayerBShape.Top + PlayerBShape.Height + col;
            //PlayerBPunishLabel.Left = PlayerB5Label.Left + PlayerB5Label.Width + col;
            PlayerBPunishLabel.Width = lwidth;
            PlayerB10Caption.Top = PlayerB10Label.Top + PlayerB10Label.Height + col;
            PlayerB10Caption.Left = begr + col;
            PlayerB10Caption.Width = lwidth;
            PlayerB7Caption.Top = PlayerB7Label.Top + PlayerB7Label.Height + col;
            PlayerB7Caption.Left = PlayerB10Caption.Left + PlayerB10Caption.Width + col;
            PlayerB7Caption.Width = lwidth;
            //PlayerB5Caption.Top = PlayerB5Label.Top + PlayerB5Label.Height + col;
            //PlayerB5Caption.Left = PlayerB7Caption.Left + PlayerB7Caption.Width + col;
            //PlayerB5Caption.Width = lwidth;
            PlayerBPunishCaption.Top = PlayerBPunishLabel.Top + PlayerBPunishLabel.Height + col;
            //PlayerBPunishCaption.Left = PlayerB5Caption.Left + PlayerB5Caption.Width + col;
            PlayerBPunishCaption.Width = lwidth;
            TimeLabel.Top = PlayerAShape.Top + (int)Math.Round((PlayerAShape.Height - TimeLabel.Height) / 2.0);
            TimeLabel.Left = endl + col;
            TimeLabel.Width = begr - endl - 2 * col;
            HoldTimeLabel.Top = PlayerAShape.Top + (int)Math.Round((PlayerAShape.Height - HoldTimeLabel.Height) / 2.0) + TimeLabel.Height;
            HoldTimeLabel.Left = endl + col;
            HoldTimeLabel.Width = begr - endl - 2 * col;
            PrepareLabel.Top = PlayerA10Caption.Top + PlayerA10Caption.Height + col;
            PrepareLabel.Left = col;
            PrepareLabel.Width = (int)Math.Round(this.Width / 2.0) - col;
            //@ Unsupported property or method(C): 'Top'
            ProgressBar.Top = PlayerA10Caption.Top + PlayerA10Caption.Height + col + (int)Math.Round(th / 5.0);
            //@ Unsupported property or method(C): 'Left'
            ProgressBar.Left = PrepareLabel.Left + PrepareLabel.Width + 2 * col;
            //@ Unsupported property or method(C): 'Width'
            ProgressBar.Width = (int)Math.Round(this.Width / 4.0) - 2 * col;
            StatsLabel.Top = PlayerA10Caption.Top + PlayerA10Caption.Height + col;
            //@ Unsupported property or method(C): 'Left'
            //@ Unsupported property or method(C): 'Width'
            StatsLabel.Left = ProgressBar.Left + ProgressBar.Width + 2 * col;
            StatsLabel.Width = (int)Math.Round(this.Width / 4.0) - col;
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

