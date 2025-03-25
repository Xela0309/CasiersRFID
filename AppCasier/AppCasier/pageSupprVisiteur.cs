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
        DatabaseConnection db = new DatabaseConnection(); // Instance de la classe DatabaseConnection
        public pageSupprVisiteur()
        {
            InitializeComponent();
            affichageVisiteur();
        }

        private void affichageVisiteur()
        {
            db.OpenConnection();

            // Récupération des visiteurs
            string[] visiteurs = db.recupNomPrenomVisiteurNonAffecté();
            // Ajout des visiteurs dans la liste

            if (visiteurs != null)
            {
                for (int i = 0; i < visiteurs.Length; i++)
                {
                    cbVisiteur.Items.Add(visiteurs[i]);
                }
            }

        }

        private void btSuppr_Click(object sender, EventArgs e)
        {
            // Recuperer le nom du visiteur et son prenom
            string[] nomPrenom = cbVisiteur.Text.Split(' ');
            string nom = nomPrenom[0];
            string prenom = nomPrenom[1];

            // Supprimer le visiteur
            if (db.supprimerVisiteur(nom, prenom))
            {
                MessageBox.Show("Visiteur supprimé !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression du visiteur !");
            }

        }
    }
}
