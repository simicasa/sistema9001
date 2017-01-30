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
            this.idLabel = new System.Windows.Forms.Label();
            this.ragioneSocialeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataCreazioneLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxUC1 = new ProgettoCMA.Controller.ComboBoxUC();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.annullaButton = new System.Windows.Forms.Button();
            this.listBoxUC1 = new ProgettoCMA.Controller.ListBoxUC();
            this.partitaIvaLabel = new System.Windows.Forms.Label();
            this.categoriaPanel = new System.Windows.Forms.Panel();
            this.comboBoxUC2 = new ProgettoCMA.Controller.ComboBoxUC();
            this.listBoxUC2 = new ProgettoCMA.Controller.ListBoxUC();
            this.nome = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.editButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clientiGroupBox = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.categoriaPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.clientiGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(340, 4);
            this.idLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 5;
            this.idLabel.Text = "ID";
            // 
            // ragioneSocialeLabel
            // 
            this.ragioneSocialeLabel.AutoSize = true;
            this.ragioneSocialeLabel.Location = new System.Drawing.Point(1, 32);
            this.ragioneSocialeLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ragioneSocialeLabel.Name = "ragioneSocialeLabel";
            this.ragioneSocialeLabel.Size = new System.Drawing.Size(35, 13);
            this.ragioneSocialeLabel.TabIndex = 18;
            this.ragioneSocialeLabel.Text = "Nome";
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
            // dataCreazioneLabel
            // 
            this.dataCreazioneLabel.AutoSize = true;
            this.dataCreazioneLabel.Location = new System.Drawing.Point(1, 4);
            this.dataCreazioneLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dataCreazioneLabel.Name = "dataCreazioneLabel";
            this.dataCreazioneLabel.Size = new System.Drawing.Size(84, 13);
            this.dataCreazioneLabel.TabIndex = 17;
            this.dataCreazioneLabel.Text = "Macro categoria";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxUC1);
            this.groupBox1.Controls.Add(this.searchTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 75);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtri";
            // 
            // comboBoxUC1
            // 
            this.comboBoxUC1.FormattingEnabled = true;
            this.comboBoxUC1.Location = new System.Drawing.Point(66, 43);
            this.comboBoxUC1.Name = "comboBoxUC1";
            this.comboBoxUC1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUC1.TabIndex = 34;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(66, 20);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(121, 20);
            this.searchTextBox.TabIndex = 32;
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
            // listBoxUC1
            // 
            this.listBoxUC1.FormattingEnabled = true;
            this.listBoxUC1.Location = new System.Drawing.Point(6, 100);
            this.listBoxUC1.Name = "listBoxUC1";
            this.listBoxUC1.Size = new System.Drawing.Size(198, 368);
            this.listBoxUC1.TabIndex = 36;
            // 
            // partitaIvaLabel
            // 
            this.partitaIvaLabel.AutoSize = true;
            this.partitaIvaLabel.Location = new System.Drawing.Point(1, 60);
            this.partitaIvaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.partitaIvaLabel.Name = "partitaIvaLabel";
            this.partitaIvaLabel.Size = new System.Drawing.Size(80, 13);
            this.partitaIvaLabel.TabIndex = 12;
            this.partitaIvaLabel.Text = "Micro categorie";
            // 
            // categoriaPanel
            // 
            this.categoriaPanel.Controls.Add(this.checkBox1);
            this.categoriaPanel.Controls.Add(this.comboBoxUC2);
            this.categoriaPanel.Controls.Add(this.listBoxUC2);
            this.categoriaPanel.Controls.Add(this.dataCreazioneLabel);
            this.categoriaPanel.Controls.Add(this.idLabel);
            this.categoriaPanel.Controls.Add(this.ragioneSocialeLabel);
            this.categoriaPanel.Controls.Add(this.partitaIvaLabel);
            this.categoriaPanel.Controls.Add(this.nome);
            this.categoriaPanel.Controls.Add(this.id);
            this.categoriaPanel.Location = new System.Drawing.Point(6, 19);
            this.categoriaPanel.Name = "categoriaPanel";
            this.categoriaPanel.Size = new System.Drawing.Size(406, 390);
            this.categoriaPanel.TabIndex = 1;
            // 
            // comboBoxUC2
            // 
            this.comboBoxUC2.FormattingEnabled = true;
            this.comboBoxUC2.Location = new System.Drawing.Point(137, 1);
            this.comboBoxUC2.Name = "comboBoxUC2";
            this.comboBoxUC2.Size = new System.Drawing.Size(186, 21);
            this.comboBoxUC2.TabIndex = 40;
            // 
            // listBoxUC2
            // 
            this.listBoxUC2.FormattingEnabled = true;
            this.listBoxUC2.Location = new System.Drawing.Point(116, 57);
            this.listBoxUC2.Name = "listBoxUC2";
            this.listBoxUC2.Size = new System.Drawing.Size(287, 329);
            this.listBoxUC2.TabIndex = 39;
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(116, 29);
            this.nome.Margin = new System.Windows.Forms.Padding(1);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(287, 20);
            this.nome.TabIndex = 20;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(363, 1);
            this.id.Margin = new System.Windows.Forms.Padding(1);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(40, 20);
            this.id.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.categoriaPanel);
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
            this.groupBox2.Text = "Categoria selezionata";
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
            // clientiGroupBox
            // 
            this.clientiGroupBox.Controls.Add(this.groupBox2);
            this.clientiGroupBox.Controls.Add(this.groupBox1);
            this.clientiGroupBox.Controls.Add(this.listBoxUC1);
            this.clientiGroupBox.Location = new System.Drawing.Point(3, 3);
            this.clientiGroupBox.Name = "clientiGroupBox";
            this.clientiGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clientiGroupBox.Size = new System.Drawing.Size(636, 473);
            this.clientiGroupBox.TabIndex = 1;
            this.clientiGroupBox.TabStop = false;
            this.clientiGroupBox.Text = "Categorie";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(116, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 41;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Categorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientiGroupBox);
            this.Name = "Categorie";
            this.Size = new System.Drawing.Size(642, 479);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.categoriaPanel.ResumeLayout(false);
            this.categoriaPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.clientiGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label ragioneSocialeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label dataCreazioneLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controller.ComboBoxUC comboBoxUC1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button annullaButton;
        private Controller.ListBoxUC listBoxUC1;
        private System.Windows.Forms.Label partitaIvaLabel;
        private System.Windows.Forms.Panel categoriaPanel;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox clientiGroupBox;
        private Controller.ComboBoxUC comboBoxUC2;
        private Controller.ListBoxUC listBoxUC2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
