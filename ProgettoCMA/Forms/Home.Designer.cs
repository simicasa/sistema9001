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
            this.clientiToolStripMenuItem,
            this.fornitoriToolStripMenuItem,
            this.categorieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(14, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1024, 51);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(70, 43);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // amministrazioneToolStripMenuItem
            // 
            this.amministrazioneToolStripMenuItem.Name = "amministrazioneToolStripMenuItem";
            this.amministrazioneToolStripMenuItem.Size = new System.Drawing.Size(228, 43);
            this.amministrazioneToolStripMenuItem.Text = "Amministrazione";
            // 
            // clientiToolStripMenuItem
            // 
            this.clientiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientiGestioneToolStripMenuItem});
            this.clientiToolStripMenuItem.Name = "clientiToolStripMenuItem";
            this.clientiToolStripMenuItem.Size = new System.Drawing.Size(105, 43);
            this.clientiToolStripMenuItem.Text = "Clienti";
            // 
            // clientiGestioneToolStripMenuItem
            // 
            this.clientiGestioneToolStripMenuItem.Name = "clientiGestioneToolStripMenuItem";
            this.clientiGestioneToolStripMenuItem.Size = new System.Drawing.Size(230, 42);
            this.clientiGestioneToolStripMenuItem.Text = "Gestione";
            this.clientiGestioneToolStripMenuItem.Click += new System.EventHandler(this.clientiGestioneToolStripMenuItem_Click);
            // 
            // fornitoriToolStripMenuItem
            // 
            this.fornitoriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fornitoriGestioneToolStripMenuItem});
            this.fornitoriToolStripMenuItem.Name = "fornitoriToolStripMenuItem";
            this.fornitoriToolStripMenuItem.Size = new System.Drawing.Size(130, 43);
            this.fornitoriToolStripMenuItem.Text = "Fornitori";
            // 
            // fornitoriGestioneToolStripMenuItem
            // 
            this.fornitoriGestioneToolStripMenuItem.Name = "fornitoriGestioneToolStripMenuItem";
            this.fornitoriGestioneToolStripMenuItem.Size = new System.Drawing.Size(298, 42);
            this.fornitoriGestioneToolStripMenuItem.Text = "Gestione";
            this.fornitoriGestioneToolStripMenuItem.Click += new System.EventHandler(this.fornitoriGestioneToolStripMenuItem_Click);
            // 
            // categorieToolStripMenuItem
            // 
            this.categorieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestioneToolStripMenuItem});
            this.categorieToolStripMenuItem.Name = "categorieToolStripMenuItem";
            this.categorieToolStripMenuItem.Size = new System.Drawing.Size(145, 43);
            this.categorieToolStripMenuItem.Text = "Categorie";
            // 
            // gestioneToolStripMenuItem
            // 
            this.gestioneToolStripMenuItem.Name = "gestioneToolStripMenuItem";
            this.gestioneToolStripMenuItem.Size = new System.Drawing.Size(298, 42);
            this.gestioneToolStripMenuItem.Text = "Gestione";
            this.gestioneToolStripMenuItem.Click += new System.EventHandler(this.gestioneToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 638);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
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
        private System.Windows.Forms.ToolStripMenuItem gestioneToolStripMenuItem;
    }
}

