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
        BindingList<Categoria> dataCombineFull = null;
        public Fornitori() : base()
        {
            InitializeComponent();
            this.visibilizzami(false);

            // DB SET
            this.dbSet = Shared.cdc.AziendaSet;
            this.dbSetSecondary = Shared.cdc.CategoriaSet;
            this.dbSetCombine = Shared.cdc.Associazione_Categoria_FornitoreSet;

            // LIST
            this.list = listBox;
            this.list.DisplayMember = "Ragione";
            this.list.ValueMember = "Ragione";
            this.listSecondary = listBox1;
            this.listSecondary.DisplayMember = "Nome";
            this.listSecondary.ValueMember = "Nome";
            this.listCombine = listBox2;
            this.listCombine.DisplayMember = "Nome";
            this.listCombine.ValueMember = "Nome";

            // BUTTONS
            this.editBt = editButton;
            this.saveBt = saveButton;
            this.deleteBt = deleteButton;
            this.addBt = addButton;
            this.cancelBt = annullaButton;

            this.initialize(this.orderList, null, new Control[] { categoriaAddButton, categoriaRemoveButton, listBox1, listBox2, searchCategoria });
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
            this.visibilizzami(true);
            this.buttonsUpdate(true);
            this.controlsUpdate(true);
            searchTextBox.Enabled = false;
            this.list.Enabled = false;

            this.textBoxesEnable(true);
            idValue.Enabled = false;
            creazioneValue.Enabled = false;
            this.dataSecondary = new BindingList<Categoria>(Shared.cdc.CategoriaSet.ToList()); //.Where(c => c.Macro != null)
            this.associazioneCategoriaFornitoreUpdate();
        }
        private void saveButtons()
        {
            this.visibilizzami(false);
            this.buttonsUpdate(false);
            this.controlsUpdate(false);
            searchTextBox.Enabled = true;
            this.list.Enabled = true;

            this.textBoxesEnable(false);
        }

        private void visibilizzami(bool visible)
        {
            clientiGroupBox.Width = clientiGroupBox.Width + ((visible ? 1 : -1) * listBox1.Width);
            searchCategoria.Visible = visible;
            listBox1.Visible = visible;
            listBox2.Visible = visible;
            categoriaAddButton.Visible = visible;
            categoriaRemoveButton.Visible = visible;
            label2.Visible = visible;
            label3.Visible = visible;
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
            this.orderList();
            this.list.SelectedItem = fornitore;
            searchTextBox.Text = "";
            this.newInstance = null;
            this.listInhibit = false;
        }
        private void orderList()
        {
            this.orderList(x => x.Ragione, x => x.Nome);
            this.intersectDatas();
            int selected = this.list.SelectedIndex;
            this.list.DataSource = this.dataSubset;
            if (selected != -1)
            {
                this.list.SelectedIndex = selected;
            }
            this.listSecondary.DataSource = this.dataSecondarySubSet;
            this.listCombine.DataSource = this.dataCombineFull;
        }
        protected override void getData()
        {
            base.getData();
            this.associazioneCategoriaFornitoreUpdate();
            /*
            this.dataCombineFull = new BindingList<Categoria>(Shared.cdc.Associazione_Categoria_FornitoreSet.Join(Shared.cdc.CategoriaSet,
                                ass => ass.Categoria.ID,
                                cat => cat.ID,
                                (ass, cat) => cat).ToList());
             */
        }
        private void associazioneCategoriaFornitoreUpdate()
        {
            if (this.list.SelectedIndex != -1)
            {
                var asd = from ass in Shared.cdc.Associazione_Categoria_FornitoreSet
                          join c in Shared.cdc.CategoriaSet on ass.Categoria.ID equals c.ID
                          join f in Shared.cdc.AziendaSet.OfType<Fornitore>() on ass.Fornitore.ID equals f.ID
                          where f.ID == ((Fornitore)this.list.SelectedItem).ID
                          select c;
                this.dataCombineFull = new BindingList<Categoria>(asd.ToList());
            }
            else
            {
                this.dataCombineFull = new BindingList<Categoria>();
            }
            if (this.dataCombineFull.Count() > 0)
            {
                this.selectedIndexCombine = 0;
            }
            else
            {
                this.selectedIndexCombine = -1;
            }
            this.orderList();
        }
        private void intersectDatas()
        {
            this.dataSecondary = new BindingList<Categoria>(this.dataSecondary.Except(this.dataSecondary.Intersect(this.dataCombineFull)).ToList());
            this.dataSecondarySubSet = new BindingList<Categoria>(this.dataSecondarySubSet.Except(this.dataSecondarySubSet.Intersect(this.dataCombineFull)).ToList());
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
            this.editButtons();
            this.updateUI(this.newInstance);
            this.listInhibit = false;
        }
        protected override void deleteButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == this.messageBoxShow("Eliminare il fornitore?", MessageBoxButtons.YesNo))
            {
                this.databaseRemove((Fornitore)this.listBox.SelectedItem);
                this.orderList();
            }
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            this.searchTextBoxFilterData(c => c.Ragione.Contains(searchTextBox.Text));
        }
        private void searchCategoria_TextChanged(object sender, EventArgs e)
        {
            this.searchTextBoxFilterData1(c => c.Nome.Contains(searchCategoria.Text));
            this.intersectDatas();
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
                Shared.cdc.SaveChanges();
                this.dataCombineFull.Add(acf.Categoria);
                this.dataSecondary.Remove(acf.Categoria);
                this.dataSecondarySubSet.Remove(acf.Categoria);
                //this.getData();
                this.orderList();
            }
        }
        private void categoriaRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.listCombine.SelectedIndex != -1)
            {
                Categoria cat = (Categoria)this.listCombine.SelectedItem;
                IQueryable<Associazione_Categoria_Fornitore> categoriaFornitore = Shared.cdc.Associazione_Categoria_FornitoreSet
                   .Where(x => (x.Fornitore.ID == ((Fornitore)this.list.SelectedItem).ID) && (x.Categoria.ID == ((Categoria)this.listCombine.SelectedItem).ID));
                Shared.cdc.Associazione_Categoria_FornitoreSet.Remove(categoriaFornitore.First());
                Shared.cdc.SaveChanges();
                this.dataCombineFull.Remove(cat);
                this.dataSecondary.Add(cat);
                this.dataSecondarySubSet.Add(cat);
                //this.getData();
                searchCategoria.Text = "";
                this.orderList();
            }
        }
    }
}
