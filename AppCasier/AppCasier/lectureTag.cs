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
        Lecteur m_lecteur;

        public lectureTag(Lecteur lecteur)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Empêcher le redimensionnement de la fenêtre
            InitializeComponent();
            m_lecteur = lecteur;


        }

        private void lectureTagValide(object sender, EventArgs e)
        {
            
            if (!m_lecteur.lireTag())
            {
                lbConfirmation.Visible = false; // Cacher le picto de tag
                lbRefus.Text = "Tag non valide"; // Afficher le message d'erreur
            }
            else
            {
                if (m_lecteur.GetTag() != "")
                {
                    lbTag.Text = m_lecteur.GetTag(); // Afficher le tag lu dans le TextBox
                    lbConfirmation.Visible = true; // Afficher le picto de tag
                }
            }
        }
    }
}
