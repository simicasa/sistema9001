namespace ProgettoCMA
{
    partial class CategorieOld
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
            this.button1 = new System.Windows.Forms.Button();
            this.ultimoPrezzoValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ultimoFornitoreValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMacro = new System.Windows.Forms.Panel();
            this.hasMacro = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.macroValue = new System.Windows.Forms.ComboBox();
            this.panelMicro = new System.Windows.Forms.Panel();
            this.microValue1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clientiGroupBox.SuspendLayout();
            this.panelMacro.SuspendLayout();
            this.panelMicro.SuspendLayout();
            this.SuspendLayout();
            // 
            // annullaButton
            // 
            this.annullaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.annullaButton.Enabled = false;
            this.annullaButton.Location = new System.Drawing.Point(270, 278);
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
            this.nomeValue.Location = new System.Drawing.Point(251, 78);
            this.nomeValue.Margin = new System.Windows.Forms.Padding(1);
            this.nomeValue.Name = "nomeValue";
            this.nomeValue.Size = new System.Drawing.Size(206, 20);
            this.nomeValue.TabIndex = 20;
            // 
            // idValue
            // 
            this.idValue.Location = new System.Drawing.Point(251, 48);
            this.idValue.Margin = new System.Windows.Forms.Padding(1);
            this.idValue.Name = "idValue";
            this.idValue.Size = new System.Drawing.Size(206, 20);
            this.idValue.TabIndex = 19;
            // 
            // ragioneSocialeLabel
            // 
            this.ragioneSocialeLabel.AutoSize = true;
            this.ragioneSocialeLabel.Location = new System.Drawing.Point(155, 79);
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
            this.deleteButton.Location = new System.Drawing.Point(232, 278);
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
            this.addButton.Location = new System.Drawing.Point(425, 278);
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
            this.saveButton.Location = new System.Drawing.Point(194, 278);
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
            this.editButton.Location = new System.Drawing.Point(156, 278);
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
            this.listBox.Size = new System.Drawing.Size(140, 264);
            this.listBox.TabIndex = 0;
            // 
            // clientiGroupBox
            // 
            this.clientiGroupBox.Controls.Add(this.button1);
            this.clientiGroupBox.Controls.Add(this.ultimoPrezzoValue);
            this.clientiGroupBox.Controls.Add(this.label4);
            this.clientiGroupBox.Controls.Add(this.ultimoFornitoreValue);
            this.clientiGroupBox.Controls.Add(this.label3);
            this.clientiGroupBox.Controls.Add(this.panelMacro);
            this.clientiGroupBox.Controls.Add(this.panelMicro);
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
            this.clientiGroupBox.Location = new System.Drawing.Point(3, 3);
            this.clientiGroupBox.Name = "clientiGroupBox";
            this.clientiGroupBox.Size = new System.Drawing.Size(463, 317);
            this.clientiGroupBox.TabIndex = 1;
            this.clientiGroupBox.TabStop = false;
            this.clientiGroupBox.Text = "CategorieOld";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 39);
            this.button1.TabIndex = 47;
            this.button1.Text = "CHIEDERE";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ultimoPrezzoValue
            // 
            this.ultimoPrezzoValue.Location = new System.Drawing.Point(251, 221);
            this.ultimoPrezzoValue.Margin = new System.Windows.Forms.Padding(1);
            this.ultimoPrezzoValue.Name = "ultimoPrezzoValue";
            this.ultimoPrezzoValue.Size = new System.Drawing.Size(206, 20);
            this.ultimoPrezzoValue.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 224);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Ultimo Prezzo";
            // 
            // ultimoFornitoreValue
            // 
            this.ultimoFornitoreValue.Location = new System.Drawing.Point(251, 251);
            this.ultimoFornitoreValue.Margin = new System.Windows.Forms.Padding(1);
            this.ultimoFornitoreValue.Name = "ultimoFornitoreValue";
            this.ultimoFornitoreValue.Size = new System.Drawing.Size(206, 20);
            this.ultimoFornitoreValue.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 252);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Ultimo Fornitore";
            // 
            // panelMacro
            // 
            this.panelMacro.Controls.Add(this.hasMacro);
            this.panelMacro.Controls.Add(this.label2);
            this.panelMacro.Controls.Add(this.macroValue);
            this.panelMacro.Location = new System.Drawing.Point(152, 103);
            this.panelMacro.Name = "panelMacro";
            this.panelMacro.Size = new System.Drawing.Size(306, 32);
            this.panelMacro.TabIndex = 42;
            // 
            // hasMacro
            // 
            this.hasMacro.AutoSize = true;
            this.hasMacro.Location = new System.Drawing.Point(290, 8);
            this.hasMacro.Name = "hasMacro";
            this.hasMacro.Size = new System.Drawing.Size(15, 14);
            this.hasMacro.TabIndex = 39;
            this.hasMacro.UseVisualStyleBackColor = true;
            this.hasMacro.CheckedChanged += new System.EventHandler(this.hasMacro_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "MacroCategoria";
            // 
            // macroValue
            // 
            this.macroValue.FormattingEnabled = true;
            this.macroValue.Location = new System.Drawing.Point(99, 5);
            this.macroValue.Name = "macroValue";
            this.macroValue.Size = new System.Drawing.Size(185, 21);
            this.macroValue.TabIndex = 35;
            // 
            // panelMicro
            // 
            this.panelMicro.Controls.Add(this.microValue1);
            this.panelMicro.Controls.Add(this.label5);
            this.panelMicro.Location = new System.Drawing.Point(150, 107);
            this.panelMicro.Name = "panelMicro";
            this.panelMicro.Size = new System.Drawing.Size(311, 110);
            this.panelMicro.TabIndex = 40;
            // 
            // microValue1
            // 
            this.microValue1.Location = new System.Drawing.Point(101, 1);
            this.microValue1.Margin = new System.Windows.Forms.Padding(1);
            this.microValue1.Multiline = true;
            this.microValue1.Name = "microValue1";
            this.microValue1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.microValue1.Size = new System.Drawing.Size(206, 103);
            this.microValue1.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "MicroCategorie";
            // 
            // CategorieOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientiGroupBox);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CategorieOld";
            this.Size = new System.Drawing.Size(469, 322);
            this.clientiGroupBox.ResumeLayout(false);
            this.clientiGroupBox.PerformLayout();
            this.panelMacro.ResumeLayout(false);
            this.panelMacro.PerformLayout();
            this.panelMicro.ResumeLayout(false);
            this.panelMicro.PerformLayout();
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
        private System.Windows.Forms.CheckBox hasMacro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox macroValue;
        private System.Windows.Forms.Panel panelMicro;
        private System.Windows.Forms.Panel panelMacro;
        private System.Windows.Forms.TextBox microValue1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ultimoPrezzoValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ultimoFornitoreValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}
