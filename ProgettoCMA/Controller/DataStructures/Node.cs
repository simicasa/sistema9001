using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller.DataStructures
{
    public class Node
    {
        public String name { get; private set; }
        public List<NodeAdjacency> adjacences { get; private set; }

        public Object data { get; private set; }
        public Type dataType { get; private set; }

        public Node(String name, Object data)
        {
            this.name = name;
            this.adjacences = new List<NodeAdjacency>();
            this.data = data;
            this.dataType = data?.GetType();
        }
        public Node AddAdjacency(Node adjacencyNode, Object adjacencyInfo)
        {
            NodeAdjacency newAdj = new NodeAdjacency(adjacencyNode, adjacencyInfo);
            this.adjacences.Add(newAdj);
            return this;
        }
        public NodeAdjacency GetAdjacency(String nodeName)
        {
            return this.adjacences.Find(n => n.node.name == nodeName);
        }
        public NodeAdjacency GetAdjacency(Node node)
        {
            return this.GetAdjacency(node.name);
        }
        public bool RemoveAdjacency(String nodeName, bool raiseException = true)
        {
            NodeAdjacency nodeAdjacency = this.GetAdjacency(nodeName);
            return this.RemoveAdjacency(nodeAdjacency, raiseException);
        }
        public bool RemoveAdjacency(Node node, bool raiseException = true)
        {
            NodeAdjacency nodeAdjacency = this.GetAdjacency(node);
            return this.RemoveAdjacency(nodeAdjacency, raiseException);
        }
        private bool RemoveAdjacency(NodeAdjacency nodeAdjacency, bool raiseException)
        {
            if (nodeAdjacency == null)
            {
                if (raiseException)
                {
                    throw new Exception("Adiacenza non trovata");
                }
            }
            else
            {
                this.adjacences.Remove(nodeAdjacency);
            }
            return true;
        }
        public int RemoveAdjacencies(bool raiseException = true)
        {
            int removedCount = this.adjacences.Count;
            foreach (NodeAdjacency adj in this.adjacences)
            {
                this.RemoveAdjacency(adj, raiseException);
            }
            return removedCount;
        }
    }
}
