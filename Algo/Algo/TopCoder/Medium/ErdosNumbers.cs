using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.TopCoder.Medium
{
    public class ErdosNumber
    {
        public string[] calculateNumbers(string[] publications)
        {
            Dictionary<string, HashSet<string>> connections = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);
            Dictionary<string, int> erdosNumbers = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (string publication in publications)
            {
                string[] authors = publication.Split(' ');

                for (int i = 0; i < authors.Length; i++)
                {
                    if (!connections.ContainsKey(authors[i]))
                    {
                        connections.Add(authors[i], new HashSet<string>(StringComparer.OrdinalIgnoreCase));
                        erdosNumbers.Add(authors[i], 0);
                    }

                    for (int j = i + 1; j < authors.Length; j++)
                    {
                        if (!connections.ContainsKey(authors[j]))
                        {
                            connections.Add(authors[j], new HashSet<string>(StringComparer.OrdinalIgnoreCase));
                            erdosNumbers.Add(authors[j], 0);
                        }

                        connections[authors[i]].Add(authors[j]);
                        connections[authors[j]].Add(authors[i]);
                    }
                }
            }


            // BFS from ERDOS
            Queue<string> toVisit = new Queue<string>();
            toVisit.Enqueue("ERDOS");
            while (toVisit.Count > 0)
            {
                string author = toVisit.Dequeue();

                foreach (string connection in connections[author])
                {
                    if (string.Equals("ERDOS", connection))
                    {
                        continue;
                    }

                    if (erdosNumbers[connection] == 0)
                    {
                        erdosNumbers[connection] = erdosNumbers[author] + 1;
                        toVisit.Enqueue(connection);
                    }
                }
            }

            List<string> result = new List<string>();
            foreach (KeyValuePair<string, int> number in erdosNumbers)
            {
                if (number.Key != "ERDOS" && number.Value == 0)
                {
                    result.Add(number.Key);
                }
                else
                {
                    result.Add(number.Key + " " + number.Value);
                }
            }

            return result.OrderBy(r => r).ToArray();
        }
    }
}
