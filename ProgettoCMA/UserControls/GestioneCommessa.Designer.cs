namespace ProgettoCMA
{
    partial class GestioneCommessa
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.idValue = new System.Windows.Forms.TextBox();
            this.clienteValue = new System.Windows.Forms.TextBox();
            this.noteValue = new System.Windows.Forms.TextBox();
            this.creazioneValue = new System.Windows.Forms.TextBox();
            this.chiusuraValue = new System.Windows.Forms.TextBox();
            this.codiceValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ragioneSocialeLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.clientiGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientiGroupBox
            // 
            this.clientiGroupBox.Controls.Add(this.groupBox3);
            this.clientiGroupBox.Controls.Add(this.groupBox2);
            this.clientiGroupBox.Controls.Add(this.groupBox1);
            this.clientiGroupBox.Location = new System.Drawing.Point(3, 3);
            this.clientiGroupBox.Name = "clientiGroupBox";
            this.clientiGroupBox.Size = new System.Drawing.Size(789, 527);
            this.clientiGroupBox.TabIndex = 1;
            this.clientiGroupBox.TabStop = false;
            this.clientiGroupBox.Text = "Commessa";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(6, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 247);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordini di Acquisto";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(6, 65);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(188, 160);
            this.listBox2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Nuovo Ordine";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.editButton);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(273, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 232);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Richieste di Offerta";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(188, 160);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ragioneSocialeLabel);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 232);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Riepilogo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.idValue);
            this.panel1.Controls.Add(this.clienteValue);
            this.panel1.Controls.Add(this.noteValue);
            this.panel1.Controls.Add(this.creazioneValue);
            this.panel1.Controls.Add(this.chiusuraValue);
            this.panel1.Controls.Add(this.codiceValue);
            this.panel1.Location = new System.Drawing.Point(91, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 216);
            this.panel1.TabIndex = 58;
            // 
            // idValue
            // 
            this.idValue.Location = new System.Drawing.Point(3, 12);
            this.idValue.Margin = new System.Windows.Forms.Padding(1);
            this.idValue.Name = "idValue";
            this.idValue.Size = new System.Drawing.Size(158, 20);
            this.idValue.TabIndex = 52;
            // 
            // clienteValue
            // 
            this.clienteValue.Location = new System.Drawing.Point(3, 40);
            this.clienteValue.Margin = new System.Windows.Forms.Padding(1);
            this.clienteValue.Name = "clienteValue";
            this.clienteValue.Size = new System.Drawing.Size(158, 20);
            this.clienteValue.TabIndex = 57;
            // 
            // noteValue
            // 
            this.noteValue.Location = new System.Drawing.Point(3, 159);
            this.noteValue.Margin = new System.Windows.Forms.Padding(1);
            this.noteValue.Multiline = true;
            this.noteValue.Name = "noteValue";
            this.noteValue.Size = new System.Drawing.Size(158, 53);
            this.noteValue.TabIndex = 51;
            // 
            // creazioneValue
            // 
            this.creazioneValue.Location = new System.Drawing.Point(3, 99);
            this.creazioneValue.Margin = new System.Windows.Forms.Padding(1);
            this.creazioneValue.Name = "creazioneValue";
            this.creazioneValue.Size = new System.Drawing.Size(158, 20);
            this.creazioneValue.TabIndex = 54;
            // 
            // chiusuraValue
            // 
            this.chiusuraValue.Location = new System.Drawing.Point(3, 129);
            this.chiusuraValue.Margin = new System.Windows.Forms.Padding(1);
            this.chiusuraValue.Name = "chiusuraValue";
            this.chiusuraValue.Size = new System.Drawing.Size(158, 20);
            this.chiusuraValue.TabIndex = 55;
            // 
            // codiceValue
            // 
            this.codiceValue.Location = new System.Drawing.Point(3, 69);
            this.codiceValue.Margin = new System.Windows.Forms.Padding(1);
            this.codiceValue.Name = "codiceValue";
            this.codiceValue.Size = new System.Drawing.Size(158, 20);
            this.codiceValue.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 56);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Cliente";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 28);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 175);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Note";
            // 
            // ragioneSocialeLabel
            // 
            this.ragioneSocialeLabel.AutoSize = true;
            this.ragioneSocialeLabel.Location = new System.Drawing.Point(8, 85);
            this.ragioneSocialeLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ragioneSocialeLabel.Name = "ragioneSocialeLabel";
            this.ragioneSocialeLabel.Size = new System.Drawing.Size(40, 13);
            this.ragioneSocialeLabel.TabIndex = 44;
            this.ragioneSocialeLabel.Text = "Codice";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 145);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Data Chiusura";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 115);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Data Creazione";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(40, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "Visualizza";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.add_user_128;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButton.Location = new System.Drawing.Point(164, 193);
            this.addButton.Margin = new System.Windows.Forms.Padding(1);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(30, 32);
            this.addButton.TabIndex = 61;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // editButton
            // 
            this.editButton.BackgroundImage = global::ProgettoCMA.Properties.Resources.editor_pencil_pen_edit_write_glyph_128;
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editButton.Location = new System.Drawing.Point(6, 193);
            this.editButton.Margin = new System.Windows.Forms.Padding(1);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(30, 32);
            this.editButton.TabIndex = 62;
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // GestioneCommessa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientiGroupBox);
            this.Name = "GestioneCommessa";
            this.Size = new System.Drawing.Size(800, 534);
            this.clientiGroupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox clientiGroupBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label ragioneSocialeLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox clienteValue;
        private System.Windows.Forms.TextBox creazioneValue;
        private System.Windows.Forms.TextBox codiceValue;
        private System.Windows.Forms.TextBox chiusuraValue;
        private System.Windows.Forms.TextBox idValue;
        private System.Windows.Forms.TextBox noteValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
    }
}
