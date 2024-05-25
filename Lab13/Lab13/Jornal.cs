using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class Journal
    {
        public List<JournalEntry> entries = new List<JournalEntry>();

        public void AddEntry(string collectionName, string changeType, object changedItem)
        {
            entries.Add(new JournalEntry(collectionName, changeType, changedItem));
        }

        public void ShowEntries()
        {
            foreach (JournalEntry entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }

    }
}
