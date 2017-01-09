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
    public partial class _DoubleListSwitch : UserControl
    {
        public _DoubleListSwitch()
        {
            InitializeComponent();

            TreeNode[] uni = new TreeNode[] { new TreeNode("uno1"), new TreeNode("uno2") };
            TreeNode uno = new TreeNode("uno", uni);
            treeView1.Nodes.Add(uno);
            string[] asd = { "uno1" };

            this.disableNodes(treeView1.Nodes, asd);
            treeView1.BeforeSelect += TreeView1_BeforeSelect;
            treeView1.Nodes[0].Expand();
        }
        private void disableNodes(TreeNodeCollection nodi, string[] quali)
        {
            foreach (TreeNode node in nodi)
            {
                this.disableNodes(node.Nodes, quali);
                if (quali.Contains(node.Text) || node.Parent == null)
                {
                    node.ForeColor = Color.Gray;
                }
            }
        }

        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            Shared.messageBox(sender.ToString());
            Shared.messageBox(e.Action.ToString());
            if (Color.Gray == e.Node.ForeColor)
            {
                e.Cancel = true;
            }
        }
    }
}
