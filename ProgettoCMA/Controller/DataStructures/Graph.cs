using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller.DataStructures
{
    public class Graph : NodeCollection
    {
        public Graph() : base()
        {

        }

        #region AddAdjacency
        public new Graph AddAjacency(Node startNode, Node adjacencyNode, Object adjacencyData)
        {
            base.AddAjacency(startNode, adjacencyNode, adjacencyData);
            return this;
        }
        public Graph AddAjacency(Node startNode, Node adjacencyNode)
        {
            this.AddAjacency(startNode, adjacencyNode, null);
            return this;
        }

        public Graph AddAjacency(Node startNode, String adjacencyNodeName, Object adjacencyData)
        {
            Node adjacencyNode = this.GetNode(adjacencyNodeName);
            this.AddAjacency(startNode, adjacencyNode, adjacencyData);
            return this;
        }
        public Graph AddAjacency(Node startNode, String adjacencyNodeName)
        {
            this.AddAjacency(startNode, adjacencyNodeName, null);
            return this;
        }

        public Graph AddAjacency(String startNodeName, Node adjacencyNode, Object adjacencyData)
        {
            Node startNode = this.GetNode(startNodeName);
            this.AddAjacency(startNode, adjacencyNode, adjacencyData);
            return this;
        }
        public Graph AddAjacency(String startNodeName, Node adjacencyNode)
        {
            this.AddAjacency(startNodeName, adjacencyNode, null);
            return this;
        }

        public Graph AddAjacency(String startNodeName, String adjacencyNodeName, Object adjacencyData)
        {
            Node startNode = this.GetNode(startNodeName);
            Node adjacencyNode = this.GetNode(adjacencyNodeName);
            this.AddAjacency(startNode, adjacencyNode, adjacencyData);
            return this;
        }
        public Graph AddAjacency(String startNodeName, String adjacencyNodeName)
        {
            this.AddAjacency(startNodeName, adjacencyNodeName, null);
            return this;
        }
        #endregion
    }
}
