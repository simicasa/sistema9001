using iTextSharp.awt.geom;
using System.Drawing;
using System.Windows.Forms;

namespace ProgettoCMA
{
    partial class ListUC<T>
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
            this.listBoxUC1 = new ProgettoCMA.Controller.ListBoxUC();
            this.SuspendLayout();
            // 
            // listBoxUC1
            // 
            this.listBoxUC1.FormattingEnabled = true;
            this.listBoxUC1.Location = new System.Drawing.Point(56, 33);
            this.listBoxUC1.Name = "listBoxUC1";
            this.listBoxUC1.Size = new System.Drawing.Size(115, 82);
            this.listBoxUC1.TabIndex = 0;
            // 
            // ListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxUC1);
            this.Name = "ListUC";
            this.Size = new System.Drawing.Size(416, 337);
            this.ResumeLayout(false);

        }

        #endregion

        private Controller.ListBoxUC listBoxUC1;
    }
}
