namespace ProgettoCMA
{
    partial class Commesse
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
            this.clientiGroupBox = new System.Windows.Forms.GroupBox();
            this.clienteValue = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.annullaButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.utenteValue = new System.Windows.Forms.TextBox();
            this.creazioneValue = new System.Windows.Forms.TextBox();
            this.codiceValue = new System.Windows.Forms.TextBox();
            this.chiusuraValue = new System.Windows.Forms.TextBox();
            this.idValue = new System.Windows.Forms.TextBox();
            this.dataCreazioneLabel = new System.Windows.Forms.Label();
            this.provinciaLabel = new System.Windows.Forms.Label();
            this.civicoLabel = new System.Windows.Forms.Label();
            this.viaLabel = new System.Windows.Forms.Label();
            this.ragioneSocialeLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.noteValue = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.clientiGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientiGroupBox
            // 
            this.clientiGroupBox.Controls.Add(this.clienteValue);
            this.clientiGroupBox.Controls.Add(this.label2);
            this.clientiGroupBox.Controls.Add(this.annullaButton);
            this.clientiGroupBox.Controls.Add(this.label1);
            this.clientiGroupBox.Controls.Add(this.searchTextBox);
            this.clientiGroupBox.Controls.Add(this.utenteValue);
            this.clientiGroupBox.Controls.Add(this.creazioneValue);
            this.clientiGroupBox.Controls.Add(this.codiceValue);
            this.clientiGroupBox.Controls.Add(this.chiusuraValue);
            this.clientiGroupBox.Controls.Add(this.idValue);
            this.clientiGroupBox.Controls.Add(this.dataCreazioneLabel);
            this.clientiGroupBox.Controls.Add(this.provinciaLabel);
            this.clientiGroupBox.Controls.Add(this.civicoLabel);
            this.clientiGroupBox.Controls.Add(this.viaLabel);
            this.clientiGroupBox.Controls.Add(this.ragioneSocialeLabel);
            this.clientiGroupBox.Controls.Add(this.idLabel);
            this.clientiGroupBox.Controls.Add(this.noteValue);
            this.clientiGroupBox.Controls.Add(this.deleteButton);
            this.clientiGroupBox.Controls.Add(this.addButton);
            this.clientiGroupBox.Controls.Add(this.saveButton);
            this.clientiGroupBox.Controls.Add(this.editButton);
            this.clientiGroupBox.Controls.Add(this.listBox);
            this.clientiGroupBox.Location = new System.Drawing.Point(3, 3);
            this.clientiGroupBox.Name = "clientiGroupBox";
            this.clientiGroupBox.Size = new System.Drawing.Size(562, 288);
            this.clientiGroupBox.TabIndex = 2;
            this.clientiGroupBox.TabStop = false;
            this.clientiGroupBox.Text = "Commesse";
            // 
            // clienteValue
            // 
            this.clienteValue.FormattingEnabled = true;
            this.clienteValue.Location = new System.Drawing.Point(270, 78);
            this.clienteValue.Name = "clienteValue";
            this.clienteValue.Size = new System.Drawing.Size(286, 17);
            this.clienteValue.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Cliente";
            // 
            // annullaButton
            // 
            this.annullaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.annullaButton.Enabled = false;
            this.annullaButton.Location = new System.Drawing.Point(270, 252);
            this.annullaButton.Margin = new System.Windows.Forms.Padding(1);
            this.annullaButton.Name = "annullaButton";
            this.annullaButton.Size = new System.Drawing.Size(246, 32);
            this.annullaButton.TabIndex = 34;
            this.annullaButton.Text = "Annulla";
            this.annullaButton.UseVisualStyleBackColor = true;
            this.annullaButton.Click += new System.EventHandler(this.annullaButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 21);
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
            this.searchTextBox.Size = new System.Drawing.Size(504, 20);
            this.searchTextBox.TabIndex = 32;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // utenteValue
            // 
            this.utenteValue.Location = new System.Drawing.Point(270, 48);
            this.utenteValue.Margin = new System.Windows.Forms.Padding(1);
            this.utenteValue.Name = "utenteValue";
            this.utenteValue.Size = new System.Drawing.Size(118, 20);
            this.utenteValue.TabIndex = 22;
            // 
            // creazioneValue
            // 
            this.creazioneValue.Location = new System.Drawing.Point(269, 135);
            this.creazioneValue.Margin = new System.Windows.Forms.Padding(1);
            this.creazioneValue.Name = "creazioneValue";
            this.creazioneValue.Size = new System.Drawing.Size(287, 20);
            this.creazioneValue.TabIndex = 21;
            // 
            // codiceValue
            // 
            this.codiceValue.Location = new System.Drawing.Point(269, 105);
            this.codiceValue.Margin = new System.Windows.Forms.Padding(1);
            this.codiceValue.Name = "codiceValue";
            this.codiceValue.Size = new System.Drawing.Size(287, 20);
            this.codiceValue.TabIndex = 20;
            // 
            // chiusuraValue
            // 
            this.chiusuraValue.Location = new System.Drawing.Point(269, 165);
            this.chiusuraValue.Margin = new System.Windows.Forms.Padding(1);
            this.chiusuraValue.Name = "chiusuraValue";
            this.chiusuraValue.Size = new System.Drawing.Size(287, 20);
            this.chiusuraValue.TabIndex = 31;
            // 
            // idValue
            // 
            this.idValue.Location = new System.Drawing.Point(430, 48);
            this.idValue.Margin = new System.Windows.Forms.Padding(1);
            this.idValue.Name = "idValue";
            this.idValue.Size = new System.Drawing.Size(127, 20);
            this.idValue.TabIndex = 19;
            // 
            // dataCreazioneLabel
            // 
            this.dataCreazioneLabel.AutoSize = true;
            this.dataCreazioneLabel.Location = new System.Drawing.Point(155, 51);
            this.dataCreazioneLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dataCreazioneLabel.Name = "dataCreazioneLabel";
            this.dataCreazioneLabel.Size = new System.Drawing.Size(39, 13);
            this.dataCreazioneLabel.TabIndex = 17;
            this.dataCreazioneLabel.Text = "Utente";
            // 
            // provinciaLabel
            // 
            this.provinciaLabel.AutoSize = true;
            this.provinciaLabel.Location = new System.Drawing.Point(155, 198);
            this.provinciaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.provinciaLabel.Name = "provinciaLabel";
            this.provinciaLabel.Size = new System.Drawing.Size(30, 13);
            this.provinciaLabel.TabIndex = 8;
            this.provinciaLabel.Text = "Note";
            // 
            // civicoLabel
            // 
            this.civicoLabel.AutoSize = true;
            this.civicoLabel.Location = new System.Drawing.Point(155, 168);
            this.civicoLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.civicoLabel.Name = "civicoLabel";
            this.civicoLabel.Size = new System.Drawing.Size(74, 13);
            this.civicoLabel.TabIndex = 7;
            this.civicoLabel.Text = "Data Chiusura";
            // 
            // viaLabel
            // 
            this.viaLabel.AutoSize = true;
            this.viaLabel.Location = new System.Drawing.Point(155, 138);
            this.viaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.viaLabel.Name = "viaLabel";
            this.viaLabel.Size = new System.Drawing.Size(80, 13);
            this.viaLabel.TabIndex = 6;
            this.viaLabel.Text = "Data Creazione";
            // 
            // ragioneSocialeLabel
            // 
            this.ragioneSocialeLabel.AutoSize = true;
            this.ragioneSocialeLabel.Location = new System.Drawing.Point(155, 108);
            this.ragioneSocialeLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ragioneSocialeLabel.Name = "ragioneSocialeLabel";
            this.ragioneSocialeLabel.Size = new System.Drawing.Size(40, 13);
            this.ragioneSocialeLabel.TabIndex = 18;
            this.ragioneSocialeLabel.Text = "Codice";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(410, 51);
            this.idLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 5;
            this.idLabel.Text = "ID";
            // 
            // noteValue
            // 
            this.noteValue.Location = new System.Drawing.Point(269, 195);
            this.noteValue.Margin = new System.Windows.Forms.Padding(1);
            this.noteValue.Multiline = true;
            this.noteValue.Name = "noteValue";
            this.noteValue.Size = new System.Drawing.Size(287, 47);
            this.noteValue.TabIndex = 4;
            // 
            // deleteButton
            // 
            this.deleteButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.delete_512;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButton.Location = new System.Drawing.Point(231, 252);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(1);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(30, 32);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.add_user_128;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButton.Location = new System.Drawing.Point(526, 252);
            this.addButton.Margin = new System.Windows.Forms.Padding(1);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(30, 32);
            this.addButton.TabIndex = 3;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.floppy_disk_icon_8284;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(194, 252);
            this.saveButton.Margin = new System.Windows.Forms.Padding(1);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(30, 32);
            this.saveButton.TabIndex = 3;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // editButton
            // 
            this.editButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.editor_pencil_pen_edit_write_glyph_128;
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editButton.Location = new System.Drawing.Point(157, 252);
            this.editButton.Margin = new System.Windows.Forms.Padding(1);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(30, 32);
            this.editButton.TabIndex = 3;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(6, 46);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(140, 238);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.commesseListBox_SelectedIndexChanged);
            // 
            // Commesse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientiGroupBox);
            this.Name = "Commesse";
            this.Size = new System.Drawing.Size(568, 294);
            this.clientiGroupBox.ResumeLayout(false);
            this.clientiGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox clientiGroupBox;
        private System.Windows.Forms.Button annullaButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox utenteValue;
        private System.Windows.Forms.TextBox creazioneValue;
        private System.Windows.Forms.TextBox codiceValue;
        private System.Windows.Forms.TextBox chiusuraValue;
        private System.Windows.Forms.TextBox idValue;
        private System.Windows.Forms.Label dataCreazioneLabel;
        private System.Windows.Forms.Label provinciaLabel;
        private System.Windows.Forms.Label civicoLabel;
        private System.Windows.Forms.Label viaLabel;
        private System.Windows.Forms.Label ragioneSocialeLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox noteValue;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ListBox clienteValue;
        private System.Windows.Forms.Label label2;
    }
}
