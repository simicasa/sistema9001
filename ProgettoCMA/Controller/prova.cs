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
        public void asd<T>(Func<dynamic, bool> dd, Dictionary<String, dynamic> dict)
        {
            foreach (T item in Shared.cdc.CategoriaSet.Where(dd).ToList())
            {
                /*
                dict[macro.Nome] = new List<String>();
                foreach (Categoria micro in macro.Micro)
                {
                    dict[macro.Nome].Add(micro.Nome);
                }
                */
            }
        }
        public prova() : base()
        {
            InitializeComponent();
            this.Initialize(this, typeof(Cliente));

            Node node1 = new Node("uno", null);
            Node node2 = new Node("due", null);
            Node node3 = new Node("tre", null);
            Node node4 = new Node("quattro", null);

            node1.AddAdjacency(node2, null);
            node1.AddAdjacency(node3, null);
            node1.AddAdjacency(node4, null);

            NodeAdjacency temp;

            temp = node1.GetAdjacency("tre");
            Console.WriteLine(temp.node.name);

            temp = node1.GetAdjacency(node3);
            Console.WriteLine(temp.node.name);

            /*
            //this.comboBoxUC1.Initialize(typeof(String), this.GetPropertiesName());
            //this.asd<Categoria>(c => c.Macro == null, new Dictionary<String, List<String>>());
            Dictionary<String, List<String>> dict = new Dictionary<String, List<String>>();
            //Func<Categoria, bool> func = new Func<Categoria, bool>(c => );
            foreach (Categoria macro in Shared.cdc.CategoriaSet.Where(c => c.Macro == null).ToList())
            {
                Func<Categoria, ICollection<Categoria>> a = new Func<Categoria, ICollection<Categoria>>(c => c.Micro);
                dict[macro.Nome] = new List<String>();
                foreach (Categoria micro in a(macro))//macro.Micro)
                {
                    dict[macro.Nome].Add(micro.Nome);
                }
            }
            this.treeViewUC1.PopulateRecursive(dict);
            */

            /*
            List<TreeNode> categorie = new List<TreeNode>();
            List<TreeNode> microCategorie;
            foreach (Categoria macro in Shared.cdc.CategoriaSet.Where(c => c.Macro == null).ToList())
            {
                microCategorie = new List<TreeNode>();
                foreach (Categoria micro in macro.Micro)
                {
                    microCategorie.Add(new TreeNode(micro.Nome));
                }
                categorie.Add(new TreeNode(macro.Nome, microCategorie.ToArray()));
            }
            treeViewUC1.Nodes.AddRange(categorie.ToArray());
            */

            /*
            TreeNode node1 = new TreeNode("padre1");
            TreeNode figlio1 = new TreeNode("figlio1");
            TreeNode figlioletto = new TreeNode("figlioletto");
            TreeNode figlio2 = new TreeNode("figlio2", new TreeNode[] { figlioletto });
            TreeNode figlio3 = new TreeNode("figlio3");
            TreeNode node2 = new TreeNode("padre2", new TreeNode[] { figlio1, figlio2, figlio3 });
            treeViewUC1.AddNode(node1);
            treeViewUC1.AddNode(node2);
            */

            maggiore.Click += maggiore_Click;
            minore.Click += minore_Click;
        }

        private void maggiore_Click(object sender, EventArgs e)
        {
            TreeViewUCDouble.SwitchNodeBetweenTreeViews(this.treeViewUC1.SelectedNode, treeViewUC1, treeViewUC2);
        }
        private void minore_Click(object sender, EventArgs e)
        {
            TreeViewUCDouble.SwitchNodeBetweenTreeViews(this.treeViewUC2.SelectedNode, treeViewUC2, treeViewUC1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.comboBoxUC1.Sort();
        }
    }
}
