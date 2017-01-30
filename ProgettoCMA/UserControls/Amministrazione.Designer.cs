namespace ProgettoCMA.UserControls
{
    partial class Amministrazione
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxUC1
            // 
            this.comboBoxUC1.FormattingEnabled = true;
            this.comboBoxUC1.Location = new System.Drawing.Point(81, 6);
            this.comboBoxUC1.Name = "comboBoxUC1";
            this.comboBoxUC1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUC1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Debug phase";
            // 
            // Amministrazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxUC1);
            this.Name = "Amministrazione";
            this.Size = new System.Drawing.Size(392, 245);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controller.ComboBoxUC comboBoxUC1;
        private System.Windows.Forms.Label label1;
    }
}
