namespace AppCasier
{
    partial class PageAjoutVisiteur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base. Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTitre = new System.Windows.Forms.Label();
            this.lbPrenom = new System.Windows.Forms.Label();
            this.lbPlaque = new System.Windows.Forms.Label();
            this.lbCompagnie = new System.Windows.Forms.Label();
            this.lbNom = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.tbPlaque = new System.Windows.Forms.TextBox();
            this.tbCompagnie = new System.Windows.Forms.TextBox();
            this.tbPrenom = new System.Windows.Forms.TextBox();
            this.lbPlaqueEx = new System.Windows.Forms.Label();
            this.btCreerVisiteur = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitre.Location = new System.Drawing.Point(12, 9);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(290, 13);
            this.lbTitre.TabIndex = 0;
            this.lbTitre.Text = "Veuillez rentrer les informations correspondantes :";
            // 
            // lbPrenom
            // 
            this.lbPrenom.AutoSize = true;
            this.lbPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrenom.Location = new System.Drawing.Point(12, 103);
            this.lbPrenom.Name = "lbPrenom";
            this.lbPrenom.Size = new System.Drawing.Size(57, 13);
            this.lbPrenom.TabIndex = 1;
            this.lbPrenom.Text = "Prenom :";
            // 
            // lbPlaque
            // 
            this.lbPlaque.AutoSize = true;
            this.lbPlaque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlaque.Location = new System.Drawing.Point(12, 188);
            this.lbPlaque.Name = "lbPlaque";
            this.lbPlaque.Size = new System.Drawing.Size(54, 13);
            this.lbPlaque.TabIndex = 3;
            this.lbPlaque.Text = "Plaque :";
            // 
            // lbCompagnie
            // 
            this.lbCompagnie.AutoSize = true;
            this.lbCompagnie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompagnie.Location = new System.Drawing.Point(12, 143);
            this.lbCompagnie.Name = "lbCompagnie";
            this.lbCompagnie.Size = new System.Drawing.Size(77, 13);
            this.lbCompagnie.TabIndex = 4;
            this.lbCompagnie.Text = "Compagnie :";
            // 
            // lbNom
            // 
            this.lbNom.AutoSize = true;
            this.lbNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNom.Location = new System.Drawing.Point(12, 63);
            this.lbNom.Name = "lbNom";
            this.lbNom.Size = new System.Drawing.Size(40, 13);
            this.lbNom.TabIndex = 5;
            this.lbNom.Text = "Nom :";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(102, 60);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(119, 20);
            this.tbNom.TabIndex = 6;
            // 
            // tbPlaque
            // 
            this.tbPlaque.Location = new System.Drawing.Point(102, 185);
            this.tbPlaque.Name = "tbPlaque";
            this.tbPlaque.Size = new System.Drawing.Size(119, 20);
            this.tbPlaque.TabIndex = 7;
            // 
            // tbCompagnie
            // 
            this.tbCompagnie.Location = new System.Drawing.Point(102, 143);
            this.tbCompagnie.Name = "tbCompagnie";
            this.tbCompagnie.Size = new System.Drawing.Size(119, 20);
            this.tbCompagnie.TabIndex = 8;
            // 
            // tbPrenom
            // 
            this.tbPrenom.Location = new System.Drawing.Point(102, 103);
            this.tbPrenom.Name = "tbPrenom";
            this.tbPrenom.Size = new System.Drawing.Size(119, 20);
            this.tbPrenom.TabIndex = 9;
            // 
            // lbPlaqueEx
            // 
            this.lbPlaqueEx.AutoSize = true;
            this.lbPlaqueEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlaqueEx.Location = new System.Drawing.Point(123, 208);
            this.lbPlaqueEx.Name = "lbPlaqueEx";
            this.lbPlaqueEx.Size = new System.Drawing.Size(80, 13);
            this.lbPlaqueEx.TabIndex = 10;
            this.lbPlaqueEx.Text = "Ex : AA-123-BB";
            // 
            // btCreerVisiteur
            // 
            this.btCreerVisiteur.Location = new System.Drawing.Point(113, 255);
            this.btCreerVisiteur.Name = "btCreerVisiteur";
            this.btCreerVisiteur.Size = new System.Drawing.Size(75, 23);
            this.btCreerVisiteur.TabIndex = 11;
            this.btCreerVisiteur.Text = "Confirmer";
            this.btCreerVisiteur.UseVisualStyleBackColor = true;
            this.btCreerVisiteur.Click += new System.EventHandler(this.btCreerVisiteur_Click);
            // 
            // PageAjoutVisiteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 292);
            this.Controls.Add(this.btCreerVisiteur);
            this.Controls.Add(this.lbPlaqueEx);
            this.Controls.Add(this.tbPrenom);
            this.Controls.Add(this.tbCompagnie);
            this.Controls.Add(this.tbPlaque);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.lbNom);
            this.Controls.Add(this.lbCompagnie);
            this.Controls.Add(this.lbPlaque);
            this.Controls.Add(this.lbPrenom);
            this.Controls.Add(this.lbTitre);
            this.Name = "PageAjoutVisiteur";
            this.Text = "PageAjoutVisiteur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.Label lbPrenom;
        private System.Windows.Forms.Label lbPlaque;
        private System.Windows.Forms.Label lbCompagnie;
        private System.Windows.Forms.Label lbNom;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.TextBox tbPlaque;
        private System.Windows.Forms.TextBox tbCompagnie;
        private System.Windows.Forms.TextBox tbPrenom;
        private System.Windows.Forms.Label lbPlaqueEx;
        private System.Windows.Forms.Button btCreerVisiteur;
    }
}