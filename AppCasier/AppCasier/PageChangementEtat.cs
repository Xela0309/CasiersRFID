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
    public partial class PageChangementEtat : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        MainForm mainform;
        public PageChangementEtat(MainForm form)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Empêcher le redimensionnement de la fenêtre
            InitializeComponent();
            db.OpenConnection();
            mainform = form;
            affichageTag();

        }

        private void affichageTag()
        {

            string[] liste = db.recupTagPO();

            for (int i = 0; i < liste.Length; i++)
            {
                cbTag.Items.Add(liste[i]);
            }
        }

        private void cbTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbEtat.Text = "";
            lbEtat.Text += db.getEtatTag(cbTag.Text);
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            db.updateTag(cbTag.Text, lbEtat.Text);
            MessageBox.Show("Changement d'état effectué !");
            lbEtat.Text = "";
            lbEtat.Text += db.getEtatTag(cbTag.Text);
        }


    }
}
