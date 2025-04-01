using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCasier
{
    internal class MenuHamburger
    {
        public bool menuOpen = false;
        public Timer menuTimer;
        private Panel menuPanel;

        string[] menuItemsAdmin = { "Ajouter Utilisateur", "Ajouter Visiteur", "Ajout Tag", "Supprimer Utilisateur", "Supprimer Visiteur", "Supprimer Tag" };
        string[] menuItemsUser = { "Ajouter Visiteur", "Ajout Tag", "Supprimer Visiteur", "Supprimer Tag" };

        MainForm mainform;
        public MenuHamburger()
        {}

        public void InitializeHamburgerMenu(MainForm form)
        {
            // Création du panel latéral (menu)
            menuPanel = new Panel
            {
                Size = new Size(200, form.Height),
                BackColor = Color.FromArgb(50, 50, 50),
                Location = new Point(-200, 0) // Caché au départ
            };
            form.Controls.Add(menuPanel);

            // Bouton Hamburger (☰)
            Button btnHamburger = new Button
            {
                Text = "☰",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Size = new Size(50, 40),
                Location = new Point(10, 10),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnHamburger.Click += (s, e) => ToggleMenu();
            form.Controls.Add(btnHamburger);

            // Boutons du menu
            int yOffset = 10;

            string[] menuItems;

            if (form.GetRole() == "admin")
            {
                menuItems = menuItemsAdmin;
            }
            else
            {
                menuItems = menuItemsUser;
            }

            foreach (string item in menuItems)
            {
                Button menuButton = new Button
                {
                    Text = item,
                    Size = new Size(180, 40),
                    Location = new Point(10, yOffset),
                    BackColor = Color.DarkGray,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                menuButton.Click += (s, e) => MenuButtonClick(item);
                menuPanel.Controls.Add(menuButton);
                yOffset += 50;
            }

            // Timer pour l'animation
            menuTimer = new Timer();
            menuTimer.Interval = 10;
            menuTimer.Tick += AnimateMenu;
        }
        private void ToggleMenu()
        {
            menuPanel.BringToFront();
            menuOpen = !menuOpen;
            menuTimer.Start();
        }

        private void AnimateMenu(object sender, EventArgs e)
        {
            int targetX = menuOpen ? 0 : -200;
            int step = menuOpen ? 20 : -20;

            if ((menuOpen && menuPanel.Left < targetX) || (!menuOpen && menuPanel.Left > targetX))
            {
                menuPanel.Left += step;
            }
            else
            {
                menuPanel.Left = targetX;
                menuTimer.Stop();
            }
        }

        private void MenuButtonClick(string menuItem)
        {

            if (menuItem == "Ajouter Utilisateur")
            {
                // Ouvrir la page d'ajout d'utilisateur
                PageAjoutUtilisateur page = new PageAjoutUtilisateur();
                page.ShowDialog();
            }
            else if (menuItem == "Ajouter Visiteur")
            {
                // Ouvrir la page d'ajout de visiteur
                PageAjoutVisiteur page = new PageAjoutVisiteur(mainform);
                page.ShowDialog();
            }
            else if (menuItem == "Ajout Tag")
            {
                // Ouvrir la page d'ajout de tag
                PageAjoutTag page = new PageAjoutTag(mainform);
                page.ShowDialog();
            }
            else if (menuItem == "Supprimer Utilisateur")
            {
                // Ouvrir la page de suppression d'utilisateur
                pageSupprUtilisateur page = new pageSupprUtilisateur();
                page.ShowDialog();
            }
            else if (menuItem == "Supprimer Visiteur")
            {
                // Ouvrir la page de suppression de visiteur
                pageSupprVisiteur page = new pageSupprVisiteur(mainform);
                page.ShowDialog();
            }
            else if (menuItem == "Supprimer Tag")
            {
                // Ouvrir la page de suppression de tag
                pageSupprTag page = new pageSupprTag(mainform);
                page.ShowDialog();
            }
            else
            {
                // Ferme automatiquement le menu après un clic
                menuOpen = false;
                menuTimer.Start();
            }
        }

        public void SetMainForm(MainForm form)
        {
            mainform = form;
        }
    }
}
