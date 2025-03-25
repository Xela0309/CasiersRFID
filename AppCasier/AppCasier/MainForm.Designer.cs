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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cbAffectationTag = new System.Windows.Forms.ComboBox();
            this.cbAffectationNom = new System.Windows.Forms.ComboBox();
            this.cbAffectationCasier = new System.Windows.Forms.ComboBox();
            this.gpbAffectation = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAffectation = new System.Windows.Forms.Label();
            this.btAffectation = new System.Windows.Forms.Button();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDeb = new System.Windows.Forms.DateTimePicker();
            this.lbLoginActuel = new System.Windows.Forms.Label();
            this.lbListeAffectation = new System.Windows.Forms.Label();
            this.listBoxAffectation = new System.Windows.Forms.ListBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gpbAffectation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
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
            this.gpbAffectation.Location = new System.Drawing.Point(12, 191);
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
            // lbLoginActuel
            // 
            this.lbLoginActuel.AutoSize = true;
            this.lbLoginActuel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoginActuel.ForeColor = System.Drawing.Color.Blue;
            this.lbLoginActuel.Location = new System.Drawing.Point(436, 9);
            this.lbLoginActuel.Name = "lbLoginActuel";
            this.lbLoginActuel.Size = new System.Drawing.Size(34, 13);
            this.lbLoginActuel.TabIndex = 14;
            this.lbLoginActuel.Text = "login";
            // 
            // lbListeAffectation
            // 
            this.lbListeAffectation.AutoSize = true;
            this.lbListeAffectation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListeAffectation.Location = new System.Drawing.Point(12, 86);
            this.lbListeAffectation.Name = "lbListeAffectation";
            this.lbListeAffectation.Size = new System.Drawing.Size(273, 13);
            this.lbListeAffectation.TabIndex = 10;
            this.lbListeAffectation.Text = "Liste des casiers occupé par une Affecttation :";
            // 
            // listBoxAffectation
            // 
            this.listBoxAffectation.FormattingEnabled = true;
            this.listBoxAffectation.Location = new System.Drawing.Point(300, 47);
            this.listBoxAffectation.Name = "listBoxAffectation";
            this.listBoxAffectation.Size = new System.Drawing.Size(119, 121);
            this.listBoxAffectation.TabIndex = 9;
            this.listBoxAffectation.Click += new System.EventHandler(this.clickListeAffectation);
            // 
            // pbLogo
            // 
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(486, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(31, 33);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 15;
            this.pbLogo.TabStop = false;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(520, 419);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lbListeAffectation);
            this.Controls.Add(this.listBoxAffectation);
            this.Controls.Add(this.lbLoginActuel);
            this.Controls.Add(this.gpbAffectation);
            this.Name = "MainForm";
            this.Text = "AppCasier";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.FermetureMenuHamburger);
            this.gpbAffectation.ResumeLayout(false);
            this.gpbAffectation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ComboBox cbAffectationTag;
        private ComboBox cbAffectationNom;
        private ComboBox cbAffectationCasier;
        private GroupBox gpbAffectation;
        private Label lbAffectation;
        private Button btAffectation;
        private DateTimePicker dtpDateFin;
        private DateTimePicker dtpDateDeb;
        private Label lbLoginActuel;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lbListeAffectation;
        private ListBox listBoxAffectation;
        private PictureBox pbLogo;
    }
}
