using System.Collections.Generic;

public class Aaagmnrs
{
    public string[] anagrams(string[] phrases)
    {
        Node root = new Node();
        root.Children = new List<Node>();

        List<string> results = new List<string>();

        foreach (string phrase in phrases)
        {
            if (root.Add(Normalize(phrase))) results.Add(phrase);
        }

        return results.ToArray();
    }

    private Queue<Node> Normalize(string phrase)
    {
        int[] r = new int[26];
        foreach (char c in phrase)
        {
            if (c == ' ') continue;

            char n = char.ToLowerInvariant(c);
            r[n - 'a']++;
        }

        Queue<Node> nodes = new Queue<Node>();

        for (char c = 'a'; c <= 'z'; c++)
        {
            if (r[c - 'a'] > 0)
            {
                Node node = new Node();
                node.Value = c;
                node.Count = r[c - 'a'];
                node.Children = new List<Node>();
                nodes.Enqueue(node);
            }
        }

        return nodes;
    }


    private struct Node
    {
        public char Value;

        public int Count;

        public List<Node> Children;

        public bool Add(Queue<Node> nodes)
        {
            // no nodes left to add
            if (nodes.Count == 0) return true;

            Node node = nodes.Dequeue();

            // search children for node
            foreach (Node child in Children)
            {
                if (child.Value == node.Value && child.Count == node.Count)
                {
                    // add recursively
                    if (nodes.Count == 0) return false;
                    return child.Add(nodes);
                }
            }

            // node not found, needs to be added
            Children.Add(node);
            if (nodes.Count == 0) return true;
            return node.Add(nodes);
        }
    }
}