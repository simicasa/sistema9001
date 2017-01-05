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
    public partial class GestioneCommessa : UC<Commessa, Lista_RDO>
    {
        public GestioneCommessa() : base()
        {
            InitializeComponent();

            // DB SET
            this.dbSet = Shared.cdc.CommessaSet;
            this.dbSetSecondary = Shared.cdc.Lista_RDOSet;
            this.initializeTextBoxes();
            this.updateUI(Shared.commessaAttiva);
            foreach (var item in panel1.Controls.OfType<TextBox>())
            {
                item.BorderStyle = BorderStyle.None;
                item.BackColor = SystemColors.Control;
            }
            // LIST
            /*
            this.list = listBox;
            this.list.DisplayMember = "Ragione";
            this.list.ValueMember = "Ragione";
            */
            this.listSecondary = listBox1;
            this.listSecondary.DisplayMember = "Progressivo";
            this.listSecondary.ValueMember = "Progressivo";

            // BUTTONS
            //this.editBt = editButton;
            //this.saveBt = saveButton;
            //this.deleteBt = deleteButton;
            //this.addBt = addButton;
            //this.cancelBt = annullaButton;

            this.initialize(this.orderList);
        }
        private void orderList()
        {
            base.orderList(x => x.Codice);
            this.listSecondary.DataSource = this.dataSecondarySubSet;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var speriamoBBene = from c in Shared.cdc.CategoriaSet
                                where c.Macro != null
                                group c by c.Macro.ID into gruppoMacro
                                where gruppoMacro.Count() > 0
                                select gruppoMacro.Key;
            if (speriamoBBene.Count() <= 0)
            {
                Shared.messageBox("Non sono presenti categorie.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Lista_RDO newLista = new Lista_RDO(-1, Shared.commessaAttiva, "", "");
            Shared.cdc.Lista_RDOSet.Add(newLista);
            Shared.cdc.SaveChanges();
            Shared.home.controlsAdd(new Liste_RDO_Composizione(newLista));
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
