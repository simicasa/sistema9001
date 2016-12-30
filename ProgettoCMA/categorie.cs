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
    public partial class categorie : UC<Categoria>
    {
        public categorie(Home home) : base(home)
        {
            InitializeComponent();
            this.dbSet = this.cdc.CategoriaSet;            
            
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

            this.textBoxesUpdate(false);
        }

     


        private void clientiListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.inhibit)
            {
                return;
            }
            this.selectedIndex = this.list.SelectedIndex;
            if (this.newCategoria != null)
            {
                DialogResult dr = MessageBox.Show("Cambiare cliente e perdere il nuovo?", "Gestione Clienti", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.inhibit = true;
                    this.data.Remove(this.newCategoria);
                    this.dataSubset.Remove(this.newCategoria);
                    //this.list.Items.Remove(this.newCategoria);
                    this.orderList();
                    this.list.SetSelected(this.selectedIndex, true);
                    this.inhibit = false;
                    this.newCategoria = null;
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
                DialogResult dr = MessageBox.Show("Cambiare cliente e perdere i progressi?", "Gestione Clienti", MessageBoxButtons.YesNo);
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

            this.textBoxesUpdate(true);
            idValue.Enabled = false;
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
            if (MessageBox.Show("Continuare con il salvataggio?", "Aggiunta Categoria", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.saveButtons();
                this.updateFields();
            }
        }

        private void updateFields()
        {
            bool isNew = (this.newCategoria == null) ? false : true;
            Categoria categoria;
            if (!isNew)
            {
                int ID = Int32.Parse(idValue.Text);
                IQueryable<Categoria> iq = this.cdc.CategoriaSet.OfType<Categoria>().Where(x => x.Id == ID);
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
                categoria = this.newCategoria;
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
                this.inhibit = true;
                this.orderList();
                this.list.SelectedItem = categoria;
                this.inhibit = false;
                //this.cdc.SaveChanges();
                searchTextBox.Text = "";
                this.newCategoria = null;
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
            this.inhibit = true;
            this.newCategoria = new Categoria("nuova categorie");
            this.data.Add(newCategoria);
            this.dataSubset.Add(newCategoria);
            this.orderList();
            this.list.SelectedItem = newCategoria;
            this.selectedIndex = this.list.SelectedIndex;
            this.editButtons();
            this.updateUI(this.newCategoria);
            this.inhibit = false;
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
