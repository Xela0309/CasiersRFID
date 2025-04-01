namespace AppCasier
{
    partial class pageSupprTag
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
            this.lbTag = new System.Windows.Forms.Label();
            this.cbTag = new System.Windows.Forms.ComboBox();
            this.lbTitre = new System.Windows.Forms.Label();
            this.btSuppr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTag
            // 
            this.lbTag.AutoSize = true;
            this.lbTag.Location = new System.Drawing.Point(12, 65);
            this.lbTag.Name = "lbTag";
            this.lbTag.Size = new System.Drawing.Size(32, 13);
            this.lbTag.TabIndex = 7;
            this.lbTag.Text = "Tag :";
            // 
            // cbTag
            // 
            this.cbTag.FormattingEnabled = true;
            this.cbTag.Location = new System.Drawing.Point(62, 62);
            this.cbTag.Name = "cbTag";
            this.cbTag.Size = new System.Drawing.Size(172, 21);
            this.cbTag.TabIndex = 6;
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Location = new System.Drawing.Point(12, 9);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(194, 13);
            this.lbTitre.TabIndex = 5;
            this.lbTitre.Text = "Veuillez selectionnez le tag à supprimer:";
            // 
            // btSuppr
            // 
            this.btSuppr.Location = new System.Drawing.Point(261, 62);
            this.btSuppr.Name = "btSuppr";
            this.btSuppr.Size = new System.Drawing.Size(75, 23);
            this.btSuppr.TabIndex = 4;
            this.btSuppr.Text = "Supprimer";
            this.btSuppr.UseVisualStyleBackColor = true;
            this.btSuppr.Click += new System.EventHandler(this.btSuppr_Click);
            // 
            // pageSupprTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 155);
            this.Controls.Add(this.lbTag);
            this.Controls.Add(this.cbTag);
            this.Controls.Add(this.lbTitre);
            this.Controls.Add(this.btSuppr);
            this.Name = "pageSupprTag";
            this.Text = "pageSupprTag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTag;
        private System.Windows.Forms.ComboBox cbTag;
        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.Button btSuppr;
    }
}