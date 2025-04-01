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
    public partial class pageSupprTag : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        MainForm mainform;
        public pageSupprTag(MainForm form)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Empêcher le redimensionnement de la fenêtre
            InitializeComponent();
            db.OpenConnection();
            mainform = form;
            affichageTag();
        }

        private void affichageTag()
        {

            string[] liste = db.recupNumTagNonAffecté();

            for (int i = 0; i < liste.Length; i++)
            {
                cbTag.Items.Add(liste[i]);
            }
        }

        private void btSuppr_Click(object sender, EventArgs e)
        {
            string tag = cbTag.Text;
            if (db.supprimerTag(tag))
            {
                MessageBox.Show("Tag supprimé !");
                this.Close();
                mainform.Maj_Affichage();
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression du tag !");
            }
        }
    }
}
