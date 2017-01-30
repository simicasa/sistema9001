using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller.DataStructures
{
    class Tree : NodeCollection
    {
        public enum INSERT_MODE
        {
            CUSTOM = 0,
            COMPLETE_TREE = 1
        }
        public int childrenNumber { get; protected set; }
        public Node root { get; protected set; }
        public INSERT_MODE insertMode { get; protected set; }
        public Tree(int nodeChildrenNumber, INSERT_MODE insertMode = INSERT_MODE.COMPLETE_TREE) : base()
        {
            this.childrenNumber = nodeChildrenNumber;
            this.insertMode = insertMode;
        }
        public override void AddNode(String name)
        {
            this.AddNode(name, null);
        }
        public override void AddNode(String name, Object data)
        {
            switch (this.insertMode)
            {
                case INSERT_MODE.COMPLETE_TREE:
                    this.AddNodeCompleteTree(name, data);
                    break;
                default:
                    throw new Exception("INSERT_MODE non valido, impossibile aggiungere un nodo");
                    break;
            }
            //int parentIndex = this.GetParentIndex();
            /*
            double a = Math.Floor(Math.Log(this.nodes.Count, this.childrenNumber));
            Console.WriteLine(parentIndex + ", h=" + a);
            */
            /*
            double a = Math.Round(Math.Log(this.nodes.Count, this.childrenNumber), MidpointRounding.AwayFromZero);
            Console.WriteLine(parentIndex + ", h=" + a);

            if (parentIndex > -1)
            {
                Node parent = this.nodes[parentIndex];
                Node node = this.GetNode(name);
                //Console.WriteLine("Genitore " + (parentIndex - 1) + " " + parent.name);
                this.AddAjacencyBody(parent, node, data);
            }
            */
        }
        private void AddNodeCompleteTree(String name, Object data)
        {
            Queue<Node> queue = new Queue<Node>(this.nodes.Count);
            if (this.nodes.Count > 0)
            {
                queue.Enqueue(this.root);
            }
            Node parent = this.AddNodeGetParentRecursive(queue);

            base.AddNode(name, data);
            if (parent == null)
            {
                this.root = this.GetNode(name);
            }
            else
            {
                parent.AddAdjacency(this.GetNode(name), data);
            }
        }
        private Node AddNodeGetParentRecursive(Queue<Node> queue)
        {
            if(queue.Count > 0)
            {
                Node node = queue.Dequeue();
                if(node.adjacences.Count < this.childrenNumber)
                {
                    return node;
                }
                foreach (NodeAdjacency adj in node.adjacences)
                {
                    queue.Enqueue(adj.node);
                }
                return this.AddNodeGetParentRecursive(queue);
            }
            return null;
        }
        public new Tree AddAjacency(Node startNode, Node adjacencyNode, Object adjacencyData)
        {
            switch (this.insertMode)
            {
                case INSERT_MODE.CUSTOM:
                    break;
                default:
                    throw new Exception("Aggiunta adiacenza non possibile con l'INSERT_MODE scelto");
            }
            return this.AddAjacencyBody(startNode, adjacencyNode, adjacencyData);
        }
        protected Tree AddAjacencyBody(Node startNode, Node adjacencyNode, Object adjacencyData)
        {
            base.AddAjacency(startNode, adjacencyNode, adjacencyData);
            return this;
        }
        public override void RemoveNode(String nodeName, bool forceIfAdj = false)
        {
            this.RemoveNode(this.GetNode(nodeName), forceIfAdj);
        }
        public override void RemoveNode(Node node, bool forceIfAdj = false)
        {
            /*
            public override void RemoveNode(Node node, bool forceIfAdj = false)
            {
                int parentIndex = this.GetParentIndex(node);
                Node removedParent = this.nodes[parentIndex];

                Node last = this.nodes.Last();
                Node lastParent = this.GetParent(last);
                lastParent.RemoveAdjacency(last);

                this.CloneAdjanceses(removedParent, last);
                Object adjData = removedParent.GetAdjacency(node).info;
                removedParent.AddAdjacency(last, adjData);

                base.RemoveNode(node, forceIfAdj);

            }*/
        }
        private Node GetLastNode()
        {
            List<int> path = new List<int>();
            decimal ris = this.nodes.Count;
            while(ris != 0)
            {
                ris = Math.Floor(ris / this.childrenNumber);
                path.Add((int)ris);
                ris -= 1;
            }
            return null;
        }
        /*
        private int GetParentIndex()
        {
            return this.GetParentIndex(this.nodes.Count);
        }
        private int GetParentIndex(Node node)
        {
            return this.GetParentIndex(this.nodes.IndexOf(node));
        }
        private int GetParentIndex(int position)
        {
            return ((int)Math.Round((decimal)position / (decimal)this.childrenNumber, MidpointRounding.AwayFromZero) - 1);
        }
        private Node GetParent(Node node)
        {
            return this.nodes[this.GetParentIndex(node)];
        }
        */

        public void provola()
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                Console.WriteLine(this.nodes[i].name + " " + i);
                foreach (var adj in this.nodes[i].adjacences)
                {
                    Console.WriteLine("-- " + adj.node.name + " " + this.nodes.IndexOf(adj.node));
                }
            }
            Console.WriteLine(" ");
        }
    }
}
