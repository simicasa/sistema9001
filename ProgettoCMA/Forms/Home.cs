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
        private MenuStrip menu;

        public Home()
        {
            Shared.home = this;
            InitializeComponent();
            this.menu = menuStrip1;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimumSize = new Size(800, 600);
            if (Shared.cdc.UtenteSet.Where(u => u.Username == "angelo").Count() < 1)
            {
                Utente utente = new Utente("angelo", "covino", "angelo", 1, "angelo");
                Shared.cdc.UtenteSet.Add(utente);
                //cdc.Entry(utente).State = System.Data.Entity.EntityState.Added;
                Shared.cdc.SaveChanges();
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
            Login login = new Login();
            login.StartPosition = FormStartPosition.CenterParent;
            if(login.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void clientiGestioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controlsAdd(new Clienti());
        }
        private void fornitoriGestioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controlsAdd(new Fornitori());

        }
        private void commesseGestioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Shared.cdc.AziendaSet.OfType<Cliente>().Count() > 0)
            {
                this.controlsAdd(new Commesse());
            }
            else
            {
                Shared.messageBox("Non sono presenti clienti per creare una commessa.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void controlsAdd(UserControl uc)
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

        private void gestioneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void gestioneToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Categorie categoria = new Categorie();
            this.controlsAdd(categoria);
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void provaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.prova p = new Controller.prova();
            this.controlsAdd(p);
            /*
            ListUC<Categoria> l = new ListUC<Categoria>();//Shared.cdc.CategoriaSet.ToList());
            l.selectedIndexChanged = this.UserControl_ButtonClick;
            //l.selectedIndexChanged += new EventHandler(this.UserControl_ButtonClick);
            //l.asd(this.UserControl_ButtonClick);
            //l.asd(delegate (Categoria c) { Console.WriteLine(c.ID.ToString()); });
            this.controlsAdd(l);
            */
            //Controller.Authentication a = new Controller.Authentication();
        }
        protected void UserControl_ButtonClick(object sender, EventArgs e, Categoria c)//, Categoria c)
        {
            Shared.messageBox("b" + c.ID.ToString());
        }
    }
}
