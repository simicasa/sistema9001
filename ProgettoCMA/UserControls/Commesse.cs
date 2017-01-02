using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ProgettoCMA
{
    public partial class Commesse : UC<Commessa, Cliente>
    {

        public Commesse(Home home) : base(home)
        {
            InitializeComponent();
            this.dbSet = Shared.cdc.CommessaSet;
            this.dbSetSecondary = Shared.cdc.AziendaSet;

            // LIST
            this.list = listBox;
            this.list.DisplayMember = "Codice";
            this.list.ValueMember = "Codice";
            this.listSecondary = clienteValue;
            this.listSecondary.DisplayMember = "Ragione";
            this.listSecondary.ValueMember = "Ragione";
            this.getData();
            this.orderList();

            // BUTTONS
            this.editBt = editButton;
            this.saveBt = saveButton;
            this.deleteBt = deleteButton;
            this.addBt = addButton;
            this.cancelBt = annullaButton;

            this.textBoxesEnable(false);
        }


        private void commesseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listInhibit)
            {
                return;
            }
            this.selectedIndex = this.list.SelectedIndex;
            if (this.newInstance != null)
            {
                DialogResult dr = MessageBox.Show("Cambiare commessa e perdere il nuovo?", "Gestione Commesse", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.listInhibit = true;
                    this.data.Remove(this.newInstance);
                    this.dataSubset.Remove(this.newInstance);
                    //this.list.Items.Remove(this.newInstance);
                    this.orderList();
                    this.list.SetSelected(this.selectedIndex, true);
                    this.listInhibit = false;
                    this.newInstance = null;
                }
                else
                {
                    this.listInhibit = true;
                    this.list.SetSelected(this.selectedIndex, true);
                    this.listInhibit = false;
                    return;
                }
            }
            else if (saveButton.Enabled)
            {
                DialogResult dr = MessageBox.Show("Cambiare commessa e perdere i progressi?", "Gestione Commesse", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    this.listInhibit = true;
                    if (this.previousSelected != -1)
                    {
                        this.list.SetSelected(this.previousSelected, true);
                    }
                    this.listInhibit = false;
                    return;
                }
            }
            if (this.selectedIndex == -1)
            {
                if (this.data.Count() == 0)
                {
                    MessageBox.Show("L'elenco e' vuoto");
                    editButton.Enabled = false;
                }
                return;
            }
            this.updateUI(this.dataSubset[this.selectedIndex]);
            this.previousSelected = this.list.SelectedIndex;
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.selectedIndex == -1)
            {
                MessageBox.Show("Nessun commessa presente", "Gestione Commesse", MessageBoxButtons.OK);
                return;
            }
            this.editButtons();
        }
        private void editButtons()
        {
            this.buttonsUpdate(true);
            searchTextBox.Enabled = false;
            this.list.Enabled = false;

            this.textBoxesEnable(true);
            idValue.Enabled = false;
            creazioneValue.Enabled = false;
        }
        private void saveButtons()
        {
            this.buttonsUpdate(false);
            searchTextBox.Enabled = true;
            this.list.Enabled = true;

            this.textBoxesEnable(false);
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continuare con il salvataggio?", "Aggiunta Commessa", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.saveButtons();
                this.updateFields();
            }
        }
        private void updateFields()
        {
            bool isNew = (this.newInstance == null) ? false : true;
            //ClassDiagramContainer cdc = new ClassDiagramContainer();
            Commessa commessa;
            if (!isNew)
            {
                int ID = Int32.Parse(idValue.Text);
                IQueryable<Commessa> iq = Shared.cdc.CommessaSet.Where(x => x.ID == ID);
                iq.Select(x => x);
                var query = iq;
                /*
                var query = from commessaQuery in iq
                            //where this.giggi(commessaQuery.Ragione) && commessaQuery.ID == ID
                            select commessaQuery;
                */
                if (query.Count() == 1)
                {
                    commessa = query.First();
                    //commessa = (Commessa)this.list.SelectedItem;
                }
                else
                {
                    throw new Exception("Errore utente non trovato");
                }
                //commessa = this.dataSubset[this.list.SelectedIndex];
            }
            else
            {
                commessa = this.newInstance;
            }

            if (isNew)
            {
                commessa.Chiusura = chiusuraValue.Text;
                commessa.Cliente = Shared.cdc.AziendaSet.OfType<Cliente>().Where(c => c.ID == 1).First();
                commessa.Note = noteValue.Text;
                /*
                commessa.Utente = Shared.cdc.UtenteSet.Where(u => u.ID == 1).First();
                Console.WriteLine(commessa.Utente.ToString());
                */
                commessa.Utente = Shared.utente;
                commessa.ID = Int32.Parse(idValue.Text);
                commessa.Codice = codiceValue.Text;
                commessa.Creazione = DateTime.Now.ToShortDateString();
                commessa.RDO = new HashSet<RDO>();
                commessa.Note = noteValue.Text;
                //this.databaseAdd(commessa);
                //Shared.cdc.Entry(commessa).State = System.Data.Entity.EntityState.Added;
                Shared.cdc.CommessaSet.Add(commessa);
                Shared.cdc.SaveChanges();
                //cdc.Entry(commessa).State = System.Data.Entity.EntityState.Added;
            }
            else
            {
                this.databaseUpdate(commessa);
                Commessa old = this.dataSubset[this.selectedIndex];
                this.dataSubset[this.selectedIndex] = commessa;
                this.data[this.data.IndexOf(old)] = commessa;
            }
            try
            {
                this.listInhibit = true;
                this.orderList();
                this.list.SelectedItem = commessa;
                this.listInhibit = false;
                //Shared.cdc.SaveChanges();
                searchTextBox.Text = "";
                this.newInstance = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void orderList()
        {
            base.orderList(x => x.Codice, x => x.Ragione);
            this.list.DataSource = this.dataSubset;
            this.listSecondary.DataSource = this.dataSecondary;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            this.listInhibit = true;
            this.newInstance = new Commessa(-1, new Cliente(), "Nuovo Codice", Shared.utente, "");
            this.data.Add(newInstance);
            this.dataSubset.Add(newInstance);
            this.orderList();
            this.list.SelectedItem = newInstance;
            this.selectedIndex = this.list.SelectedIndex;
            this.editButtons();
            this.updateUI(this.newInstance);
            this.listInhibit = false;
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Eliminare il commessa?", "Gestione commesse", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Commessa commessa;
                int ID = Int32.Parse(idValue.Text);
                var query = from commessaQuery in Shared.cdc.AziendaSet.OfType<Commessa>()
                            where commessaQuery.ID == ID
                            select commessaQuery;
                if (query.Count() == 1)
                {
                    commessa = query.First();
                }
                else
                {
                    throw new Exception("Errore utente non trovato");
                }
                this.listInhibit = true;
                Shared.cdc.CommessaSet.Remove(commessa);
                this.data.Remove(commessa);
                this.dataSubset.Remove(commessa);
                this.listInhibit = false;
                this.orderList();
                try
                {
                    Shared.cdc.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            base.searchTextBoxFilterData(c => c.Codice.Contains(searchTextBox.Text));
        }

        private void annullaButton_Click(object sender, EventArgs e)
        {
            updateUI(this.dataSubset[this.selectedIndex]);
            saveButtons();
        }
    }
}
