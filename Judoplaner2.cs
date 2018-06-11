using System;
using System.Windows.Forms;
using UGroup;
using UClass;
using UFight;
using USettings;
using ULoad;
using UDisplay;
using UPrint;
using UGameRR;
using UGameDE;
using UHelpers;
namespace Judoplaner2
{
    public class Judoplaner2
    {
        // GroupForm
        // FightForm
        // SettingsForm
        // LoadForm
        // DisplayForm
        // PrintForm
        [STAThread]
        public static void Main(string[] args)
        {
            // Application.Initialize;
            Application.EnableVisualStyles();
            //@ Unsupported property or method(C): 'ShowMainForm'
            //TODO: Application.ShowMainForm = false;
            Units.Group.GroupForm = new TGroupForm();
            Units.Load.LoadForm = new TLoadForm();
            Units.Fight.FightForm = new TFightForm();
            Units.Settings.SettingsForm = new TSettingsForm();
            Units.Display.DisplayForm = new TDisplayForm();
            Units.Print.Printing = new TPrinting();
            // Application.Run;
            Units.Group.GroupForm.Visible = false;
            Application.Run(Units.Load.LoadForm);
        }

    } // end Judoplaner2

}

