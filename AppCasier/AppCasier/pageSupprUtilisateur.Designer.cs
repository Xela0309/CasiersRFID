namespace AppCasier
{
    partial class pageSupprUtilisateur
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbUtilisateur = new System.Windows.Forms.Label();
            this.cbUtilisateur = new System.Windows.Forms.ComboBox();
            this.lbTitre = new System.Windows.Forms.Label();
            this.btSuppr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUtilisateur
            // 
            this.lbUtilisateur.AutoSize = true;
            this.lbUtilisateur.Location = new System.Drawing.Point(12, 65);
            this.lbUtilisateur.Name = "lbUtilisateur";
            this.lbUtilisateur.Size = new System.Drawing.Size(59, 13);
            this.lbUtilisateur.TabIndex = 11;
            this.lbUtilisateur.Text = "Utilisateur :";
            // 
            // cbUtilisateur
            // 
            this.cbUtilisateur.FormattingEnabled = true;
            this.cbUtilisateur.Location = new System.Drawing.Point(82, 62);
            this.cbUtilisateur.Name = "cbUtilisateur";
            this.cbUtilisateur.Size = new System.Drawing.Size(172, 21);
            this.cbUtilisateur.TabIndex = 10;
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Location = new System.Drawing.Point(12, 9);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(216, 13);
            this.lbTitre.TabIndex = 9;
            this.lbTitre.Text = "Veuillez selectionnez l\'utilisateur à supprimer:";
            // 
            // btSuppr
            // 
            this.btSuppr.Location = new System.Drawing.Point(278, 62);
            this.btSuppr.Name = "btSuppr";
            this.btSuppr.Size = new System.Drawing.Size(75, 23);
            this.btSuppr.TabIndex = 8;
            this.btSuppr.Text = "Supprimer";
            this.btSuppr.UseVisualStyleBackColor = true;
            this.btSuppr.Click += new System.EventHandler(this.btSuppr_Click);
            // 
            // pageSupprUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 157);
            this.Controls.Add(this.lbUtilisateur);
            this.Controls.Add(this.cbUtilisateur);
            this.Controls.Add(this.lbTitre);
            this.Controls.Add(this.btSuppr);
            this.Name = "pageSupprUtilisateur";
            this.Text = "pageSupprUtilisateur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUtilisateur;
        private System.Windows.Forms.ComboBox cbUtilisateur;
        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.Button btSuppr;
    }
}