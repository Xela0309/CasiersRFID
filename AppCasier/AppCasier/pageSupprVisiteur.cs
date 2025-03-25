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
    public partial class pageSupprVisiteur : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        public pageSupprVisiteur()
        {
            InitializeComponent();
            affichageVisiteur();
        }

        private void btSuppr_Click(object sender, EventArgs e)
        {
            string nom = cbVisiteur.Text;
            db.supprVisiteur(nom);
            MessageBox.Show("Le visiteur a bien été supprimé");
            this.Close();
        }

        private void affichageVisiteur()
        {
            // Requête SQL pour récupérer les visiteurs de la base de données dans une liste
            string[] liste = db.recupNomVisiteurNonAffecté();

            for (int i = 0; i < liste.Length; i++)
            {
                cbVisiteur.Items.Add(liste[i]);
            }



        }
    }
}
