using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA
{
    public partial class newODA : Form
    {
        bool isForced = true;
        public newODA(Lista_RDO lista = null)
        {
            InitializeComponent();
            IQueryable<RDO> rdos = Shared.cdc.RDOSet;
            if (lista != null)
            {
                rdos = rdos.Where(r => r.Lista_RDO.ID == lista.ID);
            }
            comboBox1.DataSource = rdos.ToList();
            comboBox1.ValueMember = "Progressivo";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.forcedResize();
            forzaButton.Enabled = creaButton.Enabled = (rdos.Count() > 0) ? true : false;
            forzaCreaButton.Enabled = false;
        }

        private void forcedResize()
        {
            this.Height = this.Height + ((this.isForced ? -1 : 1) * (this.panel1.Height + 10));
            this.forzaButton.Text = (this.isForced ? "Forza creazione" : "Crea utilizzando riferimento RDO");
            creaButton.Enabled = comboBox1.Enabled = this.isForced;
            this.isForced = !this.isForced;
            this.panel1.Visible = this.isForced;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private Utente checkLogin(String username, String password)
        {
            IQueryable<Utente> utente = Shared.cdc.UtenteSet.Where(u => u.Username == username && u.Password == password);
            if (utente.Count() == 1)
            {
                return utente.First();
            }
            return null;
        }

        private void forzaButton_Click(object sender, EventArgs e)
        {
            this.forcedResize();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            forzaCreaButton.Enabled = (textBox1.Text.Count() > 10) ? true : false;
        }

        private void creaButton_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == -1)
            {
                return;
            }
            this.creaODA();
        }
        private void forzaCreaButton_Click(object sender, EventArgs e)
        {
            this.creaODA();
        }

        private void creaODA()
        {
            Clienti c = new Clienti();
            Shared.home.controlsAdd(c);
            this.Close();
        }
    }
}
