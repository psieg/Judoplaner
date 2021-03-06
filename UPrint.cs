using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using UClass;
namespace UPrint
{
    public class TPrinting
    {
        private Bitmap bm;
        private PRINTSCALE ps;

        private void PrintCallback(object sender, PrintPageEventArgs e)
        {
            double scale = 1.0;
            Rectangle m = e.MarginBounds;

            switch (ps)
            {
                case PRINTSCALE.PRINTSCL_SCALE_AUTO:
                    if ((double)bm.Width / (double)bm.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)bm.Height / (double)bm.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)bm.Width / (double)bm.Height * (double)m.Height);
                    }
                    break;
                case PRINTSCALE.PRINTSCL_SCALE_X:
                    m.Height = (int)((double)bm.Height / (double)bm.Width * (double)m.Width);
                    break;
                case PRINTSCALE.PRINTSCL_SCALE_Y:
                    m.Width = (int)((double)bm.Width / (double)bm.Height * (double)m.Height);
                    break;
                default:
                    throw new NotImplementedException();
            }
            e.Graphics.DrawImage(bm, m);
            Font font = new Font("Arial", 8, FontStyle.Italic);
            Brush brush = new SolidBrush(Color.Gray);
            // 11 is text height
            e.Graphics.DrawString(Units.Class.PRINTMARK, font, brush, 50, e.PageBounds.Bottom - 50 - 11);
            e.Graphics.DrawImage(Judoplaner2.Properties.Resources.shidosha_black, new Rectangle(e.PageBounds.Left + 50, e.PageBounds.Bottom - 100 - 50 - 11 - 11, 100, 100));
        }

        public bool Print(IWin32Window owner, Bitmap b, string name, bool LandScape, PRINTSCALE PrintScaling)
        {
            bm = b;
            ps = PrintScaling;

            PrintDocument pd = new PrintDocument();
            pd.DocumentName = name;
            pd.PrintPage += PrintCallback;
            pd.DefaultPageSettings.Landscape = LandScape;

            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = pd;
            DialogResult result = printDialog1.ShowDialog();

            try
            {
                pd.Print();
            }
            catch (Exception e)
            {
                MessageBox.Show(Units.Group.GroupForm, "Fehler beim Drucken: " + e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bm = null;

            return true;

            /*
        bool result;
        double scale;
        int cWidth;
        int cHeight;
        //@ Unsupported property or method(C): 'Progress'
        ProgressBar.Value = 0;
        StatusLabel.Text = "Drucker w�hlen...";
        if (PrintDialog.ShowDialog() == DialogResult.OK)
        {
            //@ Unsupported property or method(D): 'Title'
            Printer.Title = name;
            //@ Unsupported property or method(C): 'Progress'
            ProgressBar.Value = 10;
            StatusLabel.Text = "Dokument vorbereiten...";
            if (LandScape)
            {
                //@ Undeclared identifier(3): 'poLandscape'
                //@ Unsupported property or method(D): 'Orientation'
                Printer.Orientation = poLandscape;
            }
            else
            {
                //@ Undeclared identifier(3): 'poPortrait'
                //@ Unsupported property or method(D): 'Orientation'
                Printer.Orientation = poPortrait;
            }
            //@ Unsupported property or method(B): 'BeginDoc'
            Printer.BeginDoc();
            //@ Unsupported property or method(D): 'Canvas'
            //@ Unsupported property or method(B): 'TextOut'
            Printer.Canvas.TextOut(0, 0, "");
            // Printer.NewPage();
            //@ Unsupported property or method(D): 'PageHeight'
            //@ Unsupported property or method(D): 'Canvas'
            //@ Unsupported property or method(D): 'Font'
            //@ Unsupported property or method(D): 'Size'
            Printer.Canvas.Font.Size = Math.Round(Convert.ToDouble(Printer.PageHeight / 1000));
            //@ Unsupported property or method(D): 'Canvas'
            //@ Unsupported property or method(D): 'Font'
            //@ Unsupported property or method(D): 'Name'
            Printer.Canvas.Font.Name = "Arial";
            //@ Unsupported property or method(D): 'Canvas'
            //@ Unsupported property or method(D): 'Font'
            //@ Unsupported property or method(D): 'Color'
            Printer.Canvas.Font.Color = System.Drawing.Color.Gray;
            //@ Unsupported property or method(D): 'Canvas'
            //@ Unsupported property or method(D): 'Font'
            //@ Unsupported property or method(D): 'Style'
            Printer.Canvas.Font.Style = new System.Drawing.FontStyle[] {System.Drawing.FontStyle.Italic};
            if (PrintScaling == PRINTSCALE.PRINTSCL_SCALE_AUTO)
            {
                //@ Unsupported property or method(D): 'PageHeight'
                //@ Unsupported property or method(D): 'PageWidth'
                if (b.Height / Printer.PageHeight < b.Width / Printer.PageWidth)
                {
                    //@ Unsupported property or method(D): 'PageWidth'
                    scale = Printer.PageWidth / b.Width;
                }
                else
                {
                    //@ Unsupported property or method(D): 'PageHeight'
                    scale = Printer.PageHeight / b.Height;
                }
            }
            else if (PrintScaling == PRINTSCALE.PRINTSCL_SCALE_X)
            {
                //@ Unsupported property or method(D): 'PageWidth'
                scale = Printer.PageWidth / b.Width;
            }
            else if (PrintScaling == PRINTSCALE.PRINTSCL_SCALE_Y)
            {
                //@ Unsupported property or method(D): 'PageHeight'
                scale = Printer.PageHeight / b.Height;
            }
            else
            {
                scale = Units.UPrint.GLUESCALE;
            }
            //@ Unsupported property or method(C): 'Progress'
            ProgressBar.Progress = 20;
            StatusLabel.Text = "Dokument erstellen...";
            switch(PrintScaling)
            {
                case PRINTSCALE.PRINTSCL_SCALE_AUTO:
                    // bring everything on one page
                    //@ Unsupported property or method(C): 'Canvas'
                    //@ Unsupported property or method(D): 'Canvas'
                    //@ Unsupported property or method(B): 'CopyRect'
                    Printer.Canvas.CopyRect(new Rectangle(0, 0, Convert.ToInt64(b.Width * scale), Convert.ToInt64(b.Height * scale)), b.Canvas, new Rectangle(0, 0, b.Width, b.Height));
                    //@ Unsupported property or method(D): 'PageHeight'
                    //@ Unsupported property or method(D): 'Canvas'
                    //@ Unsupported property or method(B): 'TextHeight'
                    //@ Unsupported property or method(D): 'Canvas'
                    //@ Unsupported property or method(B): 'TextOut'
                    Printer.Canvas.TextOut(50, Printer.PageHeight - 50 - Printer.Canvas.TextHeight(UClass.Units.UClass.STDSTR), UClass.Units.UClass.PRINTMARK);
                    break;
                case PRINTSCALE.PRINTSCL_SCALE_X:
                    // scale so that width is one page
                    cHeight = 0;
                    while (cHeight < b.Height)
                    {
                        if (cHeight != 0)
                        {
                            //@ Unsupported property or method(B): 'NewPage'
                            Printer.NewPage();
                            //@ Unsupported property or method(D): 'Canvas'
                            //@ Unsupported property or method(B): 'TextOut'
                            Printer.Canvas.TextOut(0, 0, "");
                        }
                        //@ Unsupported property or method(D): 'PageWidth'
                        //@ Unsupported property or method(D): 'PageHeight'
                        //@ Unsupported property or method(C): 'Canvas'
                        //@ Unsupported property or method(D): 'PageHeight'
                        //@ Unsupported property or method(D): 'Canvas'
                        //@ Unsupported property or method(B): 'CopyRect'
                        Printer.Canvas.CopyRect(new Rectangle(0, 0, Printer.PageWidth, Printer.PageHeight), b.Canvas, new Rectangle(0, cHeight, b.Width, cHeight + Convert.ToInt64(Printer.PageHeight / scale)));
                        //@ Unsupported property or method(D): 'PageHeight'
                        //@ Unsupported property or method(D): 'Canvas'
                        //@ Unsupported property or method(B): 'TextHeight'
                        //@ Unsupported property or method(D): 'Canvas'
                        //@ Unsupported property or method(B): 'TextOut'
                        Printer.Canvas.TextOut(50, Printer.PageHeight - 50 - Printer.Canvas.TextHeight(UClass.Units.UClass.STDSTR), UClass.Units.UClass.PRINTMARK);
                        //@ Unsupported property or method(D): 'PageHeight'
                        cHeight = cHeight + Convert.ToInt64(Printer.PageHeight / scale);
                    }
                    break;
                case PRINTSCALE.PRINTSCL_SCALE_Y:
                    // scale so that height is one page
                    cWidth = 0;
                    while (cWidth < b.Width)
                    {
                        if (cWidth != 0)
                        {
                            //@ Unsupported property or method(B): 'NewPage'
                            Printer.NewPage();
                            //@ Unsupported property or method(D): 'Canvas'
                            //@ Unsupported property or method(B): 'TextOut'
                            Printer.Canvas.TextOut(0, 0, "");
                        }
                        //@ Unsupported property or method(D): 'PageWidth'
                        //@ Unsupported property or method(D): 'PageHeight'
                        //@ Unsupported property or method(C): 'Canvas'
                        //@ Unsupported property or method(D): 'PageWidth'
                        //@ Unsupported property or method(D): 'Canvas'
                        //@ Unsupported property or method(B): 'CopyRect'
                        Printer.Canvas.CopyRect(new Rectangle(0, 0, Printer.PageWidth, Printer.PageHeight), b.Canvas, new Rectangle(cWidth, 0, cWidth + Convert.ToInt64(Printer.PageWidth / scale), b.Height));
                        //@ Unsupported property or method(D): 'PageHeight'
                        //@ Unsupported property or method(D): 'Canvas'
                        //@ Unsupported property or method(B): 'TextHeight'
                        //@ Unsupported property or method(D): 'Canvas'
                        //@ Unsupported property or method(B): 'TextOut'
                        Printer.Canvas.TextOut(50, Printer.PageHeight - 50 - Printer.Canvas.TextHeight(UClass.Units.UClass.STDSTR), UClass.Units.UClass.PRINTMARK);
                        //@ Unsupported property or method(D): 'PageWidth'
                        cWidth = cWidth + Convert.ToInt64(Printer.PageWidth / scale);
                    }
                    break;
                case PRINTSCALE.PRINTSCL_GLUE:
                    cHeight = 0;
                    while (cHeight < b.Height)
                    {
                        cWidth = 0;
                        while (cWidth < b.Width)
                        {
                            if ((cWidth != 0) || (cHeight != 0))
                            {
                                //@ Unsupported property or method(B): 'NewPage'
                                Printer.NewPage();
                                //@ Unsupported property or method(D): 'Canvas'
                                //@ Unsupported property or method(B): 'TextOut'
                                Printer.Canvas.TextOut(0, 0, "");
                            }
                            //@ Unsupported property or method(D): 'PageWidth'
                            //@ Unsupported property or method(D): 'PageHeight'
                            //@ Unsupported property or method(C): 'Canvas'
                            //@ Unsupported property or method(D): 'PageWidth'
                            //@ Unsupported property or method(D): 'PageHeight'
                            //@ Unsupported property or method(D): 'Canvas'
                            //@ Unsupported property or method(B): 'CopyRect'
                            Printer.Canvas.CopyRect(new Rectangle(0, 0, Printer.PageWidth, Printer.PageHeight), b.Canvas, new Rectangle(cWidth, cHeight, cWidth + Convert.ToInt64(Printer.PageWidth / scale), cHeight + Convert.ToInt64(Printer.PageHeight / scale)));
                            //@ Unsupported property or method(D): 'PageHeight'
                            //@ Unsupported property or method(D): 'Canvas'
                            //@ Unsupported property or method(B): 'TextHeight'
                            //@ Unsupported property or method(D): 'Canvas'
                            //@ Unsupported property or method(B): 'TextOut'
                            Printer.Canvas.TextOut(50, Printer.PageHeight - 50 - Printer.Canvas.TextHeight(UClass.Units.UClass.STDSTR), UClass.Units.UClass.PRINTMARK);
                            //@ Unsupported property or method(D): 'PageWidth'
                            cWidth = cWidth + Convert.ToInt64(Printer.PageWidth / scale);
                        }
                        //@ Unsupported property or method(D): 'PageHeight'
                        cHeight = cHeight + Convert.ToInt64(Printer.PageHeight / scale);
                    }
                    break;
            }
            //@ Unsupported property or method(C): 'Progress'
            ProgressBar.Progress = 80;
            StatusLabel.Text = "Druckauftrag senden...";
            //@ Unsupported property or method(B): 'EndDoc'
            Printer.EndDoc();
             * 
        }
        //@ Unsupported property or method(C): 'Progress'
        ProgressBar.Value = 100;
        StatusLabel.Text = "Fertig.";
        result = true;
        return result;
             */
        }

        // Note: the original parameters are Object Sender, ref bool CanClose
        public void FormCloseQuery(System.Object Sender, System.ComponentModel.CancelEventArgs _e1)
        {
            _e1.Cancel = true;
        }

    } // end TPrintForm

    public enum PRINTSCALE
    {
        PRINTSCL_SCALE_AUTO,
        PRINTSCL_SCALE_X,
        PRINTSCL_SCALE_Y,
        PRINTSCL_GLUE
    } // end PRINTSCALE

}

namespace Units
{
    public class Print
    {
        public static UPrint.TPrinting Printing = null;
        public const int GLUESCALE = 3;
    } // end UPrint

}

