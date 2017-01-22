using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller.NodeStruct
{
    public class Node
    {
        public String name { get; private set; }
        public List<NodeAdjacency> adjacences { get; private set; }

        public Object info { get; private set; }
        public Type infoType { get; private set; }

        public Node(String name, Object info)
        {
            this.name = name;
            this.adjacences = new List<NodeAdjacency>();
            this.info = info;
            this.infoType = info?.GetType();
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
    }
}
