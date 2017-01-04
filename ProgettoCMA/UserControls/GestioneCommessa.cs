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

            // BUTTONS
            //this.editBt = editButton;
            //this.saveBt = saveButton;
            //this.deleteBt = deleteButton;
            //this.addBt = addButton;
            //this.cancelBt = annullaButton;

            //this.initialize(, );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shared.home.controlsAdd(new Liste_RDO_Composizione());
        }
    }
}
