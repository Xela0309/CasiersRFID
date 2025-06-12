namespace AppCasier
{
    partial class PageAjoutTag
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
            this.btSelectTag = new System.Windows.Forms.Button();
            this.tbTag = new System.Windows.Forms.TextBox();
            this.btAjoutTag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitre
            // 
            this.lbTitre.AutoSize = true;
            this.lbTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitre.Location = new System.Drawing.Point(12, 14);
            this.lbTitre.Name = "lbTitre";
            this.lbTitre.Size = new System.Drawing.Size(144, 13);
            this.lbTitre.TabIndex = 0;
            this.lbTitre.Text = "Veuillez choisir un tag : ";
            // 
            // btSelectTag
            // 
            this.btSelectTag.Location = new System.Drawing.Point(190, 9);
            this.btSelectTag.Name = "btSelectTag";
            this.btSelectTag.Size = new System.Drawing.Size(75, 23);
            this.btSelectTag.TabIndex = 1;
            this.btSelectTag.Text = "Selectionner";
            this.btSelectTag.UseVisualStyleBackColor = true;
            this.btSelectTag.Click += new System.EventHandler(this.btSelectTag_Click);
            // 
            // tbTag
            // 
            this.tbTag.Location = new System.Drawing.Point(15, 54);
            this.tbTag.Name = "tbTag";
            this.tbTag.ReadOnly = true;
            this.tbTag.Size = new System.Drawing.Size(131, 20);
            this.tbTag.TabIndex = 2;
            // 
            // btAjoutTag
            // 
            this.btAjoutTag.Location = new System.Drawing.Point(190, 52);
            this.btAjoutTag.Name = "btAjoutTag";
            this.btAjoutTag.Size = new System.Drawing.Size(75, 23);
            this.btAjoutTag.TabIndex = 3;
            this.btAjoutTag.Text = "Ajouter";
            this.btAjoutTag.UseVisualStyleBackColor = true;
            this.btAjoutTag.Click += new System.EventHandler(this.btAjoutTag_Click);
            // 
            // PageAjoutTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 102);
            this.Controls.Add(this.btAjoutTag);
            this.Controls.Add(this.tbTag);
            this.Controls.Add(this.btSelectTag);
            this.Controls.Add(this.lbTitre);
            this.Name = "PageAjoutTag";
            this.Text = "Ajout de tag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitre;
        private System.Windows.Forms.Button btSelectTag;
        private System.Windows.Forms.TextBox tbTag;
        private System.Windows.Forms.Button btAjoutTag;
    }
}