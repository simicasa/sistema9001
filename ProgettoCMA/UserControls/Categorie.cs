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
using ProgettoCMA.UserControls;
using ProgettoCMA.Controller;
using static ProgettoCMA.Controller.Authentication;
using static ProgettoCMA.Controller.StateController;

namespace ProgettoCMA
{
    partial class Categorie : ControllerUC
    {
        StateController sc;
        public Categorie() : base()
        {
            InitializeComponent();
            this.Initialize(this, typeof(Categoria));
            this.listBoxUC1.SelectedIndexChanged += listBoxUC1_SelectedIndexChanged;
            this.listBoxUC1.DataSourceChanged += listBoxUC1_DataSourceChanged;
            this.listBoxUC1.Initialize(typeof(Categoria), "Nome");

            // EVENT HANDLERS
            this.addButton.Click += addButton_Click;
            this.saveButton.Click += saveButton_Click;
            this.deleteButton.Click += deleteButton_Click;
            this.annullaButton.Click += annullaButton_Click;
            this.editButton.Click += editButton_Click;
            this.searchTextBox.TextChanged += searchTextBox_TextChanged;

            this.comboBoxUC1.Initialize(typeof(String), this.GetPropertiesName());
            this.comboBoxUC1.SelectedItem = "Nome";
            this.comboBoxUC1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            
            this.comboBoxUC2.ValueMember = "Nome";
            this.comboBoxUC2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            this.checkBox1.CheckStateChanged += checkBox11_CheckStateChanged;

            this.sc = new StateController(GetAllControlsRecursive<Control>(this.Controls, new Type[] { typeof(Panel), typeof(GroupBox), typeof(Label) }));
            this.sc.SetPersistentDisabledControls(id);
            this.sc.AddState("noItems", true, addButton);
            this.sc.AddState("moreThanZeroItems", true, listBoxUC1, searchTextBox, editButton, addButton, deleteButton, this.comboBoxUC1);
            this.sc.AddStateAdjacentFunc(StateController.INITIAL_STATE_NAME, "noItems", i => i == 0);
            this.sc.AddStateAdjacentFunc(StateController.INITIAL_STATE_NAME, "moreThanZeroItems", i => i > 0);
            this.sc.AddState("edit", true, saveButton, annullaButton, categoriaPanel);
            this.sc.AddStateAdjacent("moreThanZeroItems", "edit", true);
            this.sc.AddState("delete", true, "moreThanZeroItems");
            this.sc.AddStateAdjacent("moreThanZeroItems", "delete");
            this.sc.AddStateAdjacent("delete", StateController.INITIAL_STATE_NAME);
            this.sc.AddState("add", true, "edit");
            this.sc.AddStateAdjacent("noItems", "add");
            this.sc.AddStateAdjacent("moreThanZeroItems", "add", true);

            this.sc.ChooseAndSetState(this.listBoxUC1.Items.Count);
        }
        private void UpdatePossibleMacros(Categoria categoria)
        {
            this.comboBoxUC2.Initialize(typeof(Categoria), Shared.cdc.CategoriaSet.Where(c => c.Macro == null && c.ID != categoria.ID).ToList());
        }
        private void checkBox11_CheckStateChanged(object sender, EventArgs e)
        {
            if(this.listBoxUC1.SelectedItem != null)
            {
                if (this.checkBox1.Checked)
                {
                    this.UpdatePossibleMacros((Categoria)this.listBoxUC1.SelectedItem);
                }
                else if(this.comboBoxUC2.Items.Count > 0)
                {
                    this.comboBoxUC2.DataSourceUpdate(new List<Categoria>());
                }
            }
        }
        private void listBoxUC1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.listBoxUC1.Items.Count == 0)
            {
                //this.UpdateUIFromInstance<Categoria>((Categoria)new Categoria());
            }
        }
        private void listBoxUC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxUC1.SelectedItem != null)
            {
                this.UpdateUIFromInstance<Categoria>((Categoria)this.listBoxUC1.SelectedItem);
                if(((Categoria)this.listBoxUC1.SelectedItem).Macro != null)
                {
                    this.checkBox1.Checked = true;
                    this.comboBoxUC2.SelectedItem = ((Categoria)this.listBoxUC1.SelectedItem).Macro;
                    this.listBoxUC2.DataSourceUpdate(new List<Categoria>());
                }
                else
                {
                    this.checkBox1.Checked = false;
                    this.listBoxUC2.Initialize(typeof(Categoria), "Nome", ((Categoria)this.listBoxUC1.SelectedItem).Micro);
                }
            }
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            this.listBoxUC1.Find(this.searchTextBox.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBoxUC1.OrderBy(this.comboBoxUC1.SelectedItem.ToString());
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Shared.messageBox(((Categoria)this.comboBoxUC2.SelectedItem).Nome);
        }
        private void annullaButton_Click(object sender, EventArgs e)
        {
            this.sc.SetState(StateController.INITIAL_STATE_NAME);
            this.sc.ChooseAndSetState(this.listBoxUC1.Items.Count);
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.sc.SetState("delete");
            if (DialogResult.Yes == Shared.messageBox("Sicuro di voler eliminare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Shared.cdc.CategoriaSet.Remove((Categoria)this.listBoxUC1.SelectedItem);
                Shared.cdc.SaveChanges();
                this.listBoxUC1.Find(this.searchTextBox.Text);
            }
            this.sc.SetState(StateController.INITIAL_STATE_NAME);
            this.sc.ChooseAndSetState(this.listBoxUC1.Items.Count);
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.sc.IsActiveState("edit"))
            {
                if (DialogResult.Yes == Shared.messageBox("Sicuro di voler salvare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Categoria categoria = this.UpdateInstanceFromUI<Categoria>((Categoria)this.listBoxUC1.SelectedItem);
                    //Shared.cdc.AziendaSet.AddRange(list);
                    Shared.cdc.SaveChanges();
                    this.listBoxUC1.Find(this.searchTextBox.Text);
                    this.listBoxUC1.SelectedItem = categoria;
                }
                this.sc.SetState("moreThanZeroItems");
            }
            else if (this.sc.IsActiveState("add"))
            {
                if (DialogResult.Yes == Shared.messageBox("Sicuro di voler salvare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    List<Categoria> list = this.CreateInstanceFromUI<Categoria>();
                    Shared.cdc.CategoriaSet.AddRange(list);
                    Shared.cdc.SaveChanges();
                    this.listBoxUC1.Find(this.searchTextBox.Text);
                    this.listBoxUC1.SelectedItem = list.First();
                }
                this.sc.SetState(StateController.INITIAL_STATE_NAME);
                this.sc.ChooseAndSetState(this.listBoxUC1.Items.Count);
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            this.sc.SetState("add");
            this.CleanUI(categoriaPanel);
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            this.sc.SetState("edit");
        }
    }
}