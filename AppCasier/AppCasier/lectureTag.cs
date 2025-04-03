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
    public partial class lectureTag : Form
    {
        Lecteur lecteur = new Lecteur("COM8", 9600); // Port et vitesse de communication

        public lectureTag()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Empêcher le redimensionnement de la fenêtre
            InitializeComponent();
        }

        public void lectureTagValide()
        {
            lecteur.OpenPort(); // Ouvrir le port série
            lecteur.lireTag();
            if (lecteur.GetTag() != "")
            {
                lbTag.Text = lecteur.GetTag(); // Afficher le tag lu dans le TextBox
            }
            
        }

        private void lectureTagValide(object sender, EventArgs e)
        {
            lecteur.OpenPort(); // Ouvrir le port série
            lecteur.lireTag();
            if (lecteur.GetTag() != "")
            {
                lbTag.Text = lecteur.GetTag(); // Afficher le tag lu dans le TextBox
            }
        }
    }
}
