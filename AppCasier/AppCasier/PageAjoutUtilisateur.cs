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
    public partial class PageAjoutUtilisateur : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        public PageAjoutUtilisateur()
        {
            InitializeComponent();
            db.OpenConnection();
        }

        private void btAccepter_Click(object sender, EventArgs e)
        {
            if ( tbLogin.Text == "" || tbPassword.Text == "" || cbRole.Text == "" )
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
            else if (db.verifyUtilisateur(tbLogin.Text))
            {
                MessageBox.Show("L'Utilisateur existe déjà !");
                return;
            }
            else
            {

                if (db.ajouterUtilisateur(tbLogin.Text, tbPassword.Text, cbRole.Text))
                {
                    MessageBox.Show("Utilisateur ajouté avec succès");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cet utilisateur existe déja");
                }
            }
        }
    }
}
