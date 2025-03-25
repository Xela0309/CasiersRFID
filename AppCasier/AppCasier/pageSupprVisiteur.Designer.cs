namespace AppCasier
{
    partial class pageSupprVisiteur
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
            this.btSuppr = new System.Windows.Forms.Button();
            this.lbTitre = new System.Windows.Forms.Label();
            this.cbVisiteur = new System.Windows.Forms.ComboBox();
            this.lbVisiteurChoisi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSuppr
            // 
            this.btSuppr.Location = new System.Drawing.Point(316, 32);
            this.btSuppr.Name = "btSuppr";
            this.btSuppr.Size = new System.Drawing.Size(75, 23);
            this.btSuppr.TabIndex = 0;
            this.btSuppr.Text = "Supprimer";
            this.btSuppr.UseVisualStyleBackColor = true;
            this.btSuppr.Click += new System.EventHandler(this.btSuppr_Click);
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitre.Location = new System.Drawing.Point(12, 9);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(260, 13);
            this.lbTitre.TabIndex = 1;
            this.lbTitre.Text = "Veuillez selectionnez le Visteur à supprimer :";
            // 
            // cbVisiteur
            // 
            this.cbVisiteur.FormattingEnabled = true;
            this.cbVisiteur.Location = new System.Drawing.Point(95, 34);
            this.cbVisiteur.Name = "cbVisiteur";
            this.cbVisiteur.Size = new System.Drawing.Size(177, 21);
            this.cbVisiteur.TabIndex = 2;
            // 
            // lbVisiteurChoisi
            // 
            this.lbVisiteurChoisi.AutoSize = true;
            this.lbVisiteurChoisi.Location = new System.Drawing.Point(12, 37);
            this.lbVisiteurChoisi.Name = "lbVisiteurChoisi";
            this.lbVisiteurChoisi.Size = new System.Drawing.Size(77, 13);
            this.lbVisiteurChoisi.TabIndex = 3;
            this.lbVisiteurChoisi.Text = "Visiteur choisi :";
            // 
            // pageSupprVisiteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 106);
            this.Controls.Add(this.lbVisiteurChoisi);
            this.Controls.Add(this.cbVisiteur);
            this.Controls.Add(this.lbTitre);
            this.Controls.Add(this.btSuppr);
            this.Name = "pageSupprVisiteur";
            this.Text = "pageSupprVisiteur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSuppr;
        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.ComboBox cbVisiteur;
        private System.Windows.Forms.Label lbVisiteurChoisi;
    }
}