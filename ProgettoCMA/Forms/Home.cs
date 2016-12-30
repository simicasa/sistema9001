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
            this.MinimumSize = new Size(400, 200);

            Utente utente = new Utente("angelo", "covino", "angelo", 1, "angelo");
            /*
            utente.Cognome = "ss";
            utente.Nome = "dd";
            utente.Ruolo = new Ruolo();
            utente.ID = 15;
            */
            //this.ahsi("ciao");

            //this.aggiungiUtente(utente);
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
        public void aggiungiUtente(Utente utente)
        {
            ClassDiagramContainer cdc = new ClassDiagramContainer();
            /*
            var test = from r in cdc.UtenteSet select r;
            Console.WriteLine("nananananananna");
            Console.WriteLine(test.Count());
            foreach (var t in test)
            {
                Console.WriteLine(t.Nome + " " + t.Cognome);
                //Console.WriteLine(t.Ragione.ToString());
                //Console.WriteLine(t.Indirizzo.Citta.ToString());
            }
            */
            cdc.UtenteSet.Add(utente);
            //cdc.Entry(utente).State = System.Data.Entity.EntityState.Added;
            cdc.SaveChanges();
        }
        
        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            /*
            Login login = new Login(this);
            login.ShowDialog();
            */
        }

        private void clientiGestioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clienti clienti = new Clienti(this);
            this.controlsAdd(clienti);
        }

        private void fornitoriGestioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fornitori fornitore = new Fornitori(this);
            this.controlsAdd(fornitore);

        }

        private void controlsAdd(UserControl uc)
        {
            uc.Top = 30;
            this.controlsClear();
            this.Controls.Add(uc);
        }
        private void controlsClear()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i].GetType() != typeof(MenuStrip))
                {
                    this.Controls[i].Dispose();
                }
            }
        }

        public void ripopolami()
        {
            ClassDiagramContainer cdc = new ClassDiagramContainer();
            Utente user = new Utente("angelo", "covino", "angelo", 1, "angelo");
            cdc.UtenteSet.Add(user);
            cdc.Entry(user).State = System.Data.Entity.EntityState.Added;
            cdc.SaveChanges();
        }

        private void gestioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categorie categoria = new categorie(this);
            this.controlsAdd(categoria);
        }
    }
}
