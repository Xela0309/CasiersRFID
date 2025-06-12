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
    public partial class PageAjoutTag : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        Lecteur lecteur;
        MainForm mainform;
        public PageAjoutTag(MainForm form, Lecteur m_lecteur)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Empêcher le redimensionnement de la fenêtre
            InitializeComponent();
            db.OpenConnection();
            lecteur = m_lecteur; // Récupérer l'instance de Lecteur
            mainform = form; // Récupérer l'instance de MainForm
            
        }

        private void btAjoutTag_Click(object sender, EventArgs e)
        {
            if (tbTag.Text == "")
            {
                MessageBox.Show("Veuillez entrer un tag valide.");
                return;
            }
            else
            {

                if (db.verifTag(tbTag.Text))
                {
                    MessageBox.Show("Le tag existe déjà.");
                    return;
                }
                else
                {
                    // Ajouter le tag à la base de données
                    if (db.ajouterTag(tbTag.Text))
                    {
                        MessageBox.Show("Tag ajouté avec succès.");
                        this.Close(); // Fermer la fenêtre après l'ajout
                        mainform.Maj_Affichage();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout du tag.");
                    }
                }
            }
        }

        private void btSelectTag_Click(object sender, EventArgs e)
        {
            lecteur.SetTag(""); // Réinitialiser le tag
            lectureTag lectureTag = new lectureTag(lecteur);
            lectureTag.ShowDialog(); // Afficher la fenêtre de lecture de tag
            if (lecteur.GetTag() != "")
            {
                tbTag.Text = lecteur.GetTag(); // Récupérer le tag lu
            }
        }
    }
}
