namespace ProgettoCMA
{
    partial class ODA_Composizioni
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.visualizzaButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.clientiGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.clientiGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 378);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Riepilogo";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ProgettoCMA.Properties.Resources.add_user_128;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(14, 43);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 62;
            this.button1.UseVisualStyleBackColor = true;
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
            // 
            // visualizzaButton
            // 
            this.visualizzaButton.Location = new System.Drawing.Point(6, 193);
            this.visualizzaButton.Name = "visualizzaButton";
            this.visualizzaButton.Size = new System.Drawing.Size(154, 32);
            this.visualizzaButton.TabIndex = 2;
            this.visualizzaButton.Text = "Visualizza";
            this.visualizzaButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Controls.Add(this.visualizzaButton);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(583, 16);
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
            // 
            // clientiGroupBox
            // 
            this.clientiGroupBox.Controls.Add(this.groupBox2);
            this.clientiGroupBox.Controls.Add(this.groupBox1);
            this.clientiGroupBox.Location = new System.Drawing.Point(3, 4);
            this.clientiGroupBox.Name = "clientiGroupBox";
            this.clientiGroupBox.Size = new System.Drawing.Size(789, 524);
            this.clientiGroupBox.TabIndex = 2;
            this.clientiGroupBox.TabStop = false;
            this.clientiGroupBox.Text = "Ordine di Acquisto";
            // 
            // ODA_Composizioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientiGroupBox);
            this.Name = "ODA_Composizioni";
            this.Size = new System.Drawing.Size(795, 533);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.clientiGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button visualizzaButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox clientiGroupBox;
    }
}
