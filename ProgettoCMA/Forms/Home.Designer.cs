namespace ProgettoCMA
{
    partial class Home
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

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amministrazioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commesseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commesseGestioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientiGestioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornitoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornitoriGestioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.amministrazioneToolStripMenuItem,
            this.commesseToolStripMenuItem,
            this.clientiToolStripMenuItem,
            this.fornitoriToolStripMenuItem,
            this.categorieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // amministrazioneToolStripMenuItem
            // 
            this.amministrazioneToolStripMenuItem.Name = "amministrazioneToolStripMenuItem";
            this.amministrazioneToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.amministrazioneToolStripMenuItem.Text = "Amministrazione";
            // 
            // commesseToolStripMenuItem
            // 
            this.commesseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commesseGestioneToolStripMenuItem});
            this.commesseToolStripMenuItem.Name = "commesseToolStripMenuItem";
            this.commesseToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.commesseToolStripMenuItem.Text = "Commesse";
            // 
            // commesseGestioneToolStripMenuItem
            // 
            this.commesseGestioneToolStripMenuItem.Name = "commesseGestioneToolStripMenuItem";
            this.commesseGestioneToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.commesseGestioneToolStripMenuItem.Text = "Gestione";
            this.commesseGestioneToolStripMenuItem.Click += new System.EventHandler(this.commesseGestioneToolStripMenuItem_Click);
            // 
            // clientiToolStripMenuItem
            // 
            this.clientiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientiGestioneToolStripMenuItem});
            this.clientiToolStripMenuItem.Name = "clientiToolStripMenuItem";
            this.clientiToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.clientiToolStripMenuItem.Text = "Clienti";
            // 
            // clientiGestioneToolStripMenuItem
            // 
            this.clientiGestioneToolStripMenuItem.Name = "clientiGestioneToolStripMenuItem";
            this.clientiGestioneToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.clientiGestioneToolStripMenuItem.Text = "Gestione";
            this.clientiGestioneToolStripMenuItem.Click += new System.EventHandler(this.clientiGestioneToolStripMenuItem_Click);
            // 
            // fornitoriToolStripMenuItem
            // 
            this.fornitoriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fornitoriGestioneToolStripMenuItem});
            this.fornitoriToolStripMenuItem.Name = "fornitoriToolStripMenuItem";
            this.fornitoriToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.fornitoriToolStripMenuItem.Text = "Fornitori";
            // 
            // fornitoriGestioneToolStripMenuItem
            // 
            this.fornitoriGestioneToolStripMenuItem.Name = "fornitoriGestioneToolStripMenuItem";
            this.fornitoriGestioneToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.fornitoriGestioneToolStripMenuItem.Text = "Gestione";
            this.fornitoriGestioneToolStripMenuItem.Click += new System.EventHandler(this.fornitoriGestioneToolStripMenuItem_Click);
            // 
            // categorieToolStripMenuItem
            // 
            this.categorieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestioneToolStripMenuItem});
            this.categorieToolStripMenuItem.Name = "categorieToolStripMenuItem";
            this.categorieToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.categorieToolStripMenuItem.Text = "Categorie";
            // 
            // gestioneToolStripMenuItem
            // 
            this.gestioneToolStripMenuItem.Name = "gestioneToolStripMenuItem";
            this.gestioneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gestioneToolStripMenuItem.Text = "Gestione";
            this.gestioneToolStripMenuItem.Click += new System.EventHandler(this.gestioneToolStripMenuItem_Click_1);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 363);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "progettoCMA";
            this.Load += new System.EventHandler(this.Home_Load);
            this.Shown += new System.EventHandler(this.Home_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amministrazioneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientiGestioneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornitoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornitoriGestioneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categorieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commesseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commesseGestioneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestioneToolStripMenuItem;
    }
}

