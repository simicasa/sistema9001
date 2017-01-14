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
            this.listBoxUC1.SelectedIndexChanged += listBoxUC1_SelectedIndexChanged;
            this.searchTextBox.TextChanged += searchTextBox_TextChanged;
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

        private void addButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == Shared.messageBox("Sicuro di voler salvare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                List<Cliente> list = this.CreateInstanceFromUI<Cliente>();
                Shared.cdc.AziendaSet.AddRange(list);
                Shared.cdc.SaveChanges();
                this.listBoxUC1.Find(this.searchTextBox.Text);
            }
        }
    }
}