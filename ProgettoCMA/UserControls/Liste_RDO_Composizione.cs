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
    public partial class Liste_RDO_Composizione : UC<Lista_RDO_Composizione>
    {
        public Liste_RDO_Composizione() : base()
        {
            InitializeComponent();

            // DB SET
            this.dbSet = Shared.cdc.Lista_RDO_ComposizioneSet;

            // LIST
            this.list = listBox;
            this.list.DisplayMember = "Categoria";
            this.list.ValueMember = "Categoria";

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
                if (DialogResult.Yes == this.messageBoxShow("Cambiare commessa_RDO_Categoria e perdere il nuovo?", MessageBoxButtons.YesNo))
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
            if (this.selectedIndex == -1)
            {
                if (this.data.Count() == 0)
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
            umValue.Enabled = false;
            quantitaValue.Enabled = false;
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
            Lista_RDO_Composizione commessa_RDO_Categoria;
            if (!isNew)
            {
                int ID = Int32.Parse(umValue.Text);
                commessa_RDO_Categoria = Shared.cdc.Lista_RDO_ComposizioneSet.OfType<Lista_RDO_Composizione>().Where(x => x.ID == ID).First();
                this.databaseUpdate(commessa_RDO_Categoria);
                Lista_RDO_Composizione old = this.dataSubset[this.selectedIndex];
                this.dataSubset[this.selectedIndex] = commessa_RDO_Categoria;
                this.data[this.data.IndexOf(old)] = commessa_RDO_Categoria;
            }
            else
            {
                commessa_RDO_Categoria = this.newInstance;
                this.databaseAdd(commessa_RDO_Categoria);
            }
            this.orderList();
            this.list.SelectedItem = commessa_RDO_Categoria;
            searchTextBox.Text = "";
            this.newInstance = null;
            this.listInhibit = false;
        }
        private void orderList()
        {
            base.orderList(x => x.ID);
            this.list.DataSource = this.dataSubset;
        }

        protected override void editButton_Click(object sender, EventArgs e)
        {
            if (this.selectedIndex == -1)
            {
                MessageBox.Show("Nessun commessa_RDO_Categoria presente", "Gestione Commessa_RDO_Categorie", MessageBoxButtons.OK);
                return;
            }
            this.editButtons();
        }
        protected override void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continuare con il salvataggio?", "Aggiunta RDO", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.saveButtons();
                this.updateFields();
            }
        }
        protected override void addButton_Click(object sender, EventArgs e)
        {
            this.listInhibit = true;
            this.newInstance = new Lista_RDO_Composizione(-1, null, null, "", 0, "");
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
            if (DialogResult.Yes == this.messageBoxShow("Eliminare il commessa_RDO_Categoria?", MessageBoxButtons.YesNo))
            {
                this.databaseRemove((Lista_RDO_Composizione)this.listBox.SelectedItem);
                this.orderList();
            }
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            //base.searchTextBoxFilterData(c => c.Id.IndexOf(searchTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        protected override void annullaButton_Click(object sender, EventArgs e)
        {
            updateUI(this.dataSubset[this.selectedIndex]);
            saveButtons();
        }

        private void generaRDOButton_Click(object sender, EventArgs e)
        {
            this.simoneVuoleLaFunzione(new Lista_RDO());
        }

        private void simoneVuoleLaFunzione(Lista_RDO listaRDO)
        {
            // prendi quello che ti serve
            // esempi:
            string codiceCommessa = listaRDO.Commessa.Codice;
            // FORMATO RIFERIMENTO INTERNO:
            // RDO_YYYY_CodiceCommessa_ProgressivoLista_ProgressivoRDOGenerata
            string nostroRiferimentoInterno = "RDO_" + DateTime.Now.Year + "_" + listaRDO.Commessa.Codice + "_" + listaRDO.Progressivo.ToString().PadLeft(4, '0') + "_" + "ProgressivoRDOGenerata";
            foreach (var item in listaRDO.Lista_RDO_Composizione)
            {
                //item.Quantita
                //item.UnitaMisura
                //item.Descrizione
                //item.Categoria.Nome
                //item.Categoria.Macro.Nome
            }
        }
    }
}
