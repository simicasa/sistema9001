using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller.DataStructures
{
    abstract public class NodeCollection
    {
        public List<Node> nodes { get; protected set; }
        
        public NodeCollection()
        {
            this.nodes = new List<Node>();
        }
        public virtual void AddNode(String name)
        {
            this.AddNode(name, null);
        }
        public virtual void AddNode(String name, Object data)
        {
            Node newNode = new Node(name, data);
            this.nodes.Add(newNode);
        }
        public Node GetNode(String nodeName)
        {
            return this.nodes.Find(n => n.name == nodeName);
        }
        public Object GetNodeData(String nodeName)
        {
            return this.GetNodeData(GetNode(nodeName));
        }
        public Object GetNodeData(Node node)
        {
            if (!this.NodeExists(node))
            {
                throw new Exception("Rilevato nodo null");
            }
            return node.data;
        }
        public bool NodeExists(String nodeName)
        {
            if (this.nodes.Find(n => n.name == nodeName) != null)
            {
                return true;
            }
            return false;
        }
        public bool NodeExists(Node node)
        {
            return (node != null) ? this.NodeExists(node.name) : false;
        }
        public virtual void RemoveNode(String nodeName, bool forceIfAdj = false)
        {
            Node node = this.GetNode(nodeName);
            this.RemoveNode(node, forceIfAdj);
        }
        public virtual void RemoveNode(Node node, bool forceIfAdj = false)
        {
            if (!this.NodeExists(node))
            {
                throw new Exception("Rilevato nodo null");
            }
            if(node.adjacences.Count > 0 && !forceIfAdj)
            {
                throw new Exception("Nono non rimosso, possiede ancora adiacenze");
            }
            node.RemoveAdjacencies();
            this.RemoveIncomingAdjacences(node);
            this.nodes.Remove(node);
        }
        public void RemoveIncomingAdjacences(Node node)
        {
            foreach (Node parent in this.nodes)
            {
                parent.RemoveAdjacency(node, false);
            }
        }
        protected void AddAjacency(Node startNode, Node adjacencyNode, Object adjacencyData)
        {
            if (!this.NodeExists(startNode) || !this.NodeExists(adjacencyNode))
            {
                throw new Exception("Rilevato nodo null, impossibile aggiungere un'adiacenza");
            }
            startNode.AddAdjacency(adjacencyNode, adjacencyData);
        }
    }
}
