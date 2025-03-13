using System;
using System.Windows.Forms;

namespace AppCasier
{
    public partial class Page1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private MainForm mainForm; // Référence vers MainForm
        private Label labelData;
        private Button buttonSaveData;
        private Button buttonBack;
        private TextBox textBoxInput;

        public Page1(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            labelData.Text = mainForm.GetUserData(); // Affiche les infos de MainForm
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            mainForm.SetUserData(textBoxInput.Text); // Met à jour les données
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme la page actuelle pour revenir à `MainForm`
        }

        private void InitializeComponent()
        {
            this.labelData = new Label();
            this.buttonSaveData = new Button();
            this.buttonBack = new Button();
            this.textBoxInput = new TextBox();
            this.SuspendLayout();

            // labelData
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(50, 50);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(200, 20);
            this.labelData.TabIndex = 0;
            this.labelData.Text = "Bienvenue sur Page 1"; // Texte initial

            // textBoxInput
            this.textBoxInput.Location = new System.Drawing.Point(50, 100);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(200, 26);
            this.textBoxInput.TabIndex = 1;

            // buttonSaveData
            this.buttonSaveData.Location = new System.Drawing.Point(50, 150);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Size = new System.Drawing.Size(100, 30);
            this.buttonSaveData.TabIndex = 2;
            this.buttonSaveData.Text = "Save Data";
            this.buttonSaveData.UseVisualStyleBackColor = true;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);

            // buttonBack
            this.buttonBack.Location = new System.Drawing.Point(150, 150);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(100, 30);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);

            // Page1
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonSaveData);
            this.Controls.Add(this.buttonBack);
            this.Name = "Page1";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
