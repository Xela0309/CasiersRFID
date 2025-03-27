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
    public partial class pageSupprUtilisateur : Form
    {

        DatabaseConnection db = new DatabaseConnection();   
        public pageSupprUtilisateur()
        {
            InitializeComponent();
            db.OpenConnection();
            affichageUtiisateur();
        }
        private void affichageUtiisateur()
        {

            string[] liste = db.recupNomUtilisateur();

            for (int i = 0; i < liste.Length; i++)
            {
                cbUtilisateur.Items.Add(liste[i]);
            }
        }

        private void btSuppr_Click(object sender, EventArgs e)
        {
            string utilisateur = cbUtilisateur.Text;
            if (db.supprimerUtilisateur(utilisateur))
            {
                MessageBox.Show("Utilisateur supprimé !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression de l'utilisateur !");
            }

        }
    }
}
