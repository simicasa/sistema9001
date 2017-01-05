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
        Lista_RDO listaRDO;

        public Liste_RDO_Composizione(Lista_RDO lista) : base()
        {
            this.listaRDO = lista;

            InitializeComponent();
            
            var macroCategorie = from c in Shared.cdc.CategoriaSet
                                 where (
                                        from cc in Shared.cdc.CategoriaSet
                                        where cc.Macro != null
                                        group cc by cc.Macro.ID into gruppoMacro
                                        where gruppoMacro.Count() > 0
                                        select gruppoMacro.Key
                                        ).ToList().Contains(c.ID)
                                 select c;
            //List<Categoria> macroCategorie = Shared.cdc.CategoriaSet.Where(c => c.Macro == null).ToList();
            macroValue.DataSource = macroCategorie.ToList();
            macroValue.ValueMember = "Nome";
            macroValue.DropDownStyle = ComboBoxStyle.DropDownList;

            // DB SET
            this.dbSet = Shared.cdc.Lista_RDO_ComposizioneSet;
            // LIST
            this.list = listBox;
            this.list.DisplayMember = "Descrizione";
            this.list.ValueMember = "Descrizione";

            // BUTTONS
            this.editBt = editButton;
            this.saveBt = saveButton;
            this.deleteBt = deleteButton;
            this.addBt = addButton;
            this.cancelBt = annullaButton;

            this.initialize(this.orderList, null, new Control[] { categoriaValue, macroValue }, new Control[] { generaRDOButton });
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
            Lista_RDO_Composizione commessa_RDO_Categoria;
            if (!isNew)
            {
                int ID = Int32.Parse(unitaMisuraValue.Text);
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
            base.orderList(x => x.Descrizione);
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
            this.newInstance = new Lista_RDO_Composizione(-1, this.listaRDO, null, "", 0, "");
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
            var vai = from ll in Shared.cdc.Lista_RDO_ComposizioneSet
                      join c in Shared.cdc.CategoriaSet on ll.Categoria.ID equals c.ID
                      join acf in Shared.cdc.Associazione_Categoria_FornitoreSet on c.ID equals acf.Categoria.ID
                      join f in Shared.cdc.AziendaSet.OfType<Fornitore>() on acf.Fornitore.ID equals f.ID
                      orderby f.ID
                      select new { Fornitore = f, ListaRDOComposizione = ll};
            Fornitore fornitore, fornitoreOld = null;
            RDO rdo = null;
            foreach (var item in vai)
            {
                fornitore = item.Fornitore;
                if (fornitoreOld == null || fornitoreOld.ID != fornitore.ID)
                {
                    rdo = new RDO(-1, this.listaRDO, fornitore, "", DateTime.Now.Year.ToString(), "");
                    Shared.cdc.RDOSet.Add(rdo);
                    Shared.cdc.SaveChanges();
                }
                Shared.cdc.RDO_ComposizioneSet.Add(new RDO_Composizione(-1, item.ListaRDOComposizione, rdo));
                fornitoreOld = fornitore;
            }
            Shared.cdc.SaveChanges();
            //string nostroRiferimentoInterno = "RDO_" + DateTime.Now.Year + "_" + listaRDO.Commessa.Codice + "_" + listaRDO.Progressivo.ToString().PadLeft(4, '0') + "_" + "ProgressivoRDOGenerata";
        }

        private void macroValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.microValueUpdate();
        }
        private void microValueUpdate()
        {
            List<Categoria> microCategorie = Shared.cdc.CategoriaSet.Where(c => c.Macro != null && c.Macro.ID == ((Categoria)macroValue.SelectedItem).ID).ToList();
            categoriaValue.DataSource = microCategorie;
            categoriaValue.ValueMember = "Nome";
            categoriaValue.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
