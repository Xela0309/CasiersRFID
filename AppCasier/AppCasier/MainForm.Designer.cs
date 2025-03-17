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
            this.btAddUtilisateur = new System.Windows.Forms.Button();
            this.btSupprUtilisateur = new System.Windows.Forms.Button();
            this.btAddTag = new System.Windows.Forms.Button();
            this.btAddVisiteur = new System.Windows.Forms.Button();
            this.btSupprVisiteur = new System.Windows.Forms.Button();
            this.btSupprTag = new System.Windows.Forms.Button();
            this.cbAffectationTag = new System.Windows.Forms.ComboBox();
            this.cbAffectationNom = new System.Windows.Forms.ComboBox();
            this.cbAffectationCasier = new System.Windows.Forms.ComboBox();
            this.listBoxAffectation = new System.Windows.Forms.ListBox();
            this.lbListeAffectation = new System.Windows.Forms.Label();
            this.gpbListeAffectation = new System.Windows.Forms.GroupBox();
            this.btRaffraichir = new System.Windows.Forms.Button();
            this.gpbAffectation = new System.Windows.Forms.GroupBox();
            this.lbAffectation = new System.Windows.Forms.Label();
            this.btAffectation = new System.Windows.Forms.Button();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDeb = new System.Windows.Forms.DateTimePicker();
            this.gpbListeAffectation.SuspendLayout();
            this.gpbAffectation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAddUtilisateur
            // 
            this.btAddUtilisateur.Location = new System.Drawing.Point(12, 12);
            this.btAddUtilisateur.Name = "btAddUtilisateur";
            this.btAddUtilisateur.Size = new System.Drawing.Size(100, 36);
            this.btAddUtilisateur.TabIndex = 0;
            this.btAddUtilisateur.Text = "Ajouter Utilisateur";
            this.btAddUtilisateur.Click += new System.EventHandler(this.buttonOpenPage1_Click);
            // 
            // btSupprUtilisateur
            // 
            this.btSupprUtilisateur.Location = new System.Drawing.Point(418, 12);
            this.btSupprUtilisateur.Name = "btSupprUtilisateur";
            this.btSupprUtilisateur.Size = new System.Drawing.Size(100, 36);
            this.btSupprUtilisateur.TabIndex = 1;
            this.btSupprUtilisateur.Text = "Supprimer Utilisateur";
            // 
            // btAddTag
            // 
            this.btAddTag.Location = new System.Drawing.Point(281, 12);
            this.btAddTag.Name = "btAddTag";
            this.btAddTag.Size = new System.Drawing.Size(100, 36);
            this.btAddTag.TabIndex = 2;
            this.btAddTag.Text = "Ajout Tag";
            // 
            // btAddVisiteur
            // 
            this.btAddVisiteur.Location = new System.Drawing.Point(145, 12);
            this.btAddVisiteur.Name = "btAddVisiteur";
            this.btAddVisiteur.Size = new System.Drawing.Size(100, 36);
            this.btAddVisiteur.TabIndex = 3;
            this.btAddVisiteur.Text = "Ajouter Visiteur";
            // 
            // btSupprVisiteur
            // 
            this.btSupprVisiteur.Location = new System.Drawing.Point(550, 12);
            this.btSupprVisiteur.Name = "btSupprVisiteur";
            this.btSupprVisiteur.Size = new System.Drawing.Size(100, 36);
            this.btSupprVisiteur.TabIndex = 4;
            this.btSupprVisiteur.Text = "Suprimmer Visiteur";
            // 
            // btSupprTag
            // 
            this.btSupprTag.Location = new System.Drawing.Point(678, 12);
            this.btSupprTag.Name = "btSupprTag";
            this.btSupprTag.Size = new System.Drawing.Size(100, 36);
            this.btSupprTag.TabIndex = 5;
            this.btSupprTag.Text = "Supprimer Tag";
            this.btSupprTag.UseVisualStyleBackColor = true;
            // 
            // cbAffectationTag
            // 
            this.cbAffectationTag.FormattingEnabled = true;
            this.cbAffectationTag.Location = new System.Drawing.Point(319, 53);
            this.cbAffectationTag.Name = "cbAffectationTag";
            this.cbAffectationTag.Size = new System.Drawing.Size(121, 21);
            this.cbAffectationTag.TabIndex = 6;
            // 
            // cbAffectationNom
            // 
            this.cbAffectationNom.FormattingEnabled = true;
            this.cbAffectationNom.Location = new System.Drawing.Point(23, 53);
            this.cbAffectationNom.Name = "cbAffectationNom";
            this.cbAffectationNom.Size = new System.Drawing.Size(121, 21);
            this.cbAffectationNom.TabIndex = 7;
            // 
            // cbAffectationCasier
            // 
            this.cbAffectationCasier.FormattingEnabled = true;
            this.cbAffectationCasier.Location = new System.Drawing.Point(174, 53);
            this.cbAffectationCasier.Name = "cbAffectationCasier";
            this.cbAffectationCasier.Size = new System.Drawing.Size(121, 21);
            this.cbAffectationCasier.TabIndex = 8;
            // 
            // listBoxAffectation
            // 
            this.listBoxAffectation.FormattingEnabled = true;
            this.listBoxAffectation.Location = new System.Drawing.Point(18, 69);
            this.listBoxAffectation.Name = "listBoxAffectation";
            this.listBoxAffectation.Size = new System.Drawing.Size(94, 108);
            this.listBoxAffectation.TabIndex = 9;
            this.listBoxAffectation.Click += new System.EventHandler(this.clickListeAffectation);
            // 
            // lbListeAffectation
            // 
            this.lbListeAffectation.AutoSize = true;
            this.lbListeAffectation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListeAffectation.Location = new System.Drawing.Point(15, 26);
            this.lbListeAffectation.Name = "lbListeAffectation";
            this.lbListeAffectation.Size = new System.Drawing.Size(191, 13);
            this.lbListeAffectation.TabIndex = 10;
            this.lbListeAffectation.Text = "Liste des Affectations en cours :";
            // 
            // gpbListeAffectation
            // 
            this.gpbListeAffectation.Controls.Add(this.btRaffraichir);
            this.gpbListeAffectation.Controls.Add(this.listBoxAffectation);
            this.gpbListeAffectation.Controls.Add(this.lbListeAffectation);
            this.gpbListeAffectation.Location = new System.Drawing.Point(12, 95);
            this.gpbListeAffectation.Name = "gpbListeAffectation";
            this.gpbListeAffectation.Size = new System.Drawing.Size(254, 224);
            this.gpbListeAffectation.TabIndex = 11;
            this.gpbListeAffectation.TabStop = false;
            // 
            // btRaffraichir
            // 
            this.btRaffraichir.Location = new System.Drawing.Point(149, 108);
            this.btRaffraichir.Name = "btRaffraichir";
            this.btRaffraichir.Size = new System.Drawing.Size(75, 23);
            this.btRaffraichir.TabIndex = 11;
            this.btRaffraichir.Text = "Raffraichir";
            this.btRaffraichir.UseVisualStyleBackColor = true;
            this.btRaffraichir.Click += new System.EventHandler(this.btRaffraichir_Click);
            // 
            // gpbAffectation
            // 
            this.gpbAffectation.Controls.Add(this.lbAffectation);
            this.gpbAffectation.Controls.Add(this.btAffectation);
            this.gpbAffectation.Controls.Add(this.dtpDateFin);
            this.gpbAffectation.Controls.Add(this.dtpDateDeb);
            this.gpbAffectation.Controls.Add(this.cbAffectationNom);
            this.gpbAffectation.Controls.Add(this.cbAffectationCasier);
            this.gpbAffectation.Controls.Add(this.cbAffectationTag);
            this.gpbAffectation.Location = new System.Drawing.Point(300, 95);
            this.gpbAffectation.Name = "gpbAffectation";
            this.gpbAffectation.Size = new System.Drawing.Size(464, 224);
            this.gpbAffectation.TabIndex = 12;
            this.gpbAffectation.TabStop = false;
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
            this.btAffectation.Location = new System.Drawing.Point(199, 169);
            this.btAffectation.Name = "btAffectation";
            this.btAffectation.Size = new System.Drawing.Size(80, 27);
            this.btAffectation.TabIndex = 11;
            this.btAffectation.Text = "Affectation";
            this.btAffectation.UseVisualStyleBackColor = true;
            this.btAffectation.Click += new System.EventHandler(this.btAffectation_Click);
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.Location = new System.Drawing.Point(268, 111);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(181, 20);
            this.dtpDateFin.TabIndex = 10;
            // 
            // dtpDateDeb
            // 
            this.dtpDateDeb.Location = new System.Drawing.Point(23, 111);
            this.dtpDateDeb.Name = "dtpDateDeb";
            this.dtpDateDeb.Size = new System.Drawing.Size(179, 20);
            this.dtpDateDeb.TabIndex = 9;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 352);
            this.Controls.Add(this.gpbAffectation);
            this.Controls.Add(this.gpbListeAffectation);
            this.Controls.Add(this.btSupprTag);
            this.Controls.Add(this.btSupprVisiteur);
            this.Controls.Add(this.btAddVisiteur);
            this.Controls.Add(this.btAddTag);
            this.Controls.Add(this.btSupprUtilisateur);
            this.Controls.Add(this.btAddUtilisateur);
            this.Name = "MainForm";
            this.Text = "AppCasier";
            this.gpbListeAffectation.ResumeLayout(false);
            this.gpbListeAffectation.PerformLayout();
            this.gpbAffectation.ResumeLayout(false);
            this.gpbAffectation.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btAddUtilisateur;
        private System.Windows.Forms.Button buttonOpenPage2;
        private Button btSupprUtilisateur;
        private Button btAddTag;
        private Button btAddVisiteur;
        private Button btSupprVisiteur;
        private Button btSupprTag;
        private ComboBox cbAffectationTag;
        private ComboBox cbAffectationNom;
        private ComboBox cbAffectationCasier;
        private ListBox listBoxAffectation;
        private Label lbListeAffectation;
        private GroupBox gpbListeAffectation;
        private GroupBox gpbAffectation;
        private Label lbAffectation;
        private Button btAffectation;
        private DateTimePicker dtpDateFin;
        private DateTimePicker dtpDateDeb;
        private Button btRaffraichir;
    }
}
