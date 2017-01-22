using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoCMA.Controller.NodeStruct;

namespace ProgettoCMA.Controller.GraphStruct
{
    public class Graph
    {
        public List<Node> nodes { get; private set; }

        public Graph()
        {

        }
        public Graph AddNode(String name)
        {
            return this.AddNode(name, null);
        }
        public Graph AddNode(String name, Object info)
        {
            Node newNode = new Node(name, info);
            this.nodes.Add(newNode);
            return this;
        }
        public Graph AddAjacency(Node startNode, Node adjacencyNode, Object adjacencyInfo)
        {
            if (!this.NodeExists(startNode) || !this.NodeExists(adjacencyNode))
            {
                throw new Exception("Rilevato nodo null, impossibile aggiungere un'adiacenza");
            }
            startNode.AddAdjacency(adjacencyNode, adjacencyInfo);
            return this;
        }
        public Node GetNode(String nodeName)
        {
            return this.nodes.Find(n => n.name == nodeName);
        }
        public Object GetNodeInfo(String nodeName)
        {
            return this.GetNodeInfo(GetNode(nodeName));
        }
        public Object GetNodeInfo(Node node)
        {
            if (!this.NodeExists(node))
            {
                throw new Exception("Rilevato nodo null");
            }
            return node.info;
        }
        public bool NodeExists(String nodeName)
        {
            if(this.nodes.Find(n => n.name == nodeName) != null)
            {
                return true;
            }
            return false;
        }
        public bool NodeExists(Node node)
        {
            return (node != null) ? this.NodeExists(node.name) : false;
        }
    }
}
