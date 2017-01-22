using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller.DataStructures
{
    public class NodeAdjacency
    {
        public Node node { get; private set; }

        public Object info { get; private set; }
        public Type infoType { get; private set; }
        
        public NodeAdjacency(Node arrivalNode, Object info)
        {
            this.node = arrivalNode;
            this.info = info;
            this.infoType = info?.GetType();
        }
    }
}
