using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Graphs
{
    public class MergeContacts
    {
        public List<List<int>> Merge(string[] contacts)
        {
            Dictionary<string, Contact> names = new Dictionary<string, Contact>();
            Dictionary<string, Contact> emails = new Dictionary<string, Contact>();
            Dictionary<string, Contact> phones = new Dictionary<string, Contact>();

            int id = 0;
            foreach (Contact c in contacts.Select(details => new Contact(details, id++)))
            {
                if (names.ContainsKey(c.Name))
                {
                    names[c.Name].Aliases.Add(c);
                }
                else
                {
                    names[c.Name] = c;
                }

                if (emails.ContainsKey(c.Email))
                {
                    emails[c.Email].Aliases.Add(c);
                }
                else
                {
                    emails[c.Email] = c;
                }

                if (phones.ContainsKey(c.Phone))
                {
                    phones[c.Phone].Aliases.Add(c);
                }
                else
                {
                    phones[c.Phone] = c;
                }
            }

            HashSet<Contact> visited = new HashSet<Contact>();
            List<List<int>> merged = new List<List<int>>();
            foreach (Contact c in emails.Values.Union(names.Values).Union(phones.Values).Where(contact => visited.Add(contact)))
            {
                merged.Add(DFS(c, visited));
            }

            return merged;
        }

        private List<int> DFS(Contact c, HashSet<Contact> visited)
        {
            List<int> mergedContact = new List<int>();
            Queue<Contact> toVisit = new Queue<Contact>();
            toVisit.Enqueue(c);
            while (toVisit.Count > 0)
            {
                Contact current = toVisit.Dequeue();
                mergedContact.Add(current.Id);
                foreach (Contact alias in current.Aliases.Where(a => visited.Add(a)))
                {
                    toVisit.Enqueue(alias);
                }
            }

            return mergedContact;
        }
    }

    public class Contact
    {
        public Contact(string details, int id)
        {
            string[] info = details.Split(' ');
            Name = info[0];
            Email = info[1];
            Phone = info[2];
            Aliases = new HashSet<Contact>();
            Id = id;
        }

        public readonly string Name;
        public readonly string Email;
        public readonly string Phone;
        public readonly int Id;

        public readonly HashSet<Contact> Aliases;
    }
}
