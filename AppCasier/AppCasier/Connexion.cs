using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCasier
{
    public partial class Connexion : Form
    {
        private MainForm mainForm; // Référence vers MainForm
        DatabaseConnection db = new DatabaseConnection(); // Instance de la classe DatabaseConnection
        public Connexion(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            if (db.OpenConnection() == false)
            {
                MessageBox.Show("Connexion échouée !");
            }
        }

        private void btConnexion_Click(object sender, EventArgs e)
        {
            //if (db.estAdministateur(tbLogin.Text))
            //{
            //    mainForm.SetUserData("S" + tbLogin.Text); // Met à jour les données
            //}

            if (db.estUtilisateur(tbLogin.Text, tbPasswd.Text))
            {
                mainForm.SetUserData("U" + tbLogin.Text); // Met à jour les données
                this.Close(); // Ferme la page actuelle pour revenir à `MainForm`
            }
            else
            {
                MessageBox.Show("Connexion échouée !");
            }


        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
