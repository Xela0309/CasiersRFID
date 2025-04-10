namespace AppCasier
{
    partial class PageAjoutUtilisateur
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
            this.btAccepter = new System.Windows.Forms.Button();
            this.lbTitreAjoutUtilisateur = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbRole = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btAccepter
            // 
            this.btAccepter.Location = new System.Drawing.Point(85, 204);
            this.btAccepter.Name = "btAccepter";
            this.btAccepter.Size = new System.Drawing.Size(75, 23);
            this.btAccepter.TabIndex = 0;
            this.btAccepter.Text = "Confirmer";
            this.btAccepter.UseVisualStyleBackColor = true;
            this.btAccepter.Click += new System.EventHandler(this.btAccepter_Click);
            // 
            // lbTitreAjoutUtilisateur
            // 
            this.lbTitreAjoutUtilisateur.AutoSize = true;
            this.lbTitreAjoutUtilisateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitreAjoutUtilisateur.Location = new System.Drawing.Point(13, 13);
            this.lbTitreAjoutUtilisateur.Name = "lbTitreAjoutUtilisateur";
            this.lbTitreAjoutUtilisateur.Size = new System.Drawing.Size(136, 13);
            this.lbTitreAjoutUtilisateur.TabIndex = 1;
            this.lbTitreAjoutUtilisateur.Text = "Ajoutez un Utilisateur :";
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogin.Location = new System.Drawing.Point(13, 64);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(46, 13);
            this.lbLogin.TabIndex = 2;
            this.lbLogin.Text = "Login :";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(13, 104);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(91, 13);
            this.lbPassword.TabIndex = 3;
            this.lbPassword.Text = "Mot de passe :";
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.Location = new System.Drawing.Point(13, 149);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(41, 13);
            this.lbRole.TabIndex = 4;
            this.lbRole.Text = "Role :";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(110, 64);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(115, 20);
            this.tbLogin.TabIndex = 5;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(110, 104);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(115, 20);
            this.tbPassword.TabIndex = 6;
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "admin",
            "user"});
            this.cbRole.Location = new System.Drawing.Point(110, 146);
            this.cbRole.Name = "cbRole";
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.Size = new System.Drawing.Size(115, 21);
            this.cbRole.TabIndex = 7;
            // 
            // PageAjoutUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 236);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lbRole);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.lbTitreAjoutUtilisateur);
            this.Controls.Add(this.btAccepter);
            this.Name = "PageAjoutUtilisateur";
            this.Text = "Ajout d\'utilisateur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAccepter;
        private System.Windows.Forms.Label lbTitreAjoutUtilisateur;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.ComboBox cbRole;
    }
}