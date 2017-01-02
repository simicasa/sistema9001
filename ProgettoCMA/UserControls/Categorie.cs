using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA
{
    public partial class Categorie : UC<Categoria>
    {
        public Categorie(Home home) : base(home)
        {
            InitializeComponent();
            this.dbSet = Shared.cdc.CategoriaSet;            
            
            // LIST
            this.list = listBox;
            this.list.DisplayMember = "Nome";
            this.list.ValueMember = "Nome";
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

     


        private void clientiListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listInhibit)
            {
                return;
            }
            this.selectedIndex = this.list.SelectedIndex;
            if (this.newInstance != null)
            {
                DialogResult dr = MessageBox.Show("Cambiare cliente e perdere il nuovo?", "Gestione Clienti", MessageBoxButtons.YesNo);
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
                DialogResult dr = MessageBox.Show("Cambiare cliente e perdere i progressi?", "Gestione Clienti", MessageBoxButtons.YesNo);
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
                MessageBox.Show("Nessun cliente presente", "Gestione Clienti", MessageBoxButtons.OK);
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
            if (MessageBox.Show("Continuare con il salvataggio?", "Aggiunta Categoria", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.saveButtons();
                this.updateFields();
            }
        }

        private void updateFields()
        {
            bool isNew = (this.newInstance == null) ? false : true;
            Categoria categoria;
            if (!isNew)
            {
                int ID = Int32.Parse(idValue.Text);
                IQueryable<Categoria> iq = Shared.cdc.CategoriaSet.OfType<Categoria>().Where(x => x.Id == ID);
                iq.Select(x => x);
                var query = iq;
                if (query.Count() == 1)
                {
                    categoria = query.First();
                }
                else
                {
                    throw new Exception("Errore utente non trovato");
                }
            }
            else
            {
                categoria = this.newInstance;
            }

            if (isNew)
            {
                this.databaseAdd(categoria);
            }
            else
            {
                this.databaseUpdate(categoria);
                Categoria old = this.dataSubset[this.selectedIndex];
                this.dataSubset[this.selectedIndex] = categoria;
                this.data[this.data.IndexOf(old)] = categoria;
            }
            try
            {
                this.listInhibit = true;
                this.orderList();
                this.list.SelectedItem = categoria;
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
            base.orderList(x => x.Nome);
            this.list.DataSource = this.dataSubset;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            this.listInhibit = true;
            this.newInstance = new Categoria("nuova categorie");
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

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            base.searchTextBoxFilterData(c => c.Nome.Contains(searchTextBox.Text));
        }

        private void annullaButton_Click(object sender, EventArgs e)
        {
            updateUI(this.dataSubset[this.selectedIndex]);
            saveButtons();
        }

        private void clientiGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
