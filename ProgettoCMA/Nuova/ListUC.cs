using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA.Nuova
{
    public partial class ListUC<T> : Class1
    {
        public ListBox listBox;
        public event EventHandler selectedIndexChanged;
        public ListUC(List<T> list)
        {
            InitializeComponent();
            //this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox = new ListBox();
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new Point(0, 0);
            this.listBox.Name = "listBox1";
            this.listBox.Size = new Size(120, 120);
            this.listBox.TabIndex = 0;

            this.Controls.Add(this.listBox);
            this.listBox.DataSource = new BindingList<T>(list);
            //this.listBox.SelectedIndexChanged += new EventHandler(this.listBoxSelectedIndexChanged);
        }
        public virtual void listBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Shared.messageBox("a");
            this.selectedIndexChanged?.Invoke(this, e);
        }

        public delegate void TestDelegate(Categoria c);
        public virtual void asd(/*Action<object, EventArgs> dsa, */TestDelegate testDelB)
        {
            //testDelB("asd");
            testDelB(new Categoria());
            //this.listBox.SelectedIndexChanged += new EventHandler(dsa);
        }
    }
}