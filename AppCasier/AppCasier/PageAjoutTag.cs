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
        public PageAjoutTag(MainForm form)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Empêcher le redimensionnement de la fenêtre
            InitializeComponent();
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
                // Ajouter le tag à la base de données
                DatabaseConnection db = new DatabaseConnection();
                db.OpenConnection();
                db.ajouterTag(tbTag.Text);
                MessageBox.Show("Tag ajouté avec succès.");
                this.Close(); // Fermer la fenêtre après l'ajout
            }
        }

        private void btSelectTag_Click(object sender, EventArgs e)
        {
            lectureTag lectureTag = new lectureTag();
            lectureTag.ShowDialog(); // Afficher la fenêtre de lecture de tag
        }
    }
}
