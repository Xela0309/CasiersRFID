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
    public partial class Page1 : Form
    {
        public Page1()
        {
            InitializeComponent();
            InitializeHamburgerMenu();
        }

        private void labelData_Click(object sender, EventArgs e)
        {

        }

            private bool menuOpen = false;
            private Timer menuTimer;


            private void InitializeHamburgerMenu()
            {
                // Panel du menu latéral
                Panel menuPanel = new Panel
                {
                    Size = new Size(200, this.Height),
                    BackColor = Color.FromArgb(50, 50, 50),
                    Location = new Point(-200, 0) // Caché au début
                };
                this.Controls.Add(menuPanel);

                // Bouton Hamburger
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
                btnHamburger.Click += (s, e) => ToggleMenu(menuPanel);
                this.Controls.Add(btnHamburger);

                // Boutons du menu
                string[] menuItems = { "Accueil", "Paramètres", "Aide", "Quitter" };
                int yOffset = 50;

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
                menuTimer.Tick += (s, e) => AnimateMenu(menuPanel);
            }

            private void ToggleMenu(Panel menuPanel)
            {
                menuOpen = !menuOpen;
                menuTimer.Start();
            }

            private void AnimateMenu(Panel menuPanel)
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
                MessageBox.Show($"Vous avez cliqué sur {menuItem}");

                if (menuItem == "Quitter")
                {
                    Application.Exit();
                }
            }
        }
    }


