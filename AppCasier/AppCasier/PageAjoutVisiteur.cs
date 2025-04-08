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
    public partial class PageAjoutVisiteur : Form
    {
        MainForm mainform;
        DatabaseConnection db = new DatabaseConnection();
        public PageAjoutVisiteur(MainForm form)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Empêcher le redimensionnement de la fenêtre
            mainform = form;
            InitializeComponent();
            afficherPays(); // Afficher les pays
            db.OpenConnection();
        }

        private void btCreerVisiteur_Click(object sender, EventArgs e)
        {
            // Verifier si les champs sont remplis
            if (tbNom.Text == "" || tbPrenom.Text == "" || tbCompagnie.Text == "" || tbPlaque.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs comme demandé !");
            }
            else
            {
                // Verifier si la plaque est valide Ex: AA-111-AA
                if (tbPlaque.Text.Length != 9 || tbPlaque.Text[2] != '-' || tbPlaque.Text[6] != '-' || !char.IsLetter(tbPlaque.Text[0]) || !char.IsLetter(tbPlaque.Text[1]) || !char.IsDigit(tbPlaque.Text[3]) || !char.IsDigit(tbPlaque.Text[4]) || !char.IsDigit(tbPlaque.Text[5]) || !char.IsLetter(tbPlaque.Text[7]) || !char.IsLetter(tbPlaque.Text[8]))
                {
                    MessageBox.Show("La plaque doit être sous la forme AA-123-BB !");
                    return;
                }
                else if (db.verifyVisiteur(tbNom.Text, tbPrenom.Text))
                {
                    MessageBox.Show("Le visiteur existe déjà !");
                    return;
                }
                else
                {
                    

                    if (db.ajouterVisiteur(tbNom.Text, tbPrenom.Text, tbPlaque.Text, tbCompagnie.Text))
                    {
                        MessageBox.Show("Visiteur ajouté avec succès !");
                        this.Close();
                        // Mettre à jour l'affichage
                        mainform.Maj_Affichage();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout du visiteur !");
                        return;
                    }
                }
            }
        }

        private void afficherPays()
        {
            // Ajouter les pays à la liste
            cbPays.Items.Add("France");
            cbPays.Items.Add("Allemagne");
            cbPays.Items.Add("Belgique");
            cbPays.Items.Add("Suisse");
            cbPays.Items.Add("Luxembourg");
            cbPays.Items.Add("Espagne");
            cbPays.Items.Add("Italie");
            cbPays.Items.Add("Portugal");
            cbPays.Items.Add("Royaume-Uni");
            cbPays.Items.Add("Irlande");
            cbPays.Items.Add("Pays-Bas");
            cbPays.Items.Add("Danemark");
            cbPays.Items.Add("Suède");
            cbPays.Items.Add("Finlande");
            cbPays.Items.Add("Autriche");
            cbPays.Items.Add("République Tchèque");
            cbPays.Items.Add("Slovénie");
            cbPays.Items.Add("Slovaquie");
            cbPays.Items.Add("Hongrie");
            cbPays.Items.Add("Roumanie");
            cbPays.Items.Add("Bulgarie");
            cbPays.Items.Add("Croatie");
            cbPays.Items.Add("Estonie");
            cbPays.Items.Add("Lettonie");
            cbPays.Items.Add("Lituanie");
            cbPays.Items.Add("Chypre");
            cbPays.Items.Add("Malte");
        }

        private void ChangementPays(object sender, EventArgs e)
        {
            // Verifier le pays selectionné
            switch (cbPays.Text)
            {
                case "France":
                    // changer la photo de pbPays
                    pbPays.Image = Properties.Resources.france;
                    break;
                case "Allemagne":
                    pbPays.Image = Properties.Resources.allemagne;
                    break;
                case "Belgique":
                    pbPays.Image = Properties.Resources.belgique;
                    break;
                case "Suisse":
                    pbPays.Image = Properties.Resources.suisse;
                    break;
                case "Luxembourg":
                    pbPays.Image = Properties.Resources.luxembourg;
                    break;
                case "Espagne":
                    pbPays.Image = Properties.Resources.espagne;
                    break;
                case "Italie":
                    pbPays.Image = Properties.Resources.italie;
                    break;
                case "Portugal":
                    pbPays.Image = Properties.Resources.portugal;
                    break;
                case "Royaume-Uni":
                    pbPays.Image = Properties.Resources.uk;
                    break;
                case "Irlande":
                    pbPays.Image = Properties.Resources.irlande;
                    break;
                case "Pays-Bas":
                    pbPays.Image = Properties.Resources.paysbas;
                    break;
                case "Danemark":
                    pbPays.Image = Properties.Resources.danemark;
                    break;
                case "Suède":
                    pbPays.Image = Properties.Resources.suede;
                    break;
                case "Finlande":
                    pbPays.Image = Properties.Resources.finlande;
                    break;
                case "Autriche":
                    pbPays.Image = Properties.Resources.autriche;
                    break;
                case "République Tchèque":
                    pbPays.Image = Properties.Resources.tchequie;
                    break;
                case "Slovénie":
                    pbPays.Image = Properties.Resources.slovenie;
                    break;
                case "Slovaquie":
                    pbPays.Image = Properties.Resources.slovaquie;
                    break;
                case "Hongrie":
                    pbPays.Image = Properties.Resources.hongrie;
                    break;
                case "Roumanie":
                    pbPays.Image = Properties.Resources.roumanie;
                    break;
                case "Bulgarie":
                    pbPays.Image = Properties.Resources.bulgarie;
                    break;
                case "Croatie":
                    pbPays.Image = Properties.Resources.croatie;
                    break;
                case "Estonie":
                    pbPays.Image = Properties.Resources.estonie;
                    break;
                case "Lettonie":
                    pbPays.Image = Properties.Resources.lettonie;
                    break;
                case "Lituanie":
                    pbPays.Image = Properties.Resources.lituanie;
                    break;
                case "Chypre":
                    pbPays.Image = Properties.Resources.chypre;
                    break;
                case "Malte":
                    pbPays.Image = Properties.Resources.malte;
                    break;

            }
        }
    }
}
