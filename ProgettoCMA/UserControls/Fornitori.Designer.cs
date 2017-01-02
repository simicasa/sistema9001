namespace ProgettoCMA
{
    public partial class Fornitori : UC<Fornitore, Categoria, Associazione_Categoria_Fornitore>
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
            this.mailValue = new System.Windows.Forms.TextBox();
            this.telefonoValue = new System.Windows.Forms.TextBox();
            this.codFiscValue = new System.Windows.Forms.TextBox();
            this.pIvaValue = new System.Windows.Forms.TextBox();
            this.nazioneValue = new System.Windows.Forms.TextBox();
            this.cittaValue = new System.Windows.Forms.TextBox();
            this.capValue = new System.Windows.Forms.TextBox();
            this.provinciaValue = new System.Windows.Forms.TextBox();
            this.civicoValue = new System.Windows.Forms.TextBox();
            this.viaValue = new System.Windows.Forms.TextBox();
            this.ragioneValue = new System.Windows.Forms.TextBox();
            this.creazioneValue = new System.Windows.Forms.TextBox();
            this.idValue = new System.Windows.Forms.TextBox();
            this.dataCreazioneLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.telefonoLabel = new System.Windows.Forms.Label();
            this.codiceFiscaleLabel = new System.Windows.Forms.Label();
            this.partitaIvaLabel = new System.Windows.Forms.Label();
            this.nazioneLabel = new System.Windows.Forms.Label();
            this.cittaLabel = new System.Windows.Forms.Label();
            this.capLabel = new System.Windows.Forms.Label();
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
            this.clientiGroupBox = new System.Windows.Forms.GroupBox();
            this.categoriaRemoveButton = new System.Windows.Forms.Button();
            this.categoriaAddButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.clientiGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // annullaButton
            // 
            this.annullaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.annullaButton.Enabled = false;
            this.annullaButton.Location = new System.Drawing.Point(270, 445);
            this.annullaButton.Margin = new System.Windows.Forms.Padding(1);
            this.annullaButton.Name = "annullaButton";
            this.annullaButton.Size = new System.Drawing.Size(246, 32);
            this.annullaButton.TabIndex = 34;
            this.annullaButton.Text = "Annulla";
            this.annullaButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 21);
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
            this.searchTextBox.Size = new System.Drawing.Size(320, 20);
            this.searchTextBox.TabIndex = 32;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // mailValue
            // 
            this.mailValue.Location = new System.Drawing.Point(270, 361);
            this.mailValue.Margin = new System.Windows.Forms.Padding(1);
            this.mailValue.Name = "mailValue";
            this.mailValue.Size = new System.Drawing.Size(287, 20);
            this.mailValue.TabIndex = 30;
            // 
            // telefonoValue
            // 
            this.telefonoValue.Location = new System.Drawing.Point(270, 333);
            this.telefonoValue.Margin = new System.Windows.Forms.Padding(1);
            this.telefonoValue.Name = "telefonoValue";
            this.telefonoValue.Size = new System.Drawing.Size(287, 20);
            this.telefonoValue.TabIndex = 29;
            // 
            // codFiscValue
            // 
            this.codFiscValue.Location = new System.Drawing.Point(270, 304);
            this.codFiscValue.Margin = new System.Windows.Forms.Padding(1);
            this.codFiscValue.Name = "codFiscValue";
            this.codFiscValue.Size = new System.Drawing.Size(287, 20);
            this.codFiscValue.TabIndex = 28;
            // 
            // pIvaValue
            // 
            this.pIvaValue.Location = new System.Drawing.Point(270, 276);
            this.pIvaValue.Margin = new System.Windows.Forms.Padding(1);
            this.pIvaValue.Name = "pIvaValue";
            this.pIvaValue.Size = new System.Drawing.Size(287, 20);
            this.pIvaValue.TabIndex = 27;
            // 
            // nazioneValue
            // 
            this.nazioneValue.Location = new System.Drawing.Point(270, 248);
            this.nazioneValue.Margin = new System.Windows.Forms.Padding(1);
            this.nazioneValue.Name = "nazioneValue";
            this.nazioneValue.Size = new System.Drawing.Size(287, 20);
            this.nazioneValue.TabIndex = 26;
            // 
            // cittaValue
            // 
            this.cittaValue.Location = new System.Drawing.Point(270, 220);
            this.cittaValue.Margin = new System.Windows.Forms.Padding(1);
            this.cittaValue.Name = "cittaValue";
            this.cittaValue.Size = new System.Drawing.Size(287, 20);
            this.cittaValue.TabIndex = 25;
            // 
            // capValue
            // 
            this.capValue.Location = new System.Drawing.Point(270, 191);
            this.capValue.Margin = new System.Windows.Forms.Padding(1);
            this.capValue.Name = "capValue";
            this.capValue.Size = new System.Drawing.Size(287, 20);
            this.capValue.TabIndex = 24;
            // 
            // provinciaValue
            // 
            this.provinciaValue.Location = new System.Drawing.Point(270, 163);
            this.provinciaValue.Margin = new System.Windows.Forms.Padding(1);
            this.provinciaValue.Name = "provinciaValue";
            this.provinciaValue.Size = new System.Drawing.Size(287, 20);
            this.provinciaValue.TabIndex = 23;
            // 
            // civicoValue
            // 
            this.civicoValue.Location = new System.Drawing.Point(270, 135);
            this.civicoValue.Margin = new System.Windows.Forms.Padding(1);
            this.civicoValue.Name = "civicoValue";
            this.civicoValue.Size = new System.Drawing.Size(287, 20);
            this.civicoValue.TabIndex = 22;
            // 
            // viaValue
            // 
            this.viaValue.Location = new System.Drawing.Point(270, 107);
            this.viaValue.Margin = new System.Windows.Forms.Padding(1);
            this.viaValue.Name = "viaValue";
            this.viaValue.Size = new System.Drawing.Size(287, 20);
            this.viaValue.TabIndex = 21;
            // 
            // ragioneValue
            // 
            this.ragioneValue.Location = new System.Drawing.Point(270, 78);
            this.ragioneValue.Margin = new System.Windows.Forms.Padding(1);
            this.ragioneValue.Name = "ragioneValue";
            this.ragioneValue.Size = new System.Drawing.Size(287, 20);
            this.ragioneValue.TabIndex = 20;
            // 
            // creazioneValue
            // 
            this.creazioneValue.Location = new System.Drawing.Point(270, 48);
            this.creazioneValue.Margin = new System.Windows.Forms.Padding(1);
            this.creazioneValue.Name = "creazioneValue";
            this.creazioneValue.Size = new System.Drawing.Size(118, 20);
            this.creazioneValue.TabIndex = 31;
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
            this.dataCreazioneLabel.Location = new System.Drawing.Point(155, 49);
            this.dataCreazioneLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dataCreazioneLabel.Name = "dataCreazioneLabel";
            this.dataCreazioneLabel.Size = new System.Drawing.Size(80, 13);
            this.dataCreazioneLabel.TabIndex = 17;
            this.dataCreazioneLabel.Text = "Data Creazione";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(155, 390);
            this.noteLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(30, 13);
            this.noteLabel.TabIndex = 16;
            this.noteLabel.Text = "Note";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(155, 362);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 15;
            this.emailLabel.Text = "Email";
            // 
            // telefonoLabel
            // 
            this.telefonoLabel.AutoSize = true;
            this.telefonoLabel.Location = new System.Drawing.Point(155, 334);
            this.telefonoLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.telefonoLabel.Name = "telefonoLabel";
            this.telefonoLabel.Size = new System.Drawing.Size(49, 13);
            this.telefonoLabel.TabIndex = 14;
            this.telefonoLabel.Text = "Telefono";
            // 
            // codiceFiscaleLabel
            // 
            this.codiceFiscaleLabel.AutoSize = true;
            this.codiceFiscaleLabel.Location = new System.Drawing.Point(155, 306);
            this.codiceFiscaleLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.codiceFiscaleLabel.Name = "codiceFiscaleLabel";
            this.codiceFiscaleLabel.Size = new System.Drawing.Size(76, 13);
            this.codiceFiscaleLabel.TabIndex = 13;
            this.codiceFiscaleLabel.Text = "Codice Fiscale";
            // 
            // partitaIvaLabel
            // 
            this.partitaIvaLabel.AutoSize = true;
            this.partitaIvaLabel.Location = new System.Drawing.Point(155, 277);
            this.partitaIvaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.partitaIvaLabel.Name = "partitaIvaLabel";
            this.partitaIvaLabel.Size = new System.Drawing.Size(57, 13);
            this.partitaIvaLabel.TabIndex = 12;
            this.partitaIvaLabel.Text = "Partita IVA";
            // 
            // nazioneLabel
            // 
            this.nazioneLabel.AutoSize = true;
            this.nazioneLabel.Location = new System.Drawing.Point(155, 249);
            this.nazioneLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.nazioneLabel.Name = "nazioneLabel";
            this.nazioneLabel.Size = new System.Drawing.Size(46, 13);
            this.nazioneLabel.TabIndex = 11;
            this.nazioneLabel.Text = "Nazione";
            // 
            // cittaLabel
            // 
            this.cittaLabel.AutoSize = true;
            this.cittaLabel.Location = new System.Drawing.Point(155, 221);
            this.cittaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.cittaLabel.Name = "cittaLabel";
            this.cittaLabel.Size = new System.Drawing.Size(28, 13);
            this.cittaLabel.TabIndex = 10;
            this.cittaLabel.Text = "Città";
            // 
            // capLabel
            // 
            this.capLabel.AutoSize = true;
            this.capLabel.Location = new System.Drawing.Point(155, 193);
            this.capLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.capLabel.Name = "capLabel";
            this.capLabel.Size = new System.Drawing.Size(28, 13);
            this.capLabel.TabIndex = 9;
            this.capLabel.Text = "CAP";
            // 
            // provinciaLabel
            // 
            this.provinciaLabel.AutoSize = true;
            this.provinciaLabel.Location = new System.Drawing.Point(155, 165);
            this.provinciaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.provinciaLabel.Name = "provinciaLabel";
            this.provinciaLabel.Size = new System.Drawing.Size(51, 13);
            this.provinciaLabel.TabIndex = 8;
            this.provinciaLabel.Text = "Provincia";
            // 
            // civicoLabel
            // 
            this.civicoLabel.AutoSize = true;
            this.civicoLabel.Location = new System.Drawing.Point(155, 136);
            this.civicoLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.civicoLabel.Name = "civicoLabel";
            this.civicoLabel.Size = new System.Drawing.Size(36, 13);
            this.civicoLabel.TabIndex = 7;
            this.civicoLabel.Text = "Civico";
            // 
            // viaLabel
            // 
            this.viaLabel.AutoSize = true;
            this.viaLabel.Location = new System.Drawing.Point(155, 108);
            this.viaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.viaLabel.Name = "viaLabel";
            this.viaLabel.Size = new System.Drawing.Size(22, 13);
            this.viaLabel.TabIndex = 6;
            this.viaLabel.Text = "Via";
            // 
            // ragioneSocialeLabel
            // 
            this.ragioneSocialeLabel.AutoSize = true;
            this.ragioneSocialeLabel.Location = new System.Drawing.Point(155, 80);
            this.ragioneSocialeLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ragioneSocialeLabel.Name = "ragioneSocialeLabel";
            this.ragioneSocialeLabel.Size = new System.Drawing.Size(85, 13);
            this.ragioneSocialeLabel.TabIndex = 18;
            this.ragioneSocialeLabel.Text = "Ragione Sociale";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(413, 49);
            this.idLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 5;
            this.idLabel.Text = "ID";
            // 
            // noteValue
            // 
            this.noteValue.Location = new System.Drawing.Point(270, 389);
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
            this.deleteButton.Location = new System.Drawing.Point(231, 445);
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
            this.addButton.Location = new System.Drawing.Point(526, 445);
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
            this.saveButton.Location = new System.Drawing.Point(194, 445);
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
            this.editButton.Location = new System.Drawing.Point(157, 445);
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
            this.listBox.Size = new System.Drawing.Size(140, 433);
            this.listBox.TabIndex = 0;
            // 
            // clientiGroupBox
            // 
            this.clientiGroupBox.Controls.Add(this.categoriaRemoveButton);
            this.clientiGroupBox.Controls.Add(this.categoriaAddButton);
            this.clientiGroupBox.Controls.Add(this.textBox1);
            this.clientiGroupBox.Controls.Add(this.listBox2);
            this.clientiGroupBox.Controls.Add(this.listBox1);
            this.clientiGroupBox.Controls.Add(this.annullaButton);
            this.clientiGroupBox.Controls.Add(this.label1);
            this.clientiGroupBox.Controls.Add(this.searchTextBox);
            this.clientiGroupBox.Controls.Add(this.mailValue);
            this.clientiGroupBox.Controls.Add(this.telefonoValue);
            this.clientiGroupBox.Controls.Add(this.codFiscValue);
            this.clientiGroupBox.Controls.Add(this.pIvaValue);
            this.clientiGroupBox.Controls.Add(this.nazioneValue);
            this.clientiGroupBox.Controls.Add(this.cittaValue);
            this.clientiGroupBox.Controls.Add(this.capValue);
            this.clientiGroupBox.Controls.Add(this.provinciaValue);
            this.clientiGroupBox.Controls.Add(this.civicoValue);
            this.clientiGroupBox.Controls.Add(this.viaValue);
            this.clientiGroupBox.Controls.Add(this.ragioneValue);
            this.clientiGroupBox.Controls.Add(this.creazioneValue);
            this.clientiGroupBox.Controls.Add(this.idValue);
            this.clientiGroupBox.Controls.Add(this.dataCreazioneLabel);
            this.clientiGroupBox.Controls.Add(this.noteLabel);
            this.clientiGroupBox.Controls.Add(this.emailLabel);
            this.clientiGroupBox.Controls.Add(this.telefonoLabel);
            this.clientiGroupBox.Controls.Add(this.codiceFiscaleLabel);
            this.clientiGroupBox.Controls.Add(this.partitaIvaLabel);
            this.clientiGroupBox.Controls.Add(this.nazioneLabel);
            this.clientiGroupBox.Controls.Add(this.cittaLabel);
            this.clientiGroupBox.Controls.Add(this.capLabel);
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
            this.clientiGroupBox.Location = new System.Drawing.Point(3, 2);
            this.clientiGroupBox.Name = "clientiGroupBox";
            this.clientiGroupBox.Size = new System.Drawing.Size(712, 485);
            this.clientiGroupBox.TabIndex = 1;
            this.clientiGroupBox.TabStop = false;
            this.clientiGroupBox.Text = "Fornitori";
            // 
            // categoriaRemoveButton
            // 
            this.categoriaRemoveButton.Location = new System.Drawing.Point(640, 238);
            this.categoriaRemoveButton.Name = "categoriaRemoveButton";
            this.categoriaRemoveButton.Size = new System.Drawing.Size(24, 47);
            this.categoriaRemoveButton.TabIndex = 39;
            this.categoriaRemoveButton.Text = "^";
            this.categoriaRemoveButton.UseVisualStyleBackColor = true;
            this.categoriaRemoveButton.Click += new System.EventHandler(this.categoriaRemoveButton_Click);
            // 
            // categoriaAddButton
            // 
            this.categoriaAddButton.Location = new System.Drawing.Point(610, 238);
            this.categoriaAddButton.Name = "categoriaAddButton";
            this.categoriaAddButton.Size = new System.Drawing.Size(24, 47);
            this.categoriaAddButton.TabIndex = 38;
            this.categoriaAddButton.Text = "v";
            this.categoriaAddButton.UseVisualStyleBackColor = true;
            this.categoriaAddButton.Click += new System.EventHandler(this.categoriaAddButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(386, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(320, 20);
            this.textBox1.TabIndex = 37;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(566, 291);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(140, 186);
            this.listBox2.TabIndex = 36;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(566, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(140, 186);
            this.listBox1.TabIndex = 35;
            // 
            // Fornitori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientiGroupBox);
            this.Name = "Fornitori";
            this.Size = new System.Drawing.Size(719, 490);
            this.clientiGroupBox.ResumeLayout(false);
            this.clientiGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button annullaButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox mailValue;
        private System.Windows.Forms.TextBox telefonoValue;
        private System.Windows.Forms.TextBox codFiscValue;
        private System.Windows.Forms.TextBox pIvaValue;
        private System.Windows.Forms.TextBox nazioneValue;
        private System.Windows.Forms.TextBox cittaValue;
        private System.Windows.Forms.TextBox capValue;
        private System.Windows.Forms.TextBox provinciaValue;
        private System.Windows.Forms.TextBox civicoValue;
        private System.Windows.Forms.TextBox viaValue;
        private System.Windows.Forms.TextBox ragioneValue;
        private System.Windows.Forms.TextBox creazioneValue;
        private System.Windows.Forms.TextBox idValue;
        private System.Windows.Forms.Label dataCreazioneLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label telefonoLabel;
        private System.Windows.Forms.Label codiceFiscaleLabel;
        private System.Windows.Forms.Label partitaIvaLabel;
        private System.Windows.Forms.Label nazioneLabel;
        private System.Windows.Forms.Label cittaLabel;
        private System.Windows.Forms.Label capLabel;
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
        private System.Windows.Forms.GroupBox clientiGroupBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button categoriaRemoveButton;
        private System.Windows.Forms.Button categoriaAddButton;
    }
}
