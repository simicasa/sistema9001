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
    public partial class Categorie : UC<Categoria>
    {
        public Categorie() : base()
        {
            InitializeComponent();

            // DB SET
            this.dbSet = Shared.cdc.CategoriaSet;

            // LIST
            this.list = listBox;
            this.list.DisplayMember = "Nome";
            this.list.ValueMember = "Nome";

            // BUTTONS
            this.editBt = editButton;
            this.saveBt = saveButton;
            this.deleteBt = deleteButton;
            this.addBt = addButton;
            this.cancelBt = annullaButton;

            microValue1.Enabled = false;
            this.initialize(this.orderList, null, new Control[] { macroValue, hasMacro });
        }
        protected override void updateUIbefore(Categoria instanceToShow)
        {
            if(instanceToShow != null)
            {
                //List<Categoria> temp = new List<Categoria>() { new Categoria(-1, "- Nessuna", null) };
                //macroValue.DataSource = temp.Union(Shared.cdc.CategoriaSet.Where(c => c.Macro == null && c.ID != instanceToShow.ID)).ToList();
                macroValue.DataSource = Shared.cdc.CategoriaSet.Where(c => c.Macro == null && c.ID != instanceToShow.ID).ToList();
                macroValue.ValueMember = "Nome";
                macroValue.DropDownStyle = ComboBoxStyle.DropDownList;
                if (instanceToShow.Micro != null && instanceToShow.Micro.Count() > 0)
                {
                    panelMacro.Visible = false;
                    panelMicro.Visible = true;
                    microValue1.Clear();
                    /*
                    IEnumerator<Categoria> cc = instanceToShow.Micro.GetEnumerator();
                    while (cc.MoveNext())
                    {
                        microValue1.Text = cc.Current.Nome + ", ";
                    }
                    */
                    foreach (var item in instanceToShow.Micro)
                    {
                        if (microValue1.TextLength > 0)
                        {
                            microValue1.Text += "\r\n";
                        }
                        microValue1.Text += item.Nome;
                    }
                }
                else
                {
                    panelMacro.Visible = true;
                    panelMicro.Visible = false;
                    if (instanceToShow.Macro != null)
                    {
                        macroValue.SelectedItem = instanceToShow.Macro;
                        hasMacro.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        macroValue.SelectedIndex = -1;
                        hasMacro.CheckState = CheckState.Unchecked;
                    }
                }
            }
        }
        protected override void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.newInstance != null)
            {
                if (DialogResult.Yes == this.messageBoxShow("Cambiare categoria e perdere il nuovo?", MessageBoxButtons.YesNo))
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
            if (macroValue.SelectedIndex != -1)
            {
                macroValue.Enabled = true;
            }
            else
            {
                macroValue.Enabled = false;
            }
            this.buttonsUpdate(true);
            searchTextBox.Enabled = false;
            this.list.Enabled = false;

            this.textBoxesEnable(true);
            idValue.Enabled = false;
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
            Categoria categoria;
            if (!isNew)
            {
                int ID = Int32.Parse(idValue.Text);
                categoria = Shared.cdc.CategoriaSet.Where(x => x.ID == ID).First();
                this.databaseUpdate(categoria);
                Categoria old = this.dataSubset[this.selectedIndex];
                this.dataSubset[this.selectedIndex] = categoria;
                this.data[this.data.IndexOf(old)] = categoria;
            }
            else
            {
                categoria = this.newInstance;
                this.databaseAdd(categoria);
            }
            this.orderList();
            this.list.SelectedItem = categoria;
            searchTextBox.Text = "";
            this.newInstance = null;
            this.listInhibit = false;
        }
        private void orderList()
        {
            base.orderList(x => x.Nome);
            this.list.DataSource = this.dataSubset;
        }

        protected override void editButton_Click(object sender, EventArgs e)
        {
            if (this.selectedIndex == -1)
            {
                MessageBox.Show("Nessun categoria presente", "Gestione Categoria", MessageBoxButtons.OK);
                return;
            }
            this.editButtons();
        }
        protected override void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continuare con il salvataggio?", "Aggiunta Categoria", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.saveButtons();
                this.updateFields();
            }
        }
        protected override void addButton_Click(object sender, EventArgs e)
        {
            this.listInhibit = true;
            this.newInstance = new Categoria(-1, "", null);
            this.data.Add(newInstance);
            this.dataSubset.Add(newInstance);
            this.orderList();
            this.list.SelectedItem = newInstance;
            this.selectedIndex = this.list.SelectedIndex;
            this.editButtons();
            this.updateUI(this.newInstance);
            this.listInhibit = false;
            macroValue.Enabled = false;
            hasMacro.Checked = false;
        }
        protected override void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Eliminare il categoria?", "Gestione categorie", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Categoria categoria = (Categoria)this.listBox.SelectedItem;
                this.listInhibit = true;
                Shared.cdc.CategoriaSet.Remove(categoria);
                this.data.Remove(categoria);
                this.dataSubset.Remove(categoria);
                this.listInhibit = false;
                this.orderList();
                Shared.cdc.SaveChanges();
            }
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            base.searchTextBoxFilterData(c => c.Nome.Contains(searchTextBox.Text));
        }
        protected override void annullaButton_Click(object sender, EventArgs e)
        {
            updateUI(this.dataSubset[this.selectedIndex]);
            saveButtons();
        }

        private void hasMacro_CheckedChanged(object sender, EventArgs e)
        {
            if (this.saveBt.Enabled)
            {
                if (((CheckBox)sender).Checked)
                {
                    macroValue.Enabled = true;
                }
                else
                {
                    macroValue.Enabled = false;
                    macroValue.SelectedIndex = -1;
                }
            }
        }
    }
}
