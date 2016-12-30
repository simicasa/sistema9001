namespace ProgettoCMA
{
    partial class Login
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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(28, 33);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(124, 29);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(35, 143);
            this.loginButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(600, 51);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(33, 91);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(120, 29);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(170, 27);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(459, 35);
            this.usernameTextBox.TabIndex = 3;
            this.usernameTextBox.Text = "angelo";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(170, 85);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(459, 35);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.Text = "angelo";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 228);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.usernameLabel);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
    }
}