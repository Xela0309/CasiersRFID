using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCasier
{
    public partial class PageAffichageInterface : Form
    {
        ChiffrageXOR ch = new ChiffrageXOR("CryptageApplication");
        DatabaseConnection db = new DatabaseConnection(); // Instance de la classe DatabaseConnection
        MainForm mainForm;
        public PageAffichageInterface(string[] detailsAffectation,MainForm form)
        {
            InitializeComponent();
            AffichageInfo(detailsAffectation);
            mainForm = form;

        }

        private void btInfoAffectationFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btInfoAffectationSupprimer_Click(object sender, EventArgs e)
        {
            // Recuperer les informations de l'affectation
            string casier = lbAffectationCasierINFO.Text;


            db.OpenConnection();
            db.supprimerAffectation(casier);
            this.Close();

            // Mettre à jour l'affichage
            mainForm.Maj_Affichage();
        }

        private void AffichageInfo(string[] detailsAffectation)
        {
            lbAffectationTagINFO.Text = detailsAffectation[0];
            lbAffectationNomINFO.Text = ch.Decrypt(detailsAffectation[1]);
            lbAffectationPrenomINFO.Text = ch.Decrypt(detailsAffectation[2]);
            lbAffectationCompagnieINFO.Text = ch.Decrypt(detailsAffectation[3]);
            lbAffectationPlaqueINFO.Text = ch.Decrypt(detailsAffectation[4]);
            lbAffectationCasierINFO.Text = detailsAffectation[5];
            lbAffectationDateDebINFO.Text = detailsAffectation[6];
            lbAffectationDateFinINFO.Text = detailsAffectation[7];

        }

    }
}
