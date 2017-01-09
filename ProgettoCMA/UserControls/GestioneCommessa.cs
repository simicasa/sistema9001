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
            this.emptyListClean();
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

            //this.groupBox3.Visible = false;
        }
        private void emptyListClean()
        {
            var provola = from listaa in Shared.cdc.Lista_RDOSet
                          where !(
                              from c in Shared.cdc.Lista_RDO_ComposizioneSet
                              group c.Lista_RDO by c.Lista_RDO.ID into coccos
                              select coccos.Key).Contains(listaa.ID)
                          select listaa;
            foreach (var item in provola)
            {
                Shared.cdc.Lista_RDOSet.Remove(item);
            }
            Shared.cdc.SaveChanges();
        }
        private void orderList()
        {
            base.orderList(x => x.Codice, x => x.Progressivo);
            this.listSecondary.DataSource = new BindingList<Lista_RDO>(this.dataSecondarySubSet.Where(l => l.Commessa.ID == Shared.commessaAttiva.ID).ToList());
        }
        private new void addButton_Click(object sender, EventArgs e)
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
            string progressivo = (Shared.cdc.Lista_RDOSet.Count() + 1).ToString().PadLeft(4, '0');
            Lista_RDO newLista = new Lista_RDO(-1, Shared.commessaAttiva, "", progressivo, DateTime.Now.Year.ToString());
            Shared.cdc.Lista_RDOSet.Add(newLista);
            Shared.cdc.SaveChanges();
            Shared.home.controlsAdd(new Liste_RDO_Composizione(newLista));
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void visualizzaButton_Click(object sender, EventArgs e)
        {
            if(this.listSecondary.SelectedIndex != -1)
            {
                Shared.home.controlsAdd(new Liste_RDO_Composizione((Lista_RDO)this.listSecondary.SelectedItem, false));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shared.home.controlsAdd(new ODA_Composizioni());
            /*
            newODA newoda = new newODA();
            newoda.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            newoda.FormBorderStyle = FormBorderStyle.FixedSingle;
            newoda.ShowDialog();
            */
        }
    }
}
