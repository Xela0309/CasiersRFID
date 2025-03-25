using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCasier
{

    internal static class Program
    {

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



        MainForm main = new MainForm();
            
            new Connexion(main);

            if (main.GetLogin() == "")
            {
                Application.Exit();
            }
            else
            {
                Application.Run(main);

            }

        }
    }
}
