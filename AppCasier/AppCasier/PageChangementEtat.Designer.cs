namespace AppCasier
{
    partial class PageChangementEtat
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
            this.btChange = new System.Windows.Forms.Button();
            this.lbEtat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTag
            // 
            this.lbTag.AutoSize = true;
            this.lbTag.Location = new System.Drawing.Point(12, 65);
            this.lbTag.Name = "lbTag";
            this.lbTag.Size = new System.Drawing.Size(32, 13);
            this.lbTag.TabIndex = 11;
            this.lbTag.Text = "Tag :";
            // 
            // cbTag
            // 
            this.cbTag.FormattingEnabled = true;
            this.cbTag.Location = new System.Drawing.Point(62, 62);
            this.cbTag.Name = "cbTag";
            this.cbTag.Size = new System.Drawing.Size(172, 21);
            this.cbTag.TabIndex = 10;
            this.cbTag.SelectedIndexChanged += new System.EventHandler(this.cbTag_SelectedIndexChanged);
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitre.Location = new System.Drawing.Point(12, 9);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(225, 13);
            this.lbTitre.TabIndex = 9;
            this.lbTitre.Text = "Veuillez selectionnez le tag à modifier:";
            // 
            // btChange
            // 
            this.btChange.Location = new System.Drawing.Point(301, 62);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(83, 23);
            this.btChange.TabIndex = 8;
            this.btChange.Text = "Changement";
            this.btChange.UseVisualStyleBackColor = true;
            this.btChange.Click += new System.EventHandler(this.btChange_Click);
            // 
            // lbEtat
            // 
            this.lbEtat.AutoSize = true;
            this.lbEtat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEtat.Location = new System.Drawing.Point(251, 65);
            this.lbEtat.Name = "lbEtat";
            this.lbEtat.Size = new System.Drawing.Size(29, 13);
            this.lbEtat.TabIndex = 12;
            this.lbEtat.Text = "etat";
            // 
            // PageChangementEtat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 119);
            this.Controls.Add(this.lbEtat);
            this.Controls.Add(this.lbTag);
            this.Controls.Add(this.cbTag);
            this.Controls.Add(this.lbTitre);
            this.Controls.Add(this.btChange);
            this.Name = "PageChangementEtat";
            this.Text = "Modification d\'état";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTag;
        private System.Windows.Forms.ComboBox cbTag;
        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.Label lbEtat;
    }
}