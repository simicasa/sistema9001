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
            this.listBoxUC1.SelectedIndexChanged += listBoxUC1_SelectedIndexChanged;
            this.listBoxUC1.DataSourceChanged += listBoxUC1_DataSourceChanged;
            this.searchTextBox.TextChanged += searchTextBox_TextChanged;
            comboBox1.DataSource = this.GetPropertiesName();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedItem = "Ragione";


            this.sc = new StateController(GetAllControlsRecursive<Control>(this.Controls));
            //this.sc.AddState("edit", editButton, this.listBoxUC1.SelectedIndex != -1);
            //this.sc.SetState(new String[] { "init", "edit" });

            int blabla = 0;
            this.sc.AddState("cEqualZero", addButton, true);
            this.sc.AddState("cGreatherThanZero", new Control[] { listBoxUC1, searchTextBox, editButton, addButton, comboBox1 }, true);
            this.sc.AddStateAdjacentFunc("init", "cEqualZero", i => i == 0);
            this.sc.AddStateAdjacentFunc("init", "cGreatherThanZero", i => i > 0);
            this.sc.ChooseAndSetState(blabla);

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
            this.listBoxUC1.OrderBy(comboBox1.SelectedItem.ToString());
        }
        private void annullaButton_Click(object sender, EventArgs e)
        {
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == Shared.messageBox("Sicuro di voler eliminare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Shared.cdc.AziendaSet.Remove((Cliente)this.listBoxUC1.SelectedItem);
                Shared.cdc.SaveChanges();
                this.listBoxUC1.Find(this.searchTextBox.Text);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == Shared.messageBox("Sicuro di voler salvare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Cliente cliente = this.UpdateInstanceFromUI<Cliente>((Cliente)this.listBoxUC1.SelectedItem);
                //Shared.cdc.AziendaSet.AddRange(list);
                Shared.cdc.SaveChanges();
                this.listBoxUC1.Find(this.searchTextBox.Text);
                this.listBoxUC1.SelectedItem = cliente;
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == Shared.messageBox("Sicuro di voler salvare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                List<Cliente> list = this.CreateInstanceFromUI<Cliente>();
                Shared.cdc.AziendaSet.AddRange(list);
                Shared.cdc.SaveChanges();
                this.listBoxUC1.Find(this.searchTextBox.Text);
                this.listBoxUC1.SelectedItem = list.First();
            }
        }
    }
}