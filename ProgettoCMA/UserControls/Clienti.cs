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
    partial class Clienti : ControllerUC
    {
        StateController sc;
        /*
        private State choose(int choosingValue)
        {
            Dictionary<Func<int, bool>, State> dict = new Dictionary<Func<int, bool>, State>();
            dict.Add(a => a < 0, new State());
            dict.Add(a => a == 0, new State());
            dict.Add(a => a > 0, new State());

            Func<int, bool> ff = a => a > 0;
            List<Func<int, Func<int, bool>, State, State, State>> funcList = new List<Func<int, Func<int, bool>, State, State, State>>();
            funcList.Add((i, fff, s1, s2) => fff(i) ? s1 : s2);

            foreach (var item in dict)
            {
                if (item.Key(choosingValue))
                {
                    return item.Value;
                }
            }
            return null;
        }
        */
        public Clienti() : base()
        {
            
            InitializeComponent();
            this.Initialize(this, typeof(Cliente));
            this.listBoxUC1.Initialize(typeof(Cliente), "Ragione");

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
            this.sc.AddState("edit", true, saveButton, annullaButton, clientePanel);
            this.sc.AddStateAdjacent("moreThanZeroItems", "edit", true);
            this.sc.AddState("delete", true, "moreThanZeroItems");
            this.sc.AddStateAdjacent("moreThanZeroItems", "delete");
            this.sc.AddStateAdjacent("delete", StateController.INITIAL_STATE_NAME);
            this.sc.AddState("add", true, "edit");
            this.sc.AddStateAdjacent("noItems", "add");
            this.sc.AddStateAdjacent("moreThanZeroItems", "add");
            this.sc.AddStateAdjacent("add", StateController.INITIAL_STATE_NAME);

            this.sc.ChooseAndSetState(this.listBoxUC1.Items.Count);

            /*
            Dictionary<Control, AuthRule> controls = new Dictionary<Control, AuthRule>();
            controls.Add(this.addButton, AuthRule.Create);
            controls.Add(this.saveButton, AuthRule.Update);
            controls.Add(this.deleteButton, AuthRule.Delete);
            Authentication.SetControlsVisibility(controls, AuthRule.clienti, AuthRule.Employee, AuthRule.clienti);
            */
            //Authentication auth = new Authentication();
        }
        private void listBoxUC1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.listBoxUC1.Items.Count == 0)
            {
                //this.UpdateUIFromInstance<Cliente>((Cliente)new Cliente());
            }
        }
        private void listBoxUC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxUC1.SelectedItem != null)
            {
                this.UpdateUIFromInstance<Cliente>((Cliente)this.listBoxUC1.SelectedItem);
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
                Shared.cdc.AziendaSet.Remove((Cliente)this.listBoxUC1.SelectedItem);
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
                    Cliente cliente = this.UpdateInstanceFromUI<Cliente>((Cliente)this.listBoxUC1.SelectedItem);
                    //Shared.cdc.AziendaSet.AddRange(list);
                    Shared.cdc.SaveChanges();
                    this.listBoxUC1.Find(this.searchTextBox.Text);
                    this.listBoxUC1.SelectedItem = cliente;
                }
                this.sc.SetState("moreThanZeroItems");
            }
            else if (this.sc.IsActiveState("add"))
            {
                if (DialogResult.Yes == Shared.messageBox("Sicuro di voler salvare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    List<Cliente> list = this.CreateInstanceFromUI<Cliente>();
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
            this.CleanUI(clientePanel);
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            this.sc.SetState("edit");
        }
    }
}