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
    public partial class Fornitori : UC<Fornitore, Categoria, Associazione_Categoria_Fornitore>
    {
        public Fornitori(Home home) : base(home)
        {
            InitializeComponent();

            // DB SET
            this.dbSet = Shared.cdc.AziendaSet;
            this.dbSetSecondary = Shared.cdc.CategoriaSet;
            this.dbSetCombine = Shared.cdc.Associazione_Categoria_FornitoreSet;

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
                if (DialogResult.Yes == this.messageBoxShow("Cambiare fornitore e perdere il nuovo?", MessageBoxButtons.YesNo))
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
            Fornitore fornitore;
            if (!isNew)
            {
                int ID = Int32.Parse(idValue.Text);
                fornitore = Shared.cdc.AziendaSet.OfType<Fornitore>().Where(x => x.ID == ID).First();
                this.databaseUpdate(fornitore);
                Fornitore old = this.dataSubset[this.selectedIndex];
                this.dataSubset[this.selectedIndex] = fornitore;
                this.data[this.data.IndexOf(old)] = fornitore;
            }
            else
            {
                fornitore = this.newInstance;
                this.databaseAdd(fornitore);
            }
            try
            {
                this.orderList();
                this.list.SelectedItem = fornitore;
                searchTextBox.Text = "";
                this.newInstance = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
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
                MessageBox.Show("Nessun fornitore presente", "Gestione Fornitori", MessageBoxButtons.OK);
                return;
            }
            this.editButtons();
        }
        protected override void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continuare con il salvataggio?", "Aggiunta Fornitore", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.saveButtons();
                this.updateFields();
            }
        }
        protected override void addButton_Click(object sender, EventArgs e)
        {
            this.listInhibit = true;
            this.newInstance = new Fornitore(-1, "", new Indirizzo(), "", "", "", "Nuovo Fornitore", "");
            this.data.Add(newInstance);
            this.dataSubset.Add(newInstance);
            this.orderList();
            this.list.SelectedItem = newInstance;
            this.selectedIndex = this.list.SelectedIndex;
            Console.WriteLine("1");
            this.editButtons();
            Console.WriteLine("2");
            this.updateUI(this.newInstance);
            this.listInhibit = false;
        }
        protected override void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Eliminare il fornitore?", "Gestione fornitori", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Fornitore fornitore;
                int ID = Int32.Parse(idValue.Text);
                var query = from fornitoreQuery in Shared.cdc.AziendaSet.OfType<Fornitore>()
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
                this.listInhibit = true;
                Shared.cdc.AziendaSet.Remove(fornitore);
                this.data.Remove(fornitore);
                this.dataSubset.Remove(fornitore);
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
            base.searchTextBoxFilterData(c => c.Ragione.Contains(searchTextBox.Text));
        }
        protected override void annullaButton_Click(object sender, EventArgs e)
        {
            updateUI(this.dataSubset[this.selectedIndex]);
            saveButtons();
        }

        private void categoriaAddButton_Click(object sender, EventArgs e)
        {
            if (this.listSecondary.SelectedIndex != -1)
            {
                Associazione_Categoria_Fornitore acf = new Associazione_Categoria_Fornitore();
                acf.Categoria = (Categoria) this.listSecondary.SelectedItem;
                acf.Fornitore = (Fornitore) this.list.SelectedItem;
                Shared.cdc.Associazione_Categoria_FornitoreSet.Add(acf);
                this.getData();
            }
        }

        private void categoriaRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.listCombine.SelectedIndex != -1)
            {
                Shared.cdc.Associazione_Categoria_FornitoreSet.Remove((Associazione_Categoria_Fornitore)this.listCombine.SelectedItem);
                this.getData();
            }
        }
    }
}
