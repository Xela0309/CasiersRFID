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
            this.gpbListeAffectation = new System.Windows.Forms.GroupBox();
            this.btRaffraichir = new System.Windows.Forms.Button();
            this.gpbAffectation = new System.Windows.Forms.GroupBox();
            this.lbAffectation = new System.Windows.Forms.Label();
            this.btAffectation = new System.Windows.Forms.Button();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDeb = new System.Windows.Forms.DateTimePicker();
            this.lbConnctedTo = new System.Windows.Forms.Label();
            this.lbLoginActuel = new System.Windows.Forms.Label();
            this.gpbListeAffectation.SuspendLayout();
            this.gpbAffectation.SuspendLayout();
            this.SuspendLayout();
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
            this.gpbListeAffectation.BackColor = System.Drawing.Color.Chartreuse;
            this.gpbListeAffectation.Controls.Add(this.btRaffraichir);
            this.gpbListeAffectation.Controls.Add(this.listBoxAffectation);
            this.gpbListeAffectation.Controls.Add(this.lbListeAffectation);
            this.gpbListeAffectation.Location = new System.Drawing.Point(12, 66);
            this.gpbListeAffectation.Name = "gpbListeAffectation";
            this.gpbListeAffectation.Size = new System.Drawing.Size(254, 224);
            this.gpbListeAffectation.TabIndex = 11;
            this.gpbListeAffectation.TabStop = false;
            this.gpbListeAffectation.Enter += new System.EventHandler(this.FermetureMenuHamburger);
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
            this.gpbAffectation.BackColor = System.Drawing.Color.Yellow;
            this.gpbAffectation.Controls.Add(this.lbAffectation);
            this.gpbAffectation.Controls.Add(this.btAffectation);
            this.gpbAffectation.Controls.Add(this.dtpDateFin);
            this.gpbAffectation.Controls.Add(this.dtpDateDeb);
            this.gpbAffectation.Controls.Add(this.cbAffectationNom);
            this.gpbAffectation.Controls.Add(this.cbAffectationCasier);
            this.gpbAffectation.Controls.Add(this.cbAffectationTag);
            this.gpbAffectation.Location = new System.Drawing.Point(295, 66);
            this.gpbAffectation.Name = "gpbAffectation";
            this.gpbAffectation.Size = new System.Drawing.Size(464, 224);
            this.gpbAffectation.TabIndex = 12;
            this.gpbAffectation.TabStop = false;
            this.gpbAffectation.Enter += new System.EventHandler(this.FermetureMenuHamburger);
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
            // lbConnctedTo
            // 
            this.lbConnctedTo.AutoSize = true;
            this.lbConnctedTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConnctedTo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbConnctedTo.Location = new System.Drawing.Point(529, 9);
            this.lbConnctedTo.Name = "lbConnctedTo";
            this.lbConnctedTo.Size = new System.Drawing.Size(138, 13);
            this.lbConnctedTo.TabIndex = 13;
            this.lbConnctedTo.Text = "Connecté en tant que :";
            // 
            // lbLoginActuel
            // 
            this.lbLoginActuel.AutoSize = true;
            this.lbLoginActuel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoginActuel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbLoginActuel.Location = new System.Drawing.Point(673, 9);
            this.lbLoginActuel.Name = "lbLoginActuel";
            this.lbLoginActuel.Size = new System.Drawing.Size(34, 13);
            this.lbLoginActuel.TabIndex = 14;
            this.lbLoginActuel.Text = "login";
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(771, 317);
            this.Controls.Add(this.lbLoginActuel);
            this.Controls.Add(this.lbConnctedTo);
            this.Controls.Add(this.gpbAffectation);
            this.Controls.Add(this.gpbListeAffectation);
            this.Name = "MainForm";
            this.Text = "AppCasier";
            this.Click += new System.EventHandler(this.FermetureMenuHamburger);
            this.gpbListeAffectation.ResumeLayout(false);
            this.gpbListeAffectation.PerformLayout();
            this.gpbAffectation.ResumeLayout(false);
            this.gpbAffectation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button buttonOpenPage2;
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
        private Label lbConnctedTo;
        private Label lbLoginActuel;
    }
}
