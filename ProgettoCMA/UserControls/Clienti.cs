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

namespace ProgettoCMA
{
    partial class Clienti : ControllerUC
    {
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
            Dictionary<Control, AuthRule> controls = new Dictionary<Control, AuthRule>();
            controls.Add(this.addButton, AuthRule.Create);
            controls.Add(this.saveButton, AuthRule.Update);
            controls.Add(this.deleteButton, AuthRule.Delete);
            Authentication.SetControlsVisibility(controls, AuthRule.clienti, AuthRule.Employee, AuthRule.clienti);
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