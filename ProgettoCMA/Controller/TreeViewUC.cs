using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA.Controller
{
    public class TreeViewUC : TreeView, IController
    {
        private Controller controller;

        public TreeViewUC()
        {
            this.controller = new Controller(true);
        }
        public void PopulateRecursive(dynamic list, TreeNodeCollection level = null)
        {
            if (level == null)
            {
                level = this.Nodes;
            }
            Type listType = ((Object)list).GetType();
            if(listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                this.PopulateRecursiveDict(list, level);
            }
            else if (listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof(List<>))
            {
                this.PopulateRecursiveList(list, level);
            }
        }
        public void PopulateRecursiveDict(dynamic list, TreeNodeCollection level)
        {
            Type[] arguments = list.GetType().GetGenericArguments();
            //Type keyType = arguments[0];
            Type valueType = arguments[1];

            TreeNode node;
            if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                foreach (var item in list)
                {
                    node = new TreeNode(item.Key);
                    level.Add(node);
                    TreeViewUC.NodeSetName(node);
                    this.PopulateRecursiveDict(item.Value, node.Nodes);
                }
            }
            if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
            {
                foreach (var item in list)
                {
                    node = new TreeNode(item.Key);
                    level.Add(node);
                    TreeViewUC.NodeSetName(node);
                    this.PopulateRecursiveList(item.Value, node.Nodes);
                }
            }
        }
        public void PopulateRecursiveList(List<String> list, TreeNodeCollection level)
        {
            TreeNode node;
            foreach (var item in list)
            {
                node = new TreeNode(item);
                TreeViewUC.NodeSetName(node);
                level.Add(node);
            }
            //Type listType = ((ObjectHandle)list).Unwrap().GetType();
        }
        /*
        DataSourceUpdate(Dictionary<dynamic, Dictionary<dynamic, List<dynamic>>>)
        private void DataSourceUpdate(dynamic list)
        {
            foreach (var macro in Shared.cdc.CategoriaSet.Where(c => c.Macro == null).ToList())
            {
                microCategorie = new List<TreeNode>();
                foreach (Categoria micro in macro.Micro)
                {
                    microCategorie.Add(new TreeNode(micro.Nome));
                }
                categorie.Add(new TreeNode(macro.Nome, microCategorie.ToArray()));
            }
            this.Nodes.AddRange(categorie.ToArray());
        }
        */
        public void AddNode(TreeNode node)
        {
            TreeViewUC.NodeSetNameRecursively(node);
            this.Nodes.Add(node);
        }
        public static void NodeSetName(TreeNode node, String name = null)
        {
            if(name != null)
            {
                node.Name = name;
            }
            else
            {
                node.Name = node.Text.Replace(" ", "");
            }
        }
        public static void NodeSetNameRecursively(TreeNode node)
        {
            TreeViewUC.NodeSetName(node);
            foreach (TreeNode subNode in node.Nodes)
            {
                TreeViewUC.NodeSetNameRecursively(subNode);
            }
        }
        public TreeNode[] GetParents(TreeNode node)
        {
            return this.GetParentsRecursive(node.Parent, node.Level - 1, new TreeNode[node.Level]);
        }
        public TreeNode[] GetParents(TreeNode node, bool markDeletableNodes)
        {
            return this.GetParentsRecursive(node.Parent, node.Level - 1, new TreeNode[node.Level], markDeletableNodes);
        }
        public static TreeNode[] GetParents(TreeViewUC treeViewUC, TreeNode node)
        {
            return treeViewUC.GetParents(node);
        }
        public TreeNode[] GetBranch(TreeNode node)
        {
            return this.GetParents(node).Concat(new TreeNode[] { node }).ToArray();
        }
        public TreeNode[] GetBranch(TreeNode node, bool markDeletableNodes)
        {
            TreeNode[] branch = this.GetParentsRecursive(node.Parent, node.Level - 1, new TreeNode[node.Level], markDeletableNodes).Concat(new TreeNode[] { node }).ToArray();
            if (markDeletableNodes)
            {
                node.Tag = 0;
            }
            return branch;
        }
        public static TreeNode[] GetBranch(TreeViewUC treeViewUC, TreeNode node)
        {
            return treeViewUC.GetBranch(node);
        }
        private TreeNode[] GetParentsRecursive(TreeNode node, int index, TreeNode[] parents, bool markDeletableNodes = false, bool markDeletableNodesFlag = false)
        {
            if (this.NodeExists(node))
            {
                parents[index] = node;
                if (markDeletableNodes)
                {
                    if (!markDeletableNodesFlag)
                    {
                        if (node.Nodes.Count > 1)
                        {
                            node.Tag = -1;
                            markDeletableNodesFlag = true;
                        }
                        else
                        {
                            node.Tag = 0;
                        }
                    }
                    else
                    {
                        node.Tag = -1;
                    }
                }
                if (this.NodeHasParent(node))
                {
                    this.GetParentsRecursive(node.Parent, index-1, parents, markDeletableNodes, markDeletableNodesFlag);
                }
            }
            return parents;
        }
        public bool NodeExists(TreeNode node)
        {
            return TreeViewUC.NodeBelongsToTreeView(node, this);
        }
        public static bool NodeBelongsToTreeView(TreeNode node, TreeViewUC treeViewUC)
        {
            if(node != null)
            {
                if(node.Parent != null)
                {
                    return TreeViewUC.NodeBelongsToTreeView(node.Parent, treeViewUC);
                }
                return treeViewUC.Nodes.Contains(node);
            }
            return false;
        }
        public bool NodeHasParent(TreeNode node)
        {
            return node.Parent != null;
        }
    }
}
