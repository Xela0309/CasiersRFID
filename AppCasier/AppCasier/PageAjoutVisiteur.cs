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
                    db.OpenConnection();
                    db.ajouterVisiteur(tbNom.Text, tbPrenom.Text, tbPlaque.Text, tbCompagnie.Text);
                    MessageBox.Show("Visiteur ajouté avec succès !");
                    this.Close();
                    // Mettre à jour l'affichage
                    mainform.Maj_Affichage();

                }
            }
        }
    }
}
