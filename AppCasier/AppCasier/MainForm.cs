using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testBDD;

namespace AppCasier
{
    public partial class MainForm : Form
    {

        private string login = ""; // Variable conservée
        DatabaseConnection db = new DatabaseConnection(); // Instance de la classe DatabaseConnection

        public MainForm()
        {
            OpenConnexion(); // Ouvrir Page de Connexion
            if (login == "") // Si l'utilisateur n'est pas connecté
            {
                // Fermer l'application
                Application.Exit();
            }
            else
            { 
                db.OpenConnection(); // Ouvrir la connexion à la base de données
                InitializeComponent();
                AfficherAffectation(); // Afficher les affectations
            }
        }

        // Ouvrir Page de Connexion
        private void OpenConnexion()
        {
            Connexion connexion = new Connexion(this);
            this.Hide();  // Cacher MainForm
            connexion.ShowDialog();  // Afficher Connexion et attendre sa fermeture
            this.Show();  // Rendre MainForm visible après la fermeture de Connexion
        }

        // Ouvrir Page1
        private void buttonOpenPage1_Click(object sender, EventArgs e)
        {
            Page1 page1 = new Page1(this);
            this.Hide();  // Cacher MainForm
            page1.ShowDialog();  // Afficher Page1 et attendre sa fermeture
            this.Show();  // Rendre MainForm visible après la fermeture de Page1
        }

        // Accéder aux données partagées
        public string GetUserData()
        {
            return login;
        }

        public void SetUserData(string newData)
        {
            login = newData;
        } 

        private void AfficherAffectation()
        {
            // Afficher les affectations
            string[] listAffectation = db.listeAffectation();

            for (int i = 0; i < listAffectation.Length; i++)
            {
                listBoxAffectation.Items.Add(listAffectation[i]);
            }

        }

        private void btRaffraichir_Click(object sender, EventArgs e)
        {
            listBoxAffectation.Items.Clear(); // Effacer les affectations
            AfficherAffectation(); // Rafraîchir les affectations
        }

        private void clickListeAffectation(object sender, EventArgs e)
        {
            // Afficher les détails de l'affectation sélectionnée
            string selectedAffectation = listBoxAffectation.SelectedItem.ToString();
            string[] detailsAffectation = db.detailsAffectation(selectedAffectation);

            // Afficher les détails de l'affectation
            MessageBox.Show("Tag : " + detailsAffectation[0] + "\n" 
                + "Nom : " + detailsAffectation[1] + "\n" 
                + "Prenom : " + detailsAffectation[2] + "\n"
                + "Compagnie :" + detailsAffectation[3] + "\n" 
                + "Numero de plaque : " + detailsAffectation[4] + "\n"
                + "Numero de casier : " + detailsAffectation[5] + "\n" 
                + "Date d'attribution : " + detailsAffectation[6] + "\n" 
                + "Date de fin d'attribution : " + detailsAffectation[7]);
        }
    }
}
