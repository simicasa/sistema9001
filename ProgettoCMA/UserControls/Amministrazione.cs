using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA.UserControls
{
    public partial class Amministrazione : UserControl
    {
        public Amministrazione()
        {
            InitializeComponent();

            this.comboBoxUC1.Initialize(typeof(String), new List<String>() { Boolean.TrueString, Boolean.FalseString });
            this.comboBoxUC1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            this.comboBoxUC1.SelectedItem = Shared.isDebugPhase.ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shared.isDebugPhase = Boolean.Parse(this.comboBoxUC1.SelectedItem.ToString());
        }
    }
}
