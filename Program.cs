using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HSMAPP.LogIn;


namespace HSMAPP
{ 
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //public static Microsoft.Extensions.Configuration.IConfiguration Configuration;
        [STAThread]
        static void Main()
        {
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new firstpage());
            if(Loginfo.UserID==0)
            {
                foreach (Form form in Application.OpenForms) { form.Dispose(); }

                Application.Exit();
              
            }
        }
        
    }
}
