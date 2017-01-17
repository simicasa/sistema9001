namespace ProgettoCMA.Controller
{
    partial class prova
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
            this.comboBoxUC1 = new ProgettoCMA.Controller.ComboBoxUC();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxUC1
            // 
            this.comboBoxUC1.FormattingEnabled = true;
            this.comboBoxUC1.Location = new System.Drawing.Point(87, 72);
            this.comboBoxUC1.Name = "comboBoxUC1";
            this.comboBoxUC1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUC1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // prova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxUC1);
            this.Name = "prova";
            this.Size = new System.Drawing.Size(432, 242);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBoxUC comboBoxUC1;
        private System.Windows.Forms.Button button1;
    }
}
