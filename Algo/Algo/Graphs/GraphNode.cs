using System.Collections.Generic;

namespace Algo.Graphs
{
    public class GraphNode
    {
        public GraphNode(string v)
        {
            Value = v;
            Paths = new List<GraphNode>();
        }

        public string Value { get; private set; }

        public List<GraphNode> Paths { get; private set; }
    }
}
