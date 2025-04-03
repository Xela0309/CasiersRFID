namespace AppCasier
{
    partial class lectureTag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lectureTag));
            this.lbTitre = new System.Windows.Forms.Label();
            this.pbRecherche = new System.Windows.Forms.PictureBox();
            this.lbTag = new System.Windows.Forms.Label();
            this.lbConfirmation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecherche)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitre.Location = new System.Drawing.Point(40, 9);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(143, 13);
            this.lbTitre.TabIndex = 1;
            this.lbTitre.Text = "Tag en cours de lecture";
            // 
            // pbRecherche
            // 
            this.pbRecherche.Image = ((System.Drawing.Image)(resources.GetObject("pbRecherche.Image")));
            this.pbRecherche.Location = new System.Drawing.Point(84, 25);
            this.pbRecherche.Name = "pbRecherche";
            this.pbRecherche.Size = new System.Drawing.Size(51, 51);
            this.pbRecherche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRecherche.TabIndex = 2;
            this.pbRecherche.TabStop = false;
            // 
            // lbTag
            // 
            this.lbTag.AutoSize = true;
            this.lbTag.Location = new System.Drawing.Point(60, 79);
            this.lbTag.Name = "lbTag";
            this.lbTag.Size = new System.Drawing.Size(70, 13);
            this.lbTag.TabIndex = 3;
            this.lbTag.Text = "                     ";
            // 
            // lbConfirmation
            // 
            this.lbConfirmation.AutoSize = true;
            this.lbConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirmation.Location = new System.Drawing.Point(70, 41);
            this.lbConfirmation.Name = "lbConfirmation";
            this.lbConfirmation.Size = new System.Drawing.Size(77, 13);
            this.lbConfirmation.TabIndex = 4;
            this.lbConfirmation.Text = "Tag trouvé :";
            this.lbConfirmation.Visible = false;
            // 
            // lectureTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 105);
            this.Controls.Add(this.lbConfirmation);
            this.Controls.Add(this.lbTag);
            this.Controls.Add(this.pbRecherche);
            this.Controls.Add(this.lbTitre);
            this.Name = "lectureTag";
            this.Text = "lectureTag";
            this.Load += new System.EventHandler(this.lectureTagValide);
            ((System.ComponentModel.ISupportInitialize)(this.pbRecherche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.PictureBox pbRecherche;
        private System.Windows.Forms.Label lbTag;
        private System.Windows.Forms.Label lbConfirmation;
    }
}