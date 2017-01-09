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
    partial class Clienti
    {
        public Clienti() : base()
        {
            InitializeComponent();
            
            // DB SET
            this.dbSet = Shared.cdc.AziendaSet;

            // LIST
            this.list = listBox;
            this.list.DisplayMember = "Ragione";
            this.list.ValueMember = "Ragione";

            // BUTTONS
            this.editBt = editButton;
            this.saveBt = saveButton;
            this.deleteBt = deleteButton;
            this.addBt = addButton;
            this.cancelBt = annullaButton;

            this.initialize(this.orderList);
        }

        protected override void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.newInstance != null)
            {
                if (this.forceRemove) {
                    this.listInhibit = true;
                    this.data.Remove(this.newInstance);
                    this.dataSubset.Remove(this.newInstance);
                    this.orderList();
                    this.selectedIndex = 0;
                    this.list.SetSelected(this.selectedIndex, true);
                    this.listInhibit = false;
                    this.newInstance = null;
                    this.forceRemove = false;
                }
            }
            if (this.selectedIndex == -1)
            {
                if(this.data.Count() == 0)
                {
                    MessageBox.Show("L'elenco e' vuoto");
                    editButton.Enabled = false;
                }
                return;
            }
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
        private void updateFields()
        {
            this.listInhibit = true;
            bool isNew = (this.newInstance == null) ? false : true;
            Cliente cliente;
            if (!isNew)
            {
                int ID = Int32.Parse(idValue.Text);
                cliente = Shared.cdc.AziendaSet.OfType<Cliente>().Where(x => x.ID == ID).First();
                this.databaseUpdate(cliente);
                Cliente old = this.dataSubset[this.selectedIndex];
                this.dataSubset[this.selectedIndex] = cliente;
                this.data[this.data.IndexOf(old)] = cliente;
            }
            else
            {
                cliente = this.newInstance;
                this.databaseAdd(cliente);
            }
            this.orderList();
            this.list.SelectedItem = cliente;
            searchTextBox.Text = "";
            this.newInstance = null;
            this.listInhibit = false;
        }
        private void orderList()
        {
            base.orderList(x => x.Ragione);
            this.list.DataSource = this.dataSubset;
        }
        
        protected override void editButton_Click(object sender, EventArgs e)
        {
            if (this.selectedIndex == -1)
            {
                MessageBox.Show("Nessun cliente presente", "Gestione Clienti", MessageBoxButtons.OK);
                return;
            }
            this.editButtons();
        }
        protected override void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continuare con il salvataggio?", "Aggiunta Cliente", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.saveButtons();
                this.updateFields();
            }
        }
        protected override void addButton_Click(object sender, EventArgs e)
        {
            this.listInhibit = true;
            this.newInstance = new Cliente(-1, "", new Indirizzo(), "", "", "", "Nuovo Cliente", "");
            this.data.Add(newInstance);
            this.dataSubset.Add(newInstance);
            this.orderList();
            this.list.SelectedItem = newInstance;
            this.selectedIndex = this.list.SelectedIndex;
            this.editButtons();
            this.updateUI(this.newInstance);
            this.listInhibit = false;
        }
        protected override void deleteButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == this.messageBoxShow("Eliminare il cliente?", MessageBoxButtons.YesNo))
            {
                this.databaseRemove((Cliente)this.listBox.SelectedItem);
                this.orderList();
            }
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            base.searchTextBoxFilterData(c => c.Ragione.IndexOf(searchTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        protected override void annullaButton_Click(object sender, EventArgs e)
        {
            updateUI(this.dataSubset[this.selectedIndex]);
            saveButtons();
        }
    }
}
