using System;
using System.Windows.Forms;

namespace AppCasier
{
    public partial class MainForm : Form
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

        private void InitializeComponent()
        {
            this.cbAffectationTag = new System.Windows.Forms.ComboBox();
            this.cbAffectationNom = new System.Windows.Forms.ComboBox();
            this.cbAffectationCasier = new System.Windows.Forms.ComboBox();
            this.listBoxAffectation = new System.Windows.Forms.ListBox();
            this.lbListeAffectation = new System.Windows.Forms.Label();
            this.gpbAffectation = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAffectation = new System.Windows.Forms.Label();
            this.btAffectation = new System.Windows.Forms.Button();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDeb = new System.Windows.Forms.DateTimePicker();
            this.lbConnctedTo = new System.Windows.Forms.Label();
            this.lbLoginActuel = new System.Windows.Forms.Label();
            this.btLogout = new System.Windows.Forms.Button();
            this.gpbAffectation.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAffectationTag
            // 
            this.cbAffectationTag.FormattingEnabled = true;
            this.cbAffectationTag.Location = new System.Drawing.Point(319, 61);
            this.cbAffectationTag.Name = "cbAffectationTag";
            this.cbAffectationTag.Size = new System.Drawing.Size(153, 21);
            this.cbAffectationTag.TabIndex = 6;
            // 
            // cbAffectationNom
            // 
            this.cbAffectationNom.FormattingEnabled = true;
            this.cbAffectationNom.Location = new System.Drawing.Point(23, 61);
            this.cbAffectationNom.Name = "cbAffectationNom";
            this.cbAffectationNom.Size = new System.Drawing.Size(121, 21);
            this.cbAffectationNom.TabIndex = 7;
            // 
            // cbAffectationCasier
            // 
            this.cbAffectationCasier.FormattingEnabled = true;
            this.cbAffectationCasier.Location = new System.Drawing.Point(172, 61);
            this.cbAffectationCasier.Name = "cbAffectationCasier";
            this.cbAffectationCasier.Size = new System.Drawing.Size(121, 21);
            this.cbAffectationCasier.TabIndex = 8;
            // 
            // listBoxAffectation
            // 
            this.listBoxAffectation.FormattingEnabled = true;
            this.listBoxAffectation.Location = new System.Drawing.Point(82, 72);
            this.listBoxAffectation.Name = "listBoxAffectation";
            this.listBoxAffectation.Size = new System.Drawing.Size(119, 121);
            this.listBoxAffectation.TabIndex = 9;
            this.listBoxAffectation.Click += new System.EventHandler(this.clickListeAffectation);
            // 
            // lbListeAffectation
            // 
            this.lbListeAffectation.AutoSize = true;
            this.lbListeAffectation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListeAffectation.Location = new System.Drawing.Point(9, 50);
            this.lbListeAffectation.Name = "lbListeAffectation";
            this.lbListeAffectation.Size = new System.Drawing.Size(273, 13);
            this.lbListeAffectation.TabIndex = 10;
            this.lbListeAffectation.Text = "Liste des casiers occupé par une Affecttation :";
            // 
            // gpbAffectation
            // 
            this.gpbAffectation.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.gpbAffectation.Controls.Add(this.label3);
            this.gpbAffectation.Controls.Add(this.label2);
            this.gpbAffectation.Controls.Add(this.label1);
            this.gpbAffectation.Controls.Add(this.lbAffectation);
            this.gpbAffectation.Controls.Add(this.btAffectation);
            this.gpbAffectation.Controls.Add(this.dtpDateFin);
            this.gpbAffectation.Controls.Add(this.dtpDateDeb);
            this.gpbAffectation.Controls.Add(this.cbAffectationNom);
            this.gpbAffectation.Controls.Add(this.cbAffectationCasier);
            this.gpbAffectation.Controls.Add(this.cbAffectationTag);
            this.gpbAffectation.Location = new System.Drawing.Point(11, 219);
            this.gpbAffectation.Name = "gpbAffectation";
            this.gpbAffectation.Size = new System.Drawing.Size(494, 224);
            this.gpbAffectation.TabIndex = 12;
            this.gpbAffectation.TabStop = false;
            this.gpbAffectation.Enter += new System.EventHandler(this.FermetureMenuHamburger);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Visiteur :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(169, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Casier :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tag :";
            // 
            // lbAffectation
            // 
            this.lbAffectation.AutoSize = true;
            this.lbAffectation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAffectation.Location = new System.Drawing.Point(11, 16);
            this.lbAffectation.Name = "lbAffectation";
            this.lbAffectation.Size = new System.Drawing.Size(318, 13);
            this.lbAffectation.TabIndex = 11;
            this.lbAffectation.Text = "Selectionnez les éléments à ajouter dans l\'affectation :";
            // 
            // btAffectation
            // 
            this.btAffectation.Location = new System.Drawing.Point(213, 177);
            this.btAffectation.Name = "btAffectation";
            this.btAffectation.Size = new System.Drawing.Size(80, 27);
            this.btAffectation.TabIndex = 11;
            this.btAffectation.Text = "Affectation";
            this.btAffectation.UseVisualStyleBackColor = true;
            this.btAffectation.Click += new System.EventHandler(this.btAffectation_Click);
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.Location = new System.Drawing.Point(288, 120);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(184, 20);
            this.dtpDateFin.TabIndex = 10;
            // 
            // dtpDateDeb
            // 
            this.dtpDateDeb.Location = new System.Drawing.Point(26, 120);
            this.dtpDateDeb.Name = "dtpDateDeb";
            this.dtpDateDeb.Size = new System.Drawing.Size(193, 20);
            this.dtpDateDeb.TabIndex = 9;
            // 
            // lbConnctedTo
            // 
            this.lbConnctedTo.AutoSize = true;
            this.lbConnctedTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConnctedTo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbConnctedTo.Location = new System.Drawing.Point(369, 50);
            this.lbConnctedTo.Name = "lbConnctedTo";
            this.lbConnctedTo.Size = new System.Drawing.Size(138, 13);
            this.lbConnctedTo.TabIndex = 13;
            this.lbConnctedTo.Text = "Connecté en tant que :";
            // 
            // lbLoginActuel
            // 
            this.lbLoginActuel.AutoSize = true;
            this.lbLoginActuel.BackColor = System.Drawing.SystemColors.Info;
            this.lbLoginActuel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoginActuel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLoginActuel.Location = new System.Drawing.Point(387, 72);
            this.lbLoginActuel.Name = "lbLoginActuel";
            this.lbLoginActuel.Size = new System.Drawing.Size(34, 13);
            this.lbLoginActuel.TabIndex = 14;
            this.lbLoginActuel.Text = "login";
            // 
            // btLogout
            // 
            this.btLogout.Location = new System.Drawing.Point(390, 135);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(61, 48);
            this.btLogout.TabIndex = 15;
            this.btLogout.Text = "Se déconnecter";
            this.btLogout.UseVisualStyleBackColor = true;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(519, 450);
            this.Controls.Add(this.btLogout);
            this.Controls.Add(this.lbListeAffectation);
            this.Controls.Add(this.listBoxAffectation);
            this.Controls.Add(this.lbLoginActuel);
            this.Controls.Add(this.lbConnctedTo);
            this.Controls.Add(this.gpbAffectation);
            this.Name = "MainForm";
            this.Text = "AppCasier";
            this.Click += new System.EventHandler(this.FermetureMenuHamburger);
            this.gpbAffectation.ResumeLayout(false);
            this.gpbAffectation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ComboBox cbAffectationTag;
        private ComboBox cbAffectationNom;
        private ComboBox cbAffectationCasier;
        private ListBox listBoxAffectation;
        private Label lbListeAffectation;
        private GroupBox gpbAffectation;
        private Label lbAffectation;
        private Button btAffectation;
        private DateTimePicker dtpDateFin;
        private DateTimePicker dtpDateDeb;
        private Label lbConnctedTo;
        private Label lbLoginActuel;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btLogout;
    }
}
