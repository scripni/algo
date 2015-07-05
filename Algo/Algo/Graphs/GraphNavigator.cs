using System.Collections.Generic;

namespace Algo.Graphs
{
    public class GraphNavigator
    {
        public IEnumerable<GraphNode> TopologicalSort(GraphNode[] graph)
        {
            HashSet<GraphNode> visited = new HashSet<GraphNode>();
            Stack<GraphNode> sorted = new Stack<GraphNode>();
            foreach (GraphNode node in graph)
            {
                TopologicalSort(node, visited, sorted);
            }

            return sorted;
        }

        private void TopologicalSort(GraphNode node, HashSet<GraphNode> visited, Stack<GraphNode> sorted)
        {
            if (visited.Contains(node)) return;

            visited.Add(node);
            foreach (GraphNode n in node.Paths)
            {
                TopologicalSort(n, visited, sorted);
            }

            sorted.Push(node);
        }
    }
}
