using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCasier
{
    public partial class PageAjoutVisiteur : Form
    {
        MainForm mainform;
        DatabaseConnection db = new DatabaseConnection();
        PlaqueInfo pays ;
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
            if (tbNom.Text == "" || tbPrenom.Text == "" || tbCompagnie.Text == "" || tbPlaque.Text == "" || cbPays.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs comme demandé !");
            }
            else
            {
                // Verifier si la plaque est valide encomparant avec le regex
                if(!Regex.IsMatch(tbPlaque.Text, pays.Regex))
                {
                    MessageBox.Show("La plaque doit être sous la forme demandée !");
                    return;
                }
                else if (db.verifyVisiteur(tbNom.Text, tbPrenom.Text))
                {
                    MessageBox.Show("Le visiteur existe déjà !");
                    return;
                }
                else
                {
                    

                    if (db.ajouterVisiteur(tbNom.Text, tbPrenom.Text, tbPlaque.Text, tbCompagnie.Text,cbPays.Text))
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
            cbPays.Items.Add("Autre");
        }

        private void ChangementPays(object sender, EventArgs e)
        {
            // Verifier le pays selectionné
            switch (cbPays.Text)
            {
                case "France":
                    pbPays.Image = Properties.Resources.france;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.France].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.France].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.France].Exemple;
                    break;
                case "Allemagne":
                    pbPays.Image = Properties.Resources.allemagne;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Allemagne].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Allemagne].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Allemagne].Exemple;
                    break;
                case "Belgique":
                    pbPays.Image = Properties.Resources.belgique;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Belgique].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Belgique].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Belgique].Exemple;
                    break;
                case "Suisse":
                    pbPays.Image = Properties.Resources.suisse;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Suisse].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Suisse].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Suisse].Exemple;
                    break;
                case "Luxembourg":
                    pbPays.Image = Properties.Resources.luxembourg;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Luxembourg].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Luxembourg].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Luxembourg].Exemple;
                    break;
                case "Espagne":
                    pbPays.Image = Properties.Resources.espagne;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Espagne].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Espagne].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Espagne].Exemple;
                    break;
                case "Italie":
                    pbPays.Image = Properties.Resources.italie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Italie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Italie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Italie].Exemple;
                    break;
                case "Portugal":                    
                    pbPays.Image = Properties.Resources.portugal;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Portugal].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Portugal].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Portugal].Exemple;
                    MessageBox.Show(cbPays.Text);
                    break;
                case "Royaume-Uni":
                    pbPays.Image = Properties.Resources.uk;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.RoyaumeUni].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.RoyaumeUni].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.RoyaumeUni].Exemple;
                    break;
                case "Irlande":
                    pbPays.Image = Properties.Resources.irlande;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Irlande].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Irlande].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Irlande].Exemple;
                    break;
                case "Pays-Bas":
                    pbPays.Image = Properties.Resources.paysbas;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.PaysBas].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.PaysBas].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.PaysBas].Exemple;
                    break;
                case "Danemark":
                    pbPays.Image = Properties.Resources.danemark;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Danemark].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Danemark].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Danemark].Exemple;
                    break;
                case "Suède":
                    pbPays.Image = Properties.Resources.suede;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Suede].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Suede].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Suede].Exemple;
                    break;
                case "Finlande":
                    pbPays.Image = Properties.Resources.finlande;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Finlande].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Finlande].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Finlande].Exemple;
                    break;
                case "Autriche":
                    pbPays.Image = Properties.Resources.autriche;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Autriche].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Autriche].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Autriche].Exemple;
                    break;
                case "République Tchèque":
                    pbPays.Image = Properties.Resources.tchequie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Tchequie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Tchequie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Tchequie].Exemple;
                    break;
                case "Slovénie":
                    pbPays.Image = Properties.Resources.slovenie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Slovenie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Slovenie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Slovenie].Exemple;
                    break;
                case "Slovaquie":
                    pbPays.Image = Properties.Resources.slovaquie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Slovaquie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Slovaquie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Slovaquie].Exemple;
                    break;
                case "Hongrie":
                    pbPays.Image = Properties.Resources.hongrie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Hongrie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Hongrie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Hongrie].Exemple;
                    break;
                case "Roumanie":
                    pbPays.Image = Properties.Resources.roumanie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Roumanie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Roumanie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Roumanie].Exemple;
                    break;
                case "Bulgarie":
                    pbPays.Image = Properties.Resources.bulgarie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Bulgarie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Bulgarie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Bulgarie].Exemple;
                    break;
                case "Croatie":
                    pbPays.Image = Properties.Resources.croatie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Croatie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Croatie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Croatie].Exemple;
                    break;
                case "Estonie":
                    pbPays.Image = Properties.Resources.estonie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Estonie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Estonie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Estonie].Exemple;
                    break;
                case "Lettonie":
                    pbPays.Image = Properties.Resources.lettonie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Lettonie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Lettonie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Lettonie].Exemple;
                    break;
                case "Lituanie":
                    pbPays.Image = Properties.Resources.lituanie;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Lituanie].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Lituanie].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Lituanie].Exemple;
                    break;
                case "Chypre":
                    pbPays.Image = Properties.Resources.chypre;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Chypre].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Chypre].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Chypre].Exemple;
                    break;
                case "Malte":
                    pbPays.Image = Properties.Resources.malte;
                    pays = new PlaqueInfo(PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Malte].Regex, PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Malte].Exemple);
                    lbPlaqueEx.Text = "Ex : " + PlaquesEuropeennes.InfosPlaques[PaysEuropeen.Malte].Exemple;
                    break;
                case "Autre":
                    pbPays.Image = Properties.Resources.autre;
                    lbPlaqueEx.Text = "";
                    break;

            }
        }
    }
}
