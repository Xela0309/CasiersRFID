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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.listBoxAffectation = new System.Windows.Forms.ListBox();
            this.lbListeAffectation = new System.Windows.Forms.Label();
            this.gpbListeAffectation = new System.Windows.Forms.GroupBox();
            this.gpbAffectation = new System.Windows.Forms.GroupBox();
            this.lbAffectation = new System.Windows.Forms.Label();
            this.btAffectation = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btRaffraichir = new System.Windows.Forms.Button();
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(319, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(23, 53);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 7;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(174, 53);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 8;
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
            // gpbAffectation
            // 
            this.gpbAffectation.Controls.Add(this.lbAffectation);
            this.gpbAffectation.Controls.Add(this.btAffectation);
            this.gpbAffectation.Controls.Add(this.dateTimePicker2);
            this.gpbAffectation.Controls.Add(this.dateTimePicker1);
            this.gpbAffectation.Controls.Add(this.comboBox2);
            this.gpbAffectation.Controls.Add(this.comboBox3);
            this.gpbAffectation.Controls.Add(this.comboBox1);
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
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(268, 111);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(181, 20);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(23, 111);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(179, 20);
            this.dateTimePicker1.TabIndex = 9;
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
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ListBox listBoxAffectation;
        private Label lbListeAffectation;
        private GroupBox gpbListeAffectation;
        private GroupBox gpbAffectation;
        private Label lbAffectation;
        private Button btAffectation;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Button btRaffraichir;
    }
}
