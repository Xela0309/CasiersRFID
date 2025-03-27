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
    public partial class logout : Form
    {
        MainForm mainform;
        public logout(MainForm form)
        {
            InitializeComponent();
            mainform = form;
            affichageInfo();
        }
        private void affichageInfo()
        {
            lbLogin.Text = mainform.GetLogin();

            if (mainform.GetRole() == "admin")
            {
                lbRole.Text = "Administrateur";
            }
            else
            {
                lbRole.Text = "Utilisateur";
            }
        }
    }
}
