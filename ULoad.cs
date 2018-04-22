using System;
using System.Windows.Forms;
using System.IO;
using UGroup;
using UDisplay;
using UClass;
namespace ULoad
{
    public partial class TLoadForm: Form
    {
        public TLoadForm()
        {
            InitializeComponent();
        }

        public void Timer1Timer(System.Object Sender, System.EventArgs _e1)
        {
            Units.Group.GroupForm.Show();
            if (Screen.AllScreens.Length> 1)
            {
                Units.Display.DisplayForm.Show();
                Units.Display.DisplayForm.Left = Screen.AllScreens[1].Bounds.Left;
                Units.Display.DisplayForm.Top = Screen.AllScreens[1].Bounds.Top;
                Units.Display.DisplayForm.Width = Screen.AllScreens[1].Bounds.Width;
                Units.Display.DisplayForm.Height = Screen.AllScreens[1].Bounds.Height;
            }
            this.Hide();
            this.Timer1.Enabled = false;
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            int i;
            bool good1;
            bool good2;
            string keywanted;
            DateTime dCompiled;
            Label1.Text = Units.Class.APPNAME + ' ' + Units.Class.VERSION + ' ';
            good1 = false;
            good2 = false;
            dCompiled = new DateTime(2012, 05 ,12);
            // if SecondsBetween(dCompiled,Now()) < 8640000 then //100 Tage
            good2 = true;
            if (!good2)
            {
                Timer1.Enabled = false;
                MessageBox.Show("Zugriffsverletzung bei Adresse 004B1C37 in Modul \'" + Path.GetFileName(System.Environment.GetCommandLineArgs()[0]) + "\'.\r\nLesen von Adresse 00000000.", System.AppDomain.CurrentDomain.FriendlyName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Application.Exit();
            }
            if (good1)
            {
                this.Timer1.Interval = 1;
            }
        }

    } // end TLoadForm

}

namespace Units
{
    public class Load
    {
        public static ULoad.TLoadForm LoadForm = null;
    } // end ULoad

}

