using System;
using System.Windows.Forms;
using Snythite_Canteen;

namespace BioMetrixCore
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (System.Configuration.ConfigurationSettings.AppSettings["App_Type"] == "Admin")
            {
                Application.Run(new Admin_Menu());
            }
            else
            {
                Application.Run(new Menu()); 
            }
        }
    }
}
