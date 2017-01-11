using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA
{
    public partial class ListUC<T> : UserControl
    {
        public Action<object, EventArgs, Categoria> selectedIndexChanged;

        public ListUC()//List<T> list)
        {
            InitializeComponent();
            //this.class21.asd<Categoria>(Shared.cdc.CategoriaSet);

            this.listBoxUC1.Initialize(typeof(Categoria), "Nome");

            //this.class21.dsa(typeof(Categoria), Shared.cdc.CategoriaSet);


            //this.listBox.DataSource = new BindingList<T>(list);
            //this.listBox.SelectedIndexChanged += new EventHandler((sender, e) => listBoxSelectedIndexChanged(sender, e, new Categoria()));
            //this.listBox1.SelectedIndexChanged += this.listBoxSelectedIndexChanged;
        }

        public void listBoxSelectedIndexChanged(object o, EventArgs e)
        {
            //this.selectedIndexChanged?.Invoke(this, e, (Categoria)this.listBox1.SelectedItem);
        }
    }
}