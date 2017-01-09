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
    public partial class ODA_Composizioni : UserControl
    {
        public ODA_Composizioni()
        {
            InitializeComponent();
            /*
            this.tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            this.tableLayoutPanel1.RowCount++;
            this.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoScrollMinSize = new Size(this.tableLayoutPanel1.Width, 20);
            this.tableLayoutPanel1.HorizontalScroll.Enabled = false;
            this.tableLayoutPanel1.VerticalScroll.Enabled = true;
            this.tableLayoutPanel1.MaximumSize = new Size(this.tableLayoutPanel1.Width, 220);
            this.tableLayoutPanel1.MinimumSize = new Size(this.tableLayoutPanel1.Width, 20);
            */
        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.tableLayoutPanel1.RowCount == 5)
            {
                this.tableLayoutPanel1.Size = new Size(this.tableLayoutPanel1.Width + 20, this.tableLayoutPanel1.Height);
            }
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            this.tableLayoutPanel1.Controls.Add(new Label() { Text = "a" }, 0, this.tableLayoutPanel1.RowCount - 1);
            this.tableLayoutPanel1.Controls.Add(new Label() { Text = "b" }, 1, this.tableLayoutPanel1.RowCount - 1);
            this.tableLayoutPanel1.Controls.Add(new Label() { Text = "c" }, 2, this.tableLayoutPanel1.RowCount - 1);
            this.tableLayoutPanel1.Controls.Add(new Label() { Text = "d" }, 3, this.tableLayoutPanel1.RowCount - 1);
        }
        */
    }
}
