using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace AppCasier
{

    public partial class MainForm : Form
    {

        private string login = ""; // Variable conservée
        private string role = ""; // Variable conservée
        DatabaseConnection db = new DatabaseConnection(); // Instance de la classe DatabaseConnection
        MenuHamburger menu = new MenuHamburger(); // Instance de la classe Menu

        public MainForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Empêcher le redimensionnement de la fenêtre
            OpenConnexion(); // Ouvrir Page de Connexion
            if (login == "") // Si l'utilisateur n'est pas connecté
            {
                // Fermer l'application
                Application.Exit();
            }
            else
            {
                db.OpenConnection(); // Ouvrir la connexion à la base de données
                affichageGeneral();
                
            }
        }

        // Ouvrir Page de Connexion

        public void affichageGeneral()
        {
            InitializeComponent();
            afficherAffectation(); // Afficher les affectations
            affichageSelection();
            menu.InitializeHamburgerMenu(this); // Initialiser le menu
            menu.SetMainForm(this); // Mettre à jour le formulaire principal
            affichageDatePasser();
        }
        private void OpenConnexion()
        {
            Connexion connexion = new Connexion(this);
            this.Hide();  // Cacher MainForm
            connexion.ShowDialog();  // Afficher Connexion et attendre sa fermeture
            this.Show();  // Rendre MainForm visible après la fermeture de Connexion
        }

        // Accéder aux données partagées
        public string GetLogin()
        {
            return login;
        }

        public void SetLogin(string newData)
        {
            login = newData;
        }

        public string GetRole()
        {
            return role;
        }

        public void SetRole(string newData)
        {
            role = newData;
        }

        public void afficherAffectation()
        {

            listBoxAffectation.Items.Clear(); // Effacer les affectations

            // Afficher les affectations
            string[] listAffectation = db.listeAffectation();

            for (int i = 0; i < listAffectation.Length; i++)
            {
                listBoxAffectation.Items.Add("Casier n°" + listAffectation[i]);
            }

            affichageSelection();

        }

        public void Maj_Affichage()
        {
            afficherAffectation(); // Rafraîchir les affectations
            affichageSelection(); // Rafraîchir les sélections
        }

        private void clickListeAffectation(object sender, EventArgs e)
        {
            // Gerer si il nèy a pas d'affectation
            if (listBoxAffectation.SelectedItem == null)
            {
                return;
            }

            // Selectionner le numero du casier
            string selectedAffectation = listBoxAffectation.SelectedItem.ToString().Substring(9);
            string[] detailsAffectation = db.detailsAffectation(selectedAffectation);

            // Afficher les détails de l'affectation
            PageAffichageInterface pageAffichage = new PageAffichageInterface(detailsAffectation,this);
            pageAffichage.ShowDialog();

        }

        private void affichageSelection()
        {
            // Supprimer les éléments de la liste
            cbAffectationNom.Items.Clear();
            cbAffectationCasier.Items.Clear();
            cbAffectationTag.Items.Clear();

            cbAffectationCasier.Text = "";
            cbAffectationNom.Text = "";
            cbAffectationTag.Text = "";

            // Récupérer les détails de l'affectation sélectionnée
            string[] Nom = db.recupNomPrenomVisiteurNonAffecté();
            string[] Casier = db.recupNumCasierNonAffecté();
            string[] Tag = db.recupNumTagNonAffecté();

            // Afficher les détails de l'affectation
            for (int i = 0; i < Nom.Length; i++)
            {
                cbAffectationNom.Items.Add(Nom[i]);
            }

            for (int i = 0; i < Casier.Length; i++)
            {
                cbAffectationCasier.Items.Add(Casier[i]);
            }

            for (int i = 0; i < Tag.Length; i++)
            {
                cbAffectationTag.Items.Add(Tag[i]);
            }

        }

        private void btAffectation_Click(object sender, EventArgs e)
        {

            if (cbAffectationTag.SelectedItem == null || cbAffectationNom.SelectedItem == null || cbAffectationCasier.SelectedItem == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs !");
                return;
            }
            else
            {
                if (dtpDateDeb.Value >= dtpDateFin.Value)
                {
                    MessageBox.Show("La date de début doit être inférieure à la date de fin !");
                    return;
                }

                else
                {
                    if (dtpDateDeb.Value < DateTime.Now)
                    {
                        // Recuperer les informations de l'affectation
                        string tag = cbAffectationTag.SelectedItem.ToString();
                        // Recuperer le nom du visiteur
                        string[] nomPrenom = cbAffectationNom.SelectedItem.ToString().Split(' ');
                        string nom = nomPrenom[0];
                        string prenom = nomPrenom[1];
                        string casier = cbAffectationCasier.SelectedItem.ToString();
                        string dateDeb = dtpDateDeb.Value.ToString("yyyy-MM-dd");
                        string dateFin = dtpDateFin.Value.ToString("yyyy-MM-dd");

                        // Ajouter l'affectation
                        if (db.ajouterAffectation(tag, nom,prenom, casier, dateDeb, dateFin))
                        {
                            MessageBox.Show("Affectation ajoutée !");
                            // Mettre à jour l'affichage
                            afficherAffectation();
                            affichageSelection();
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de l'ajout de l'affectation !");
                        }
                    }
                }
            }
        }

        private void FermetureMenuHamburger(object sender, EventArgs e)
        {
            menu.menuOpen = false;
            menu.menuTimer.Start();
        }

        public void FermetureMenu()
        {
            menu.menuOpen = false;
            menu.menuTimer.Start();
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            logout logout = new logout(this);
            logout.ShowDialog();
        }

        private void affichageDatePasser()
        {
            // Recuperer les affectations
            string[] affectation = db.affectationDateLimite();

            // Parcourir les affectations
            for (int i = 0; i < affectation.Length; i++)
            {
                // Recuperer les informations de l'affectation
                string[] detailsAffectation = db.infoAffectation(affectation[i]);

                // Afficher les informations de l'affectation
                verifDate verifDate = new verifDate(detailsAffectation, this);
                verifDate.ShowDialog();

            }
        }
    }
}
