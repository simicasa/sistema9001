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
    partial class Fornitori : ControllerUC
    {
        StateController sc;
        public Fornitori() : base()
        {

            InitializeComponent();
            this.Initialize(this, typeof(Fornitore));
            this.listBoxUC1.Initialize(typeof(Fornitore), "Ragione");

            // EVENT HANDLERS
            this.addButton.Click += addButton_Click;
            this.saveButton.Click += saveButton_Click;
            this.deleteButton.Click += deleteButton_Click;
            this.annullaButton.Click += annullaButton_Click;
            this.editButton.Click += editButton_Click;
            this.listBoxUC1.SelectedIndexChanged += listBoxUC1_SelectedIndexChanged;
            this.listBoxUC1.DataSourceChanged += listBoxUC1_DataSourceChanged;
            this.searchTextBox.TextChanged += searchTextBox_TextChanged;

            this.comboBoxUC1.Initialize(typeof(String), this.GetPropertiesName());
            this.comboBoxUC1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            this.comboBoxUC1.SelectedItem = "Ragione";

            this.sc = new StateController(GetAllControlsRecursive<Control>(this.Controls, new Type[] { typeof(Panel), typeof(GroupBox), typeof(Label) }));
            this.sc.SetPersistentDisabledControls(id, creazione);
            this.sc.AddState("noItems", true, addButton);
            this.sc.AddState("moreThanZeroItems", true, listBoxUC1, searchTextBox, editButton, addButton, deleteButton, this.comboBoxUC1);
            this.sc.AddStateAdjacentFunc(StateController.INITIAL_STATE_NAME, "noItems", i => i == 0);
            this.sc.AddStateAdjacentFunc(StateController.INITIAL_STATE_NAME, "moreThanZeroItems", i => i > 0);
            this.sc.AddState("edit", true, saveButton, annullaButton, fornitorePanel, categoriaGroupBox);
            this.sc.AddStateAdjacent("moreThanZeroItems", "edit", true);
            this.sc.AddState("delete", true, "moreThanZeroItems");
            this.sc.AddStateAdjacent("moreThanZeroItems", "delete");
            this.sc.AddStateAdjacent("delete", StateController.INITIAL_STATE_NAME);
            this.sc.AddState("add", true, saveButton, annullaButton, fornitorePanel);
            this.sc.AddStateAdjacent("noItems", "add");
            this.sc.AddStateAdjacent("moreThanZeroItems", "add", true);

            this.sc.ChooseAndSetState(this.listBoxUC1.Items.Count);

            this.categoriaAddButton.Click += categoriaAddButton_Click;
            this.categoriaRemoveButton.Click += categoriaRemoveButton_Click;
        }

        private void UpdateCategorie(Fornitore fornitore)
        {
            this.treeViewUC1.Nodes.Clear();
            this.treeViewUC2.Nodes.Clear();
            Dictionary<String, List<String>> dict1 = new Dictionary<String, List<String>>();
            foreach (Categoria macro in Shared.cdc.CategoriaSet.Where(c => c.Macro == null).ToList())
            {
                Func<Categoria, ICollection<Categoria>> a = new Func<Categoria, ICollection<Categoria>>(c => c.Micro);
                dict1[macro.Nome] = new List<String>();
                foreach (Categoria micro in a(macro))
                {
                    dict1[macro.Nome].Add(micro.Nome);
                }
            }
            this.treeViewUC1.PopulateRecursive(dict1);
            var asd = from ass in Shared.cdc.Associazione_Categoria_FornitoreSet
                      join c in Shared.cdc.CategoriaSet on ass.Categoria.ID equals c.ID
                      join f in Shared.cdc.AziendaSet.OfType<Fornitore>() on ass.Fornitore.ID equals f.ID
                      where f.ID == fornitore.ID
                      select c;
            //Dictionary<String, List<String>> dict2 = new Dictionary<String, List<String>>();
            foreach (Categoria cat in asd)
            {
                TreeNode t = this.treeViewUC1.Nodes.Find(cat.Macro.Nome, false).First().Nodes.Find(cat.Nome, false).First();
                //Categoria macro = cat.Macro;
                //Func<Categoria, ICollection<Categoria>> a = new Func<Categoria, ICollection<Categoria>>(c => c.Micro);
                /*
                if (!dict2.ContainsKey(macro.Nome))
                {
                    //dict2[macro.Nome] = new List<String>();
                }
                */
                //dict1[macro.Nome].Remove(cat.Nome);
                //dict2[macro.Nome].Add(cat.Nome);
                TreeViewUCDouble.SwitchNodeBetweenTreeViews(t, treeViewUC1, treeViewUC2);
            }
            //this.treeViewUC2.PopulateRecursive(dict2);
            this.treeViewUC1.ExpandAll();
            this.treeViewUC2.ExpandAll();
        }

        private void categoriaAddButton_Click(object sender, EventArgs e)
        {
            if (this.treeViewUC1.SelectedNode != null)
            {
                Categoria categoria;
                Associazione_Categoria_Fornitore acf;
                if (this.treeViewUC1.SelectedNode.Level == 1)
                {
                    categoria = Categoria.FindByName(this.treeViewUC1.SelectedNode.Text);
                    acf = new Associazione_Categoria_Fornitore((Fornitore)this.listBoxUC1.SelectedItem, categoria);
                    Shared.cdc.Associazione_Categoria_FornitoreSet.Add(acf);
                }
                else
                {
                    foreach (TreeNode item in this.treeViewUC1.SelectedNode.Nodes)
                    {
                        categoria = Categoria.FindByName(item.Text);
                        acf = new Associazione_Categoria_Fornitore((Fornitore)this.listBoxUC1.SelectedItem, categoria);
                        Shared.cdc.Associazione_Categoria_FornitoreSet.Add(acf);
                    }
                }
                TreeViewUCDouble.SwitchNodeBetweenTreeViews(this.treeViewUC1.SelectedNode, treeViewUC1, treeViewUC2);
                Shared.cdc.SaveChanges();
            }
        }
        private void categoriaRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.treeViewUC2.SelectedNode != null)
            {
                Categoria categoria;
                Associazione_Categoria_Fornitore acf;
                if (this.treeViewUC2.SelectedNode.Level == 1)
                {
                    categoria = Categoria.FindByName(this.treeViewUC2.SelectedNode.Text);
                    acf = Associazione_Categoria_Fornitore.Find((Fornitore)this.listBoxUC1.SelectedItem, categoria);
                    Shared.cdc.Associazione_Categoria_FornitoreSet.Remove(acf);
                }
                else
                {
                    foreach (TreeNode item in this.treeViewUC2.SelectedNode.Nodes)
                    {
                        categoria = Categoria.FindByName(item.Text);
                        acf = Associazione_Categoria_Fornitore.Find((Fornitore)this.listBoxUC1.SelectedItem, categoria);
                        Shared.cdc.Associazione_Categoria_FornitoreSet.Remove(acf);
                    }
                }
                TreeViewUCDouble.SwitchNodeBetweenTreeViews(this.treeViewUC2.SelectedNode, treeViewUC2, treeViewUC1);
                Shared.cdc.SaveChanges();
            }
        }
        private void listBoxUC1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.listBoxUC1.Items.Count == 0)
            {
                //this.UpdateUIFromInstance<Fornitore>((Fornitore)new Fornitore());
            }
        }
        private void listBoxUC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxUC1.SelectedItem != null)
            {
                this.UpdateUIFromInstance<Fornitore>((Fornitore)this.listBoxUC1.SelectedItem);
                this.UpdateCategorie((Fornitore)this.listBoxUC1.SelectedItem);
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
                Shared.cdc.AziendaSet.Remove((Fornitore)this.listBoxUC1.SelectedItem);
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
                    Fornitore fornitore = this.UpdateInstanceFromUI<Fornitore>((Fornitore)this.listBoxUC1.SelectedItem);
                    //Shared.cdc.AziendaSet.AddRange(list);
                    Shared.cdc.SaveChanges();
                    this.listBoxUC1.Find(this.searchTextBox.Text);
                    this.listBoxUC1.SelectedItem = fornitore;
                }
                this.sc.SetState("moreThanZeroItems");
            }
            else if (this.sc.IsActiveState("add"))
            {
                if (DialogResult.Yes == Shared.messageBox("Sicuro di voler salvare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    List<Fornitore> list = this.CreateInstanceFromUI<Fornitore>();
                    Shared.cdc.AziendaSet.AddRange(list);
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
            this.CleanUI(fornitorePanel);
            this.treeViewUC1.Nodes.Clear();
            this.treeViewUC2.Nodes.Clear();
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            this.sc.SetState("edit");
            this.treeViewUC1.CollapseAll();
            this.treeViewUC2.CollapseAll();
        }
    }
}