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
        public Commesse() : base()
        {
            InitializeComponent();
            List<Cliente> asd = Shared.cdc.AziendaSet.OfType<Cliente>().ToList();
            clienteValue.DataSource = asd;
            clienteValue.ValueMember = "Ragione";
            clienteValue.DropDownStyle = ComboBoxStyle.DropDownList;

            // DB SET
            this.dbSet = Shared.cdc.CommessaSet;
            this.dbSetSecondary = Shared.cdc.AziendaSet;

            // LIST
            this.list = listBox;
            this.list.DisplayMember = "Codice";
            this.list.ValueMember = "Codice";
            /*
            this.listSecondary = clienteValue1;
            this.listSecondary.DisplayMember = "Ragione";
            this.listSecondary.ValueMember = "Ragione";
            */

            // BUTTONS
            this.editBt = editButton;
            this.saveBt = saveButton;
            this.deleteBt = deleteButton;
            this.addBt = addButton;
            this.cancelBt = annullaButton;

            idValue.Enabled = false;
            creazioneValue.Enabled = false;

            this.initialize(this.orderList, null, new Control[] { clienteValue }, new Control[] { usaButton });
        }

        protected override void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void editButtons()
        {
            this.controlsUpdate(true);
            this.buttonsUpdate(true);
            searchTextBox.Enabled = false;
            this.list.Enabled = false;

            this.textBoxesEnable(true);
        }
        private void saveButtons()
        {
            this.controlsUpdate(false);
            this.buttonsUpdate(false);
            searchTextBox.Enabled = true;
            this.list.Enabled = true;

            this.textBoxesEnable(false);
        }
        private void updateFields()
        {
            this.listInhibit = true;
            bool isNew = (this.newInstance == null) ? false : true;
            Commessa commessa;
            if (!isNew)
            {
                int ID = Int32.Parse(idValue.Text);
                commessa = Shared.cdc.CommessaSet.OfType<Commessa>().Where(x => x.ID == ID).First();
                this.databaseUpdate(commessa);
                Commessa old = this.dataSubset[this.selectedIndex];
                this.dataSubset[this.selectedIndex] = commessa;
                this.data[this.data.IndexOf(old)] = commessa;
            }
            else
            {
                commessa = this.newInstance;
                this.databaseAdd(commessa);
            }
            this.orderList();
            this.list.SelectedItem = commessa;
            searchTextBox.Text = "";
            this.newInstance = null;
            this.listInhibit = false;
        }
        private void orderList()
        {
            base.orderList(x => x.Codice, x => x.Ragione);
            this.list.DataSource = this.dataSubset;
            //this.listSecondary.DataSource = this.dataSecondary;
        }
        protected override void editButton_Click(object sender, EventArgs e)
        {
            if (this.selectedIndex == -1)
            {
                MessageBox.Show("Nessun Commessa presente", "Gestione Commesse", MessageBoxButtons.OK);
                return;
            }
            this.editButtons();
        }
        protected override void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continuare con il salvataggio?", "Aggiunta Commessa", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.saveButtons();
                this.updateFields();
            }
        }
        protected override void addButton_Click(object sender, EventArgs e)
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
        protected override void deleteButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == this.messageBoxShow("Eliminare il commessa?", MessageBoxButtons.YesNo))
            {
                this.databaseRemove((Commessa)this.listBox.SelectedItem);
                this.orderList();
            }
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            base.searchTextBoxFilterData(c => c.Codice.IndexOf(searchTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        protected override void annullaButton_Click(object sender, EventArgs e)
        {
            updateUI(this.dataSubset[this.selectedIndex]);
            saveButtons();
        }

        private void usaButton_Click(object sender, EventArgs e)
        {
            Shared.commessaAttiva = (Commessa)this.list.SelectedItem;
            Shared.home.controlsAdd(new GestioneCommessa());
        }
    }
}