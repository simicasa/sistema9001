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
            this.maggiore = new System.Windows.Forms.Button();
            this.minore = new System.Windows.Forms.Button();
            this.treeViewUC1 = new ProgettoCMA.Controller.TreeViewUC();
            this.treeViewUC2 = new ProgettoCMA.Controller.TreeViewUC();
            this.SuspendLayout();
            // 
            // comboBoxUC1
            // 
            this.comboBoxUC1.FormattingEnabled = true;
            this.comboBoxUC1.Location = new System.Drawing.Point(725, 23);
            this.comboBoxUC1.Name = "comboBoxUC1";
            this.comboBoxUC1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUC1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(753, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // maggiore
            // 
            this.maggiore.Location = new System.Drawing.Point(184, 59);
            this.maggiore.Name = "maggiore";
            this.maggiore.Size = new System.Drawing.Size(75, 23);
            this.maggiore.TabIndex = 3;
            this.maggiore.Text = ">";
            this.maggiore.UseVisualStyleBackColor = true;
            // 
            // minore
            // 
            this.minore.Location = new System.Drawing.Point(184, 88);
            this.minore.Name = "minore";
            this.minore.Size = new System.Drawing.Size(75, 23);
            this.minore.TabIndex = 3;
            this.minore.Text = "<";
            this.minore.UseVisualStyleBackColor = true;
            // 
            // treeViewUC1
            // 
            this.treeViewUC1.Location = new System.Drawing.Point(57, 35);
            this.treeViewUC1.Name = "treeViewUC1";
            this.treeViewUC1.Size = new System.Drawing.Size(121, 97);
            this.treeViewUC1.TabIndex = 4;
            // 
            // treeViewUC2
            // 
            this.treeViewUC2.Location = new System.Drawing.Point(265, 35);
            this.treeViewUC2.Name = "treeViewUC2";
            this.treeViewUC2.Size = new System.Drawing.Size(121, 97);
            this.treeViewUC2.TabIndex = 4;
            // 
            // prova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewUC2);
            this.Controls.Add(this.treeViewUC1);
            this.Controls.Add(this.minore);
            this.Controls.Add(this.maggiore);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxUC1);
            this.Name = "prova";
            this.Size = new System.Drawing.Size(863, 242);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBoxUC comboBoxUC1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button maggiore;
        private System.Windows.Forms.Button minore;
        private TreeViewUC treeViewUC1;
        private TreeViewUC treeViewUC2;
    }
}
