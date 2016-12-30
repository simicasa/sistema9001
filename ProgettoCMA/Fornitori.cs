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
    public partial class Fornitori : UC<Fornitore>
    {

        public Fornitori(Home home) : base(home)
        {
            InitializeComponent();
            this.dbSet = this.cdc.AziendaSet;

            // LIST
            this.list = listBox;
            this.list.DisplayMember = "Ragione";
            this.list.ValueMember = "Ragione";
            this.getData();
            this.orderList();

            // BUTTONS
            this.editBt = editButton;
            this.saveBt = saveButton;
            this.deleteBt = deleteButton;
            this.addBt = addButton;
            this.cancelBt = annullaButton;

            this.textBoxesUpdate(false);
        }


        private void fornitoriListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.inhibit)
            {
                return;
            }
            this.selectedIndex = this.list.SelectedIndex;
            if (this.newFornitore != null)
            {
                DialogResult dr = MessageBox.Show("Cambiare fornitore e perdere il nuovo?", "Gestione Fornitori", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.inhibit = true;
                    this.data.Remove(this.newFornitore);
                    this.dataSubset.Remove(this.newFornitore);
                    //this.list.Items.Remove(this.newFornitore);
                    this.orderList();
                    this.list.SetSelected(this.selectedIndex, true);
                    this.inhibit = false;
                    this.newFornitore = null;
                }
                else
                {
                    this.inhibit = true;
                    this.list.SetSelected(this.selectedIndex, true);
                    this.inhibit = false;
                    return;
                }
            }
            else if (saveButton.Enabled)
            {
                DialogResult dr = MessageBox.Show("Cambiare fornitore e perdere i progressi?", "Gestione Fornitori", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    this.inhibit = true;
                    if (this.previousSelected != -1)
                    {
                        this.list.SetSelected(this.previousSelected, true);
                    }
                    this.inhibit = false;
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
                MessageBox.Show("Nessun fornitore presente", "Gestione Fornitori", MessageBoxButtons.OK);
                return;
            }
            this.editButtons();
        }
        private void editButtons()
        {
            this.buttonsUpdate(true);
            searchTextBox.Enabled = false;
            this.list.Enabled = false;

            this.textBoxesUpdate(true);
            idValue.Enabled = false;
            creazioneValue.Enabled = false;
        }
        private void saveButtons()
        {
            this.buttonsUpdate(false);
            searchTextBox.Enabled = true;
            this.list.Enabled = true;

            this.textBoxesUpdate(false);
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continuare con il salvataggio?", "Aggiunta Fornitore", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.saveButtons();
                this.updateFields();
            }
        }
        private void updateFields()
        {
            bool isNew = (this.newFornitore == null) ? false : true;
            //ClassDiagramContainer cdc = new ClassDiagramContainer();
            Fornitore fornitore;
            if (!isNew)
            {
                int ID = Int32.Parse(idValue.Text);
                IQueryable<Fornitore> iq = this.cdc.AziendaSet.OfType<Fornitore>().Where(x => x.ID == ID);
                iq.Select(x => x);
                var query = iq;
                /*
                var query = from fornitoreQuery in iq
                            //where this.giggi(fornitoreQuery.Ragione) && fornitoreQuery.ID == ID
                            select fornitoreQuery;
                */
                if (query.Count() == 1)
                {
                    fornitore = query.First();
                    //fornitore = (Fornitore)this.list.SelectedItem;
                }
                else
                {
                    throw new Exception("Errore utente non trovato");
                }
                //fornitore = this.dataSubset[this.list.SelectedIndex];
            }
            else
            {
                fornitore = this.newFornitore;
            }

            if (isNew)
            {
                this.databaseAdd(fornitore);
                //this.cdc.AziendaSet.Add(fornitore);
                //cdc.Entry(fornitore).State = System.Data.Entity.EntityState.Added;
            }
            else
            {
                this.databaseUpdate(fornitore);
                Fornitore old = this.dataSubset[this.selectedIndex];
                this.dataSubset[this.selectedIndex] = fornitore;
                this.data[this.data.IndexOf(old)] = fornitore;
            }
            try
            {
                this.inhibit = true;
                this.orderList();
                this.list.SelectedItem = fornitore;
                this.inhibit = false;
                //this.cdc.SaveChanges();
                searchTextBox.Text = "";
                this.newFornitore = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void orderList()
        {
            base.orderList(x => x.Ragione);
            this.list.DataSource = this.dataSubset;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            this.inhibit = true;
            this.newFornitore = new Fornitore(-1, "", new Indirizzo(), "", "", "", "Nuovo Fornitore", "");
            this.data.Add(newFornitore);
            this.dataSubset.Add(newFornitore);
            this.orderList();
            this.list.SelectedItem = newFornitore;
            this.selectedIndex = this.list.SelectedIndex;
            this.editButtons();
            this.updateUI(this.newFornitore);
            this.inhibit = false;
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Eliminare il fornitore?", "Gestione fornitori", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Fornitore fornitore;
                int ID = Int32.Parse(idValue.Text);
                var query = from fornitoreQuery in this.cdc.AziendaSet.OfType<Fornitore>()
                            where fornitoreQuery.ID == ID
                            select fornitoreQuery;
                if (query.Count() == 1)
                {
                    fornitore = query.First();
                }
                else
                {
                    throw new Exception("Errore utente non trovato");
                }
                this.inhibit = true;
                this.cdc.AziendaSet.Remove(fornitore);
                this.data.Remove(fornitore);
                this.dataSubset.Remove(fornitore);
                this.inhibit = false;
                this.orderList();
                try
                {
                    this.cdc.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void annullaButton_Click(object sender, EventArgs e)
        {
            updateUI(this.dataSubset[this.selectedIndex]);
            saveButtons();
        }
    }
}
