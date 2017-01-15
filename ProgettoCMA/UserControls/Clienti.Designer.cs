using System.Windows.Forms;

namespace ProgettoCMA
{
    public partial class Clienti
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clientePanel = new System.Windows.Forms.Panel();
            this.indirizzoPanel = new System.Windows.Forms.Panel();
            this.via = new System.Windows.Forms.TextBox();
            this.provinciaSigla = new System.Windows.Forms.TextBox();
            this.civico = new System.Windows.Forms.TextBox();
            this.provincia = new System.Windows.Forms.TextBox();
            this.cap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.citta = new System.Windows.Forms.TextBox();
            this.nazioneLabel = new System.Windows.Forms.Label();
            this.viaLabel = new System.Windows.Forms.Label();
            this.nazione = new System.Windows.Forms.TextBox();
            this.cittaLabel = new System.Windows.Forms.Label();
            this.civicoLabel = new System.Windows.Forms.Label();
            this.capLabel = new System.Windows.Forms.Label();
            this.provinciaLabel = new System.Windows.Forms.Label();
            this.dataCreazioneLabel = new System.Windows.Forms.Label();
            this.note = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.ragioneSocialeLabel = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.TextBox();
            this.telefono = new System.Windows.Forms.TextBox();
            this.codFisc = new System.Windows.Forms.TextBox();
            this.pIva = new System.Windows.Forms.TextBox();
            this.partitaIvaLabel = new System.Windows.Forms.Label();
            this.codiceFiscaleLabel = new System.Windows.Forms.Label();
            this.telefonoLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.ragione = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.creazione = new System.Windows.Forms.TextBox();
            this.editButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.annullaButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxUC1 = new ProgettoCMA.Controller.ListBoxUC();
            this.clientiGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.clientePanel.SuspendLayout();
            this.indirizzoPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientiGroupBox
            // 
            this.clientiGroupBox.Controls.Add(this.groupBox2);
            this.clientiGroupBox.Controls.Add(this.groupBox1);
            this.clientiGroupBox.Controls.Add(this.listBoxUC1);
            this.clientiGroupBox.Location = new System.Drawing.Point(3, 3);
            this.clientiGroupBox.Name = "clientiGroupBox";
            this.clientiGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clientiGroupBox.Size = new System.Drawing.Size(636, 473);
            this.clientiGroupBox.TabIndex = 0;
            this.clientiGroupBox.TabStop = false;
            this.clientiGroupBox.Text = "Clienti";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clientePanel);
            this.groupBox2.Controls.Add(this.editButton);
            this.groupBox2.Controls.Add(this.saveButton);
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Controls.Add(this.annullaButton);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Location = new System.Drawing.Point(210, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 449);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cliente selezionato";
            // 
            // clientePanel
            // 
            this.clientePanel.Controls.Add(this.indirizzoPanel);
            this.clientePanel.Controls.Add(this.dataCreazioneLabel);
            this.clientePanel.Controls.Add(this.note);
            this.clientePanel.Controls.Add(this.idLabel);
            this.clientePanel.Controls.Add(this.ragioneSocialeLabel);
            this.clientePanel.Controls.Add(this.mail);
            this.clientePanel.Controls.Add(this.telefono);
            this.clientePanel.Controls.Add(this.codFisc);
            this.clientePanel.Controls.Add(this.pIva);
            this.clientePanel.Controls.Add(this.partitaIvaLabel);
            this.clientePanel.Controls.Add(this.codiceFiscaleLabel);
            this.clientePanel.Controls.Add(this.telefonoLabel);
            this.clientePanel.Controls.Add(this.emailLabel);
            this.clientePanel.Controls.Add(this.noteLabel);
            this.clientePanel.Controls.Add(this.ragione);
            this.clientePanel.Controls.Add(this.id);
            this.clientePanel.Controls.Add(this.creazione);
            this.clientePanel.Location = new System.Drawing.Point(6, 19);
            this.clientePanel.Name = "clientePanel";
            this.clientePanel.Size = new System.Drawing.Size(406, 390);
            this.clientePanel.TabIndex = 1;
            // 
            // indirizzoPanel
            // 
            this.indirizzoPanel.Controls.Add(this.via);
            this.indirizzoPanel.Controls.Add(this.provinciaSigla);
            this.indirizzoPanel.Controls.Add(this.civico);
            this.indirizzoPanel.Controls.Add(this.provincia);
            this.indirizzoPanel.Controls.Add(this.cap);
            this.indirizzoPanel.Controls.Add(this.label2);
            this.indirizzoPanel.Controls.Add(this.citta);
            this.indirizzoPanel.Controls.Add(this.nazioneLabel);
            this.indirizzoPanel.Controls.Add(this.viaLabel);
            this.indirizzoPanel.Controls.Add(this.nazione);
            this.indirizzoPanel.Controls.Add(this.cittaLabel);
            this.indirizzoPanel.Controls.Add(this.civicoLabel);
            this.indirizzoPanel.Controls.Add(this.capLabel);
            this.indirizzoPanel.Controls.Add(this.provinciaLabel);
            this.indirizzoPanel.Location = new System.Drawing.Point(1, 57);
            this.indirizzoPanel.Name = "indirizzoPanel";
            this.indirizzoPanel.Size = new System.Drawing.Size(405, 164);
            this.indirizzoPanel.TabIndex = 1;
            // 
            // via
            // 
            this.via.Location = new System.Drawing.Point(116, 1);
            this.via.Margin = new System.Windows.Forms.Padding(1);
            this.via.Name = "via";
            this.via.Size = new System.Drawing.Size(287, 20);
            this.via.TabIndex = 21;
            this.via.Text = "d";
            // 
            // provinciaSigla
            // 
            this.provinciaSigla.Location = new System.Drawing.Point(363, 57);
            this.provinciaSigla.Margin = new System.Windows.Forms.Padding(1);
            this.provinciaSigla.Name = "provinciaSigla";
            this.provinciaSigla.Size = new System.Drawing.Size(41, 20);
            this.provinciaSigla.TabIndex = 35;
            this.provinciaSigla.Text = "h";
            // 
            // civico
            // 
            this.civico.Location = new System.Drawing.Point(116, 29);
            this.civico.Margin = new System.Windows.Forms.Padding(1);
            this.civico.Name = "civico";
            this.civico.Size = new System.Drawing.Size(287, 20);
            this.civico.TabIndex = 22;
            this.civico.Text = "f";
            // 
            // provincia
            // 
            this.provincia.Location = new System.Drawing.Point(116, 57);
            this.provincia.Margin = new System.Windows.Forms.Padding(1);
            this.provincia.Name = "provincia";
            this.provincia.Size = new System.Drawing.Size(207, 20);
            this.provincia.TabIndex = 23;
            this.provincia.Text = "g";
            // 
            // cap
            // 
            this.cap.Location = new System.Drawing.Point(116, 85);
            this.cap.Margin = new System.Windows.Forms.Padding(1);
            this.cap.Name = "cap";
            this.cap.Size = new System.Drawing.Size(287, 20);
            this.cap.TabIndex = 24;
            this.cap.Text = "j";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sigla";
            // 
            // citta
            // 
            this.citta.Location = new System.Drawing.Point(116, 114);
            this.citta.Margin = new System.Windows.Forms.Padding(1);
            this.citta.Name = "citta";
            this.citta.Size = new System.Drawing.Size(287, 20);
            this.citta.TabIndex = 25;
            this.citta.Text = "k";
            // 
            // nazioneLabel
            // 
            this.nazioneLabel.AutoSize = true;
            this.nazioneLabel.Location = new System.Drawing.Point(1, 143);
            this.nazioneLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.nazioneLabel.Name = "nazioneLabel";
            this.nazioneLabel.Size = new System.Drawing.Size(46, 13);
            this.nazioneLabel.TabIndex = 11;
            this.nazioneLabel.Text = "Nazione";
            // 
            // viaLabel
            // 
            this.viaLabel.AutoSize = true;
            this.viaLabel.Location = new System.Drawing.Point(1, 4);
            this.viaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.viaLabel.Name = "viaLabel";
            this.viaLabel.Size = new System.Drawing.Size(22, 13);
            this.viaLabel.TabIndex = 6;
            this.viaLabel.Text = "Via";
            // 
            // nazione
            // 
            this.nazione.Location = new System.Drawing.Point(116, 142);
            this.nazione.Margin = new System.Windows.Forms.Padding(1);
            this.nazione.Name = "nazione";
            this.nazione.Size = new System.Drawing.Size(287, 20);
            this.nazione.TabIndex = 26;
            this.nazione.Text = "l";
            // 
            // cittaLabel
            // 
            this.cittaLabel.AutoSize = true;
            this.cittaLabel.Location = new System.Drawing.Point(1, 117);
            this.cittaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.cittaLabel.Name = "cittaLabel";
            this.cittaLabel.Size = new System.Drawing.Size(28, 13);
            this.cittaLabel.TabIndex = 10;
            this.cittaLabel.Text = "Città";
            // 
            // civicoLabel
            // 
            this.civicoLabel.AutoSize = true;
            this.civicoLabel.Location = new System.Drawing.Point(1, 32);
            this.civicoLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.civicoLabel.Name = "civicoLabel";
            this.civicoLabel.Size = new System.Drawing.Size(36, 13);
            this.civicoLabel.TabIndex = 7;
            this.civicoLabel.Text = "Civico";
            // 
            // capLabel
            // 
            this.capLabel.AutoSize = true;
            this.capLabel.Location = new System.Drawing.Point(1, 88);
            this.capLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.capLabel.Name = "capLabel";
            this.capLabel.Size = new System.Drawing.Size(28, 13);
            this.capLabel.TabIndex = 9;
            this.capLabel.Text = "CAP";
            // 
            // provinciaLabel
            // 
            this.provinciaLabel.AutoSize = true;
            this.provinciaLabel.Location = new System.Drawing.Point(1, 60);
            this.provinciaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.provinciaLabel.Name = "provinciaLabel";
            this.provinciaLabel.Size = new System.Drawing.Size(51, 13);
            this.provinciaLabel.TabIndex = 8;
            this.provinciaLabel.Text = "Provincia";
            // 
            // dataCreazioneLabel
            // 
            this.dataCreazioneLabel.AutoSize = true;
            this.dataCreazioneLabel.Location = new System.Drawing.Point(2, 4);
            this.dataCreazioneLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dataCreazioneLabel.Name = "dataCreazioneLabel";
            this.dataCreazioneLabel.Size = new System.Drawing.Size(80, 13);
            this.dataCreazioneLabel.TabIndex = 17;
            this.dataCreazioneLabel.Text = "Data Creazione";
            // 
            // note
            // 
            this.note.Location = new System.Drawing.Point(117, 340);
            this.note.Margin = new System.Windows.Forms.Padding(1);
            this.note.Multiline = true;
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(287, 47);
            this.note.TabIndex = 4;
            this.note.Text = "t";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(341, 4);
            this.idLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 5;
            this.idLabel.Text = "ID";
            // 
            // ragioneSocialeLabel
            // 
            this.ragioneSocialeLabel.AutoSize = true;
            this.ragioneSocialeLabel.Location = new System.Drawing.Point(2, 32);
            this.ragioneSocialeLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ragioneSocialeLabel.Name = "ragioneSocialeLabel";
            this.ragioneSocialeLabel.Size = new System.Drawing.Size(85, 13);
            this.ragioneSocialeLabel.TabIndex = 18;
            this.ragioneSocialeLabel.Text = "Ragione Sociale";
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(117, 312);
            this.mail.Margin = new System.Windows.Forms.Padding(1);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(287, 20);
            this.mail.TabIndex = 30;
            this.mail.Text = "r";
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(117, 284);
            this.telefono.Margin = new System.Windows.Forms.Padding(1);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(287, 20);
            this.telefono.TabIndex = 29;
            this.telefono.Text = "e";
            // 
            // codFisc
            // 
            this.codFisc.Location = new System.Drawing.Point(117, 255);
            this.codFisc.Margin = new System.Windows.Forms.Padding(1);
            this.codFisc.Name = "codFisc";
            this.codFisc.Size = new System.Drawing.Size(287, 20);
            this.codFisc.TabIndex = 28;
            this.codFisc.Text = "w";
            // 
            // pIva
            // 
            this.pIva.Location = new System.Drawing.Point(117, 227);
            this.pIva.Margin = new System.Windows.Forms.Padding(1);
            this.pIva.Name = "pIva";
            this.pIva.Size = new System.Drawing.Size(287, 20);
            this.pIva.TabIndex = 27;
            this.pIva.Text = "q";
            // 
            // partitaIvaLabel
            // 
            this.partitaIvaLabel.AutoSize = true;
            this.partitaIvaLabel.Location = new System.Drawing.Point(2, 230);
            this.partitaIvaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.partitaIvaLabel.Name = "partitaIvaLabel";
            this.partitaIvaLabel.Size = new System.Drawing.Size(57, 13);
            this.partitaIvaLabel.TabIndex = 12;
            this.partitaIvaLabel.Text = "Partita IVA";
            // 
            // codiceFiscaleLabel
            // 
            this.codiceFiscaleLabel.AutoSize = true;
            this.codiceFiscaleLabel.Location = new System.Drawing.Point(2, 258);
            this.codiceFiscaleLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.codiceFiscaleLabel.Name = "codiceFiscaleLabel";
            this.codiceFiscaleLabel.Size = new System.Drawing.Size(76, 13);
            this.codiceFiscaleLabel.TabIndex = 13;
            this.codiceFiscaleLabel.Text = "Codice Fiscale";
            // 
            // telefonoLabel
            // 
            this.telefonoLabel.AutoSize = true;
            this.telefonoLabel.Location = new System.Drawing.Point(2, 287);
            this.telefonoLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.telefonoLabel.Name = "telefonoLabel";
            this.telefonoLabel.Size = new System.Drawing.Size(49, 13);
            this.telefonoLabel.TabIndex = 14;
            this.telefonoLabel.Text = "Telefono";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(2, 315);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 15;
            this.emailLabel.Text = "Email";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(2, 343);
            this.noteLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(30, 13);
            this.noteLabel.TabIndex = 16;
            this.noteLabel.Text = "Note";
            // 
            // ragione
            // 
            this.ragione.Location = new System.Drawing.Point(117, 29);
            this.ragione.Margin = new System.Windows.Forms.Padding(1);
            this.ragione.Name = "ragione";
            this.ragione.Size = new System.Drawing.Size(287, 20);
            this.ragione.TabIndex = 20;
            this.ragione.Text = "s";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(364, 1);
            this.id.Margin = new System.Windows.Forms.Padding(1);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(40, 20);
            this.id.TabIndex = 19;
            this.id.Text = "-1";
            // 
            // creazione
            // 
            this.creazione.Location = new System.Drawing.Point(117, 1);
            this.creazione.Margin = new System.Windows.Forms.Padding(1);
            this.creazione.Name = "creazione";
            this.creazione.Size = new System.Drawing.Size(207, 20);
            this.creazione.TabIndex = 31;
            this.creazione.Text = "a";
            // 
            // editButton
            // 
            this.editButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.editor_pencil_pen_edit_write_glyph_128;
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editButton.Location = new System.Drawing.Point(10, 413);
            this.editButton.Margin = new System.Windows.Forms.Padding(1);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(30, 32);
            this.editButton.TabIndex = 3;
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.floppy_disk_icon_8284;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButton.Location = new System.Drawing.Point(47, 413);
            this.saveButton.Margin = new System.Windows.Forms.Padding(1);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(30, 32);
            this.saveButton.TabIndex = 3;
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.add_user_128;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButton.Location = new System.Drawing.Point(379, 413);
            this.addButton.Margin = new System.Windows.Forms.Padding(1);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(30, 32);
            this.addButton.TabIndex = 3;
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // annullaButton
            // 
            this.annullaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.annullaButton.Location = new System.Drawing.Point(123, 413);
            this.annullaButton.Margin = new System.Windows.Forms.Padding(1);
            this.annullaButton.Name = "annullaButton";
            this.annullaButton.Size = new System.Drawing.Size(246, 32);
            this.annullaButton.TabIndex = 34;
            this.annullaButton.Text = "Annulla";
            this.annullaButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.delete_512;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButton.Location = new System.Drawing.Point(84, 413);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(1);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(30, 32);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchTextBox);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 75);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtri";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(66, 20);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(121, 20);
            this.searchTextBox.TabIndex = 32;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(66, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Ordina per";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Ricerca";
            // 
            // listBoxUC1
            // 
            this.listBoxUC1.FormattingEnabled = true;
            this.listBoxUC1.Location = new System.Drawing.Point(6, 100);
            this.listBoxUC1.Name = "listBoxUC1";
            this.listBoxUC1.Size = new System.Drawing.Size(198, 368);
            this.listBoxUC1.TabIndex = 36;
            // 
            // Clienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientiGroupBox);
            this.Name = "Clienti";
            this.Size = new System.Drawing.Size(641, 477);
            this.clientiGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.clientePanel.ResumeLayout(false);
            this.clientePanel.PerformLayout();
            this.indirizzoPanel.ResumeLayout(false);
            this.indirizzoPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox clientiGroupBox;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox note;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.TextBox telefono;
        private System.Windows.Forms.TextBox codFisc;
        private System.Windows.Forms.TextBox pIva;
        private System.Windows.Forms.TextBox nazione;
        private System.Windows.Forms.TextBox citta;
        private System.Windows.Forms.TextBox cap;
        private System.Windows.Forms.TextBox provincia;
        private System.Windows.Forms.TextBox civico;
        private System.Windows.Forms.TextBox via;
        private System.Windows.Forms.TextBox ragione;
        private System.Windows.Forms.TextBox creazione;
        private System.Windows.Forms.TextBox id;
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
        private System.Windows.Forms.Button deleteButton;
        private TextBox searchTextBox;
        private Label label1;
        private Button annullaButton;
        private TextBox provinciaSigla;
        private Label label2;
        private Controller.ListBoxUC listBoxUC1;
        private Panel clientePanel;
        private Panel indirizzoPanel;
        private ComboBox comboBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label3;
    }
}
