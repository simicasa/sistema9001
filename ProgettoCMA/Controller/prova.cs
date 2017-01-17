using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgettoCMA.UserControls;

namespace ProgettoCMA.Controller
{
    public partial class prova : ControllerUC
    {
        public prova() : base()
        {
            InitializeComponent();
            this.Initialize(this, typeof(Cliente));
            this.comboBoxUC1.Initialize(typeof(String), this.GetPropertiesName());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.comboBoxUC1.Sort();
        }
    }
}
