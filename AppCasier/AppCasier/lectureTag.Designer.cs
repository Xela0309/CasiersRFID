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
            this.lbTitre = new System.Windows.Forms.Label();
            this.lbTag = new System.Windows.Forms.Label();
            this.lbConfirmation = new System.Windows.Forms.Label();
            this.lbRefus = new System.Windows.Forms.Label();
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
            // lbTag
            // 
            this.lbTag.AutoSize = true;
            this.lbTag.Location = new System.Drawing.Point(70, 67);
            this.lbTag.Name = "lbTag";
            this.lbTag.Size = new System.Drawing.Size(70, 13);
            this.lbTag.TabIndex = 3;
            this.lbTag.Text = "                     ";
            // 
            // lbConfirmation
            // 
            this.lbConfirmation.AutoSize = true;
            this.lbConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirmation.Location = new System.Drawing.Point(70, 31);
            this.lbConfirmation.Name = "lbConfirmation";
            this.lbConfirmation.Size = new System.Drawing.Size(77, 13);
            this.lbConfirmation.TabIndex = 4;
            this.lbConfirmation.Text = "Tag trouvé :";
            this.lbConfirmation.Visible = false;
            // 
            // lbRefus
            // 
            this.lbRefus.AutoSize = true;
            this.lbRefus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRefus.Location = new System.Drawing.Point(67, 54);
            this.lbRefus.Name = "lbRefus";
            this.lbRefus.Size = new System.Drawing.Size(91, 13);
            this.lbRefus.TabIndex = 5;
            this.lbRefus.Text = "                     ";
            // 
            // lectureTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 102);
            this.Controls.Add(this.lbRefus);
            this.Controls.Add(this.lbConfirmation);
            this.Controls.Add(this.lbTag);
            this.Controls.Add(this.lbTitre);
            this.Name = "lectureTag";
            this.Text = "lectureTag";
            this.Load += new System.EventHandler(this.lectureTagValide);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.Label lbTag;
        private System.Windows.Forms.Label lbConfirmation;
        private System.Windows.Forms.Label lbRefus;
    }
}