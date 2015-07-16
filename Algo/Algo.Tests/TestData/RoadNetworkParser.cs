using System;
using System.Collections.Generic;

namespace Algo.Tests.TestData
{
    public class RoadNetworkParser
    {
        public RoadNetworkParser(string input)
        {
            Vertices = new HashSet<int>();
            Edges = new Dictionary<int, Dictionary<int, double>>();
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int numberOfNodes = int.Parse(lines[0]);
            for (int i = 0; i < numberOfNodes; i++)
            {
                string[] values = lines[i + 1].Split(' ');
                int id = int.Parse(values[0]);
                Vertices.Add(id);
                Edges[id] = new Dictionary<int, double>();
            }

            Console.WriteLine("Found '{0}' vertices.", numberOfNodes);

            int numberOfEdges = int.Parse(lines[numberOfNodes + 1]);
            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] edge = lines[i * 2 + numberOfNodes + 2].Split(' ');
                int from = int.Parse(edge[0]);
                int to = int.Parse(edge[1]);

                double travelTime = double.Parse(lines[i * 2 + numberOfNodes + 3].Split(' ')[0]);
                Edges[to][from] = travelTime;
                Edges[from][to] = travelTime;
            }

            Console.WriteLine("Found '{0}' edges.", numberOfEdges);
        }

        public HashSet<int> Vertices { get; private set; }


        public Dictionary<int, Dictionary<int, double>> Edges { get; private set; }
    }
}
