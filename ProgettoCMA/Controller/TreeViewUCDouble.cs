using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA.Controller
{
    class TreeViewUCDouble
    {
        private TreeViewUC treeViewUC1;
        private TreeViewUC treeViewUC2;
        public TreeViewUCDouble(TreeViewUC treeViewUC1, TreeViewUC treeViewUC2)
        {
            this.treeViewUC1 = treeViewUC1;
            this.treeViewUC2 = treeViewUC2;
        }
        public void SwitchNodeBetweenTreeViews(TreeNode node)
        {
            TreeViewUCDouble.SwitchNodeBetweenTreeViews(node, this.treeViewUC1, this.treeViewUC2);
        }
        public static void SwitchNodeBetweenTreeViews(TreeNode node, TreeViewUC treeViewUCStart, TreeViewUC treeViewUC2Destination)
        {
            if (node == null)
            {
                if (Shared.isDebugPhase)
                {
                    throw new Exception("Impossibile effettuare l'operazione, il nodo selezionato e' null");
                }
                return;
            }
            else if (TreeViewUCDouble.AreTreeViewsNull(treeViewUCStart, treeViewUC2Destination))
            {
                if (Shared.isDebugPhase)
                {
                    throw new Exception("Una delle due TreeView risulta null, impossibile continuare");
                }
                return;
            }
            TreeNode[] parents = treeViewUCStart.GetParents(node, true);
            node.Remove();
            TreeNode lastParent;
            if (parents != null && parents.Length > 0)
            {
                lastParent = TreeViewUCDouble.AddBranchToTreeViewRecursively(parents, 0, treeViewUC2Destination.Nodes, null);
                lastParent.Nodes.Add(node);
            }
            else
            {
                if (treeViewUC2Destination.Nodes.ContainsKey(node.Name))
                {
                    foreach (TreeNode item in node.Nodes)
                    {
                        treeViewUC2Destination.Nodes[node.Name].Nodes.Add(item);
                    }
                }
                else
                {
                    treeViewUC2Destination.Nodes.Add(node);
                }
            }
            foreach (var item in parents)
            {
                if((int)item.Tag == 0)
                {
                    item.Remove();
                }
            }
            treeViewUC2Destination.Sort();
        }
        private static TreeNode AddBranchToTreeViewRecursively(TreeNode[] parents, int index, TreeNodeCollection nodeDestinationLevel, TreeNode lastParent)
        {
            if(index < parents.Length)
            {
                if (nodeDestinationLevel.ContainsKey(parents[index].Name))
                {
                    return TreeViewUCDouble.AddBranchToTreeViewRecursively(parents, index + 1, nodeDestinationLevel[parents[index].Name].Nodes, nodeDestinationLevel[parents[index].Name]);
                }
                else
                {
                    TreeNode clone = new TreeNode(parents[index].Text);
                    TreeViewUC.NodeSetName(clone);
                    clone.Tag = parents[index].Tag;
                    nodeDestinationLevel.Add(clone);
                    return TreeViewUCDouble.AddBranchToTreeViewRecursively(parents, index + 1, clone.Nodes, clone);
                }
            }
            return lastParent;
        }
        private bool AreTreeViewsNull()
        {
            return TreeViewUCDouble.AreTreeViewsNull(this.treeViewUC1, this.treeViewUC2);
        }
        private static bool AreTreeViewsNull(TreeViewUC treeViewUC1, TreeViewUC treeViewUC2)
        {
            if (treeViewUC1 == null || treeViewUC2 == null)
            {
                return true;
            }
            return false;
        }
    }
}
