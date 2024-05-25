using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class JournalEntry
    {
        public string CollectionName { get; }
        public string ChangeType { get; }
        public object ChangedItem { get; }

        public JournalEntry(string collectionName, string changeType, object changedItem)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ChangedItem = changedItem;
        }

        public override string ToString()
        {
            return $"Коллекция: {CollectionName}, Тип изменения: {ChangeType}, Измененный элемент: {ChangedItem}";
        }
    }
}
