using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using testBDD;

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

            DatabaseConnection db = new DatabaseConnection();
            db.OpenConnection();

            Console.WriteLine("Connexion ouverte !");


            MainForm main = new MainForm();
            
            new Connexion(main);

            if (main.GetUserData() == "")
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
