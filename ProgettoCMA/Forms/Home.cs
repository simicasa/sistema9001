using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA
{
    public partial class Home : Form
    {
        public Utente utente;
        private MenuStrip menu;
        public Home()
        {
            InitializeComponent();
            this.menu = menuStrip1;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimumSize = new Size(800, 600);
            ClassDiagramContainer cdc = new ClassDiagramContainer();
            if(cdc.UtenteSet.Where(u => u.Username == "angelo").Count() < 1)
            {
                Utente utente = new Utente("angelo", "covino", "angelo", 1, "angelo");
                cdc.UtenteSet.Add(utente);
                //cdc.Entry(utente).State = System.Data.Entity.EntityState.Added;
                cdc.SaveChanges();
            }
        }
        public void ahsi()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Console.WriteLine(config.ConnectionStrings.ConnectionStrings["ClassDiagramContainer"].ConnectionString);
            config.ConnectionStrings.ConnectionStrings.Remove(config.ConnectionStrings.ConnectionStrings["ClassDiagramContainer"]);
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("ClassDiagramContainer", "metadata=res://*/ClassDiagram.csdl|res://*/ClassDiagram.ssdl|res://*/ClassDiagram.msl;provider=System.Data.SqlClient;provider connection string=\"data source=192.168.0.15;Initial Catalog=CMA;Persist Security Info=True;User ID=angelo;Password=Napoli1990\"", "System.Data.EntityClient"));
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            Console.WriteLine(config.ConnectionStrings.ConnectionStrings["ClassDiagramContainer"].ConnectionString);
        }
        
        private void Home_Load(object sender, EventArgs e)
        {
        }
        private void Home_Shown(object sender, EventArgs e)
        {
            Login login = new Login(this);
            login.StartPosition = FormStartPosition.CenterParent;
            login.ShowDialog();
        }

        private void clientiGestioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controlsAdd(new Clienti(this));
        }
        private void fornitoriGestioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controlsAdd(new Fornitori(this));

        }
        private void commesseGestioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controlsAdd(new Commesse(this));
        }

        private void controlsAdd(UserControl uc)
        {
            uc.Top = 30;
            this.controlsClear();
            this.Controls.Add(uc);
        }
        private void controlsClear()
        {
            foreach (var item in this.Controls)
            {
                if(item.GetType() != typeof(MenuStrip))
                {
                    ((Control)item).Dispose();
                }
            }
        }
    }
}
