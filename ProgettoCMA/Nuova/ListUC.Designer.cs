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
            this.class21 = new ProgettoCMA.Class2();
            this.SuspendLayout();
            // 
            // class21
            // 
            this.class21.FormattingEnabled = true;
            this.class21.Location = new System.Drawing.Point(3, 3);
            this.class21.Name = "class21";
            this.class21.Size = new System.Drawing.Size(136, 121);
            this.class21.TabIndex = 0;
            // 
            // ListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.class21);
            this.Name = "ListUC";
            this.Size = new System.Drawing.Size(416, 337);
            this.ResumeLayout(false);

        }

        #endregion

        private Class2 class21;
    }
}
