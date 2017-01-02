namespace ProgettoCMA
{
    partial class Categorie
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.annullaButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.nomeValue = new System.Windows.Forms.TextBox();
            this.idValue = new System.Windows.Forms.TextBox();
            this.ragioneSocialeLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.clientiGroupBox = new System.Windows.Forms.GroupBox();
            this.clientiGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // annullaButton
            // 
            this.annullaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.annullaButton.Enabled = false;
            this.annullaButton.Location = new System.Drawing.Point(277, 211);
            this.annullaButton.Margin = new System.Windows.Forms.Padding(1);
            this.annullaButton.Name = "annullaButton";
            this.annullaButton.Size = new System.Drawing.Size(147, 32);
            this.annullaButton.TabIndex = 34;
            this.annullaButton.Text = "Annulla";
            this.annullaButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Ricerca";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(6, 18);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(409, 20);
            this.searchTextBox.TabIndex = 32;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // nomeValue
            // 
            this.nomeValue.Location = new System.Drawing.Point(213, 78);
            this.nomeValue.Margin = new System.Windows.Forms.Padding(1);
            this.nomeValue.Name = "nomeValue";
            this.nomeValue.Size = new System.Drawing.Size(244, 20);
            this.nomeValue.TabIndex = 20;
            // 
            // idValue
            // 
            this.idValue.Location = new System.Drawing.Point(213, 48);
            this.idValue.Margin = new System.Windows.Forms.Padding(1);
            this.idValue.Name = "idValue";
            this.idValue.Size = new System.Drawing.Size(244, 20);
            this.idValue.TabIndex = 19;
            // 
            // ragioneSocialeLabel
            // 
            this.ragioneSocialeLabel.AutoSize = true;
            this.ragioneSocialeLabel.Location = new System.Drawing.Point(153, 79);
            this.ragioneSocialeLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ragioneSocialeLabel.Name = "ragioneSocialeLabel";
            this.ragioneSocialeLabel.Size = new System.Drawing.Size(35, 13);
            this.ragioneSocialeLabel.TabIndex = 18;
            this.ragioneSocialeLabel.Text = "Nome";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(155, 51);
            this.idLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 5;
            this.idLabel.Text = "ID";
            // 
            // deleteButton
            // 
            this.deleteButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.delete_512;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButton.Location = new System.Drawing.Point(239, 211);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(1);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(30, 32);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.add_user_128;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButton.Location = new System.Drawing.Point(426, 211);
            this.addButton.Margin = new System.Windows.Forms.Padding(1);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(30, 32);
            this.addButton.TabIndex = 3;
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.floppy_disk_icon_8284;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(197, 211);
            this.saveButton.Margin = new System.Windows.Forms.Padding(1);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(30, 32);
            this.saveButton.TabIndex = 3;
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.editor_pencil_pen_edit_write_glyph_128;
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editButton.Location = new System.Drawing.Point(157, 211);
            this.editButton.Margin = new System.Windows.Forms.Padding(1);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(30, 32);
            this.editButton.TabIndex = 3;
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(6, 46);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(140, 199);
            this.listBox.TabIndex = 0;
            // 
            // clientiGroupBox
            // 
            this.clientiGroupBox.Controls.Add(this.annullaButton);
            this.clientiGroupBox.Controls.Add(this.label1);
            this.clientiGroupBox.Controls.Add(this.searchTextBox);
            this.clientiGroupBox.Controls.Add(this.nomeValue);
            this.clientiGroupBox.Controls.Add(this.idValue);
            this.clientiGroupBox.Controls.Add(this.ragioneSocialeLabel);
            this.clientiGroupBox.Controls.Add(this.idLabel);
            this.clientiGroupBox.Controls.Add(this.deleteButton);
            this.clientiGroupBox.Controls.Add(this.addButton);
            this.clientiGroupBox.Controls.Add(this.saveButton);
            this.clientiGroupBox.Controls.Add(this.editButton);
            this.clientiGroupBox.Controls.Add(this.listBox);
            this.clientiGroupBox.Location = new System.Drawing.Point(8, 7);
            this.clientiGroupBox.Name = "clientiGroupBox";
            this.clientiGroupBox.Size = new System.Drawing.Size(473, 252);
            this.clientiGroupBox.TabIndex = 1;
            this.clientiGroupBox.TabStop = false;
            this.clientiGroupBox.Text = "Categrie";
            // 
            // Categorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientiGroupBox);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Categorie";
            this.Size = new System.Drawing.Size(492, 265);
            this.clientiGroupBox.ResumeLayout(false);
            this.clientiGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button annullaButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox nomeValue;
        private System.Windows.Forms.TextBox idValue;
        private System.Windows.Forms.Label ragioneSocialeLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.GroupBox clientiGroupBox;
    }
}
