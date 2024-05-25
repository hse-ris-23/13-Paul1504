using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLibrary1;

namespace Lab13
{
    public static class JournalExtensions
    {
        public static void HandleCollectionCountChanged(this Journal journal, object sender, CollectionHandlerEventArgs args)
        {
            journal.AddEntry("Collection1", args.ChangeType, args.ChangedItem);
        }

        public static void HandleCollectionReferenceChanged(this Journal journal, object sender, CollectionHandlerEventArgs args)
        {
            journal.AddEntry(sender is MyObservableCollection<Vehicle>  ? "Collection1" : "Collection2", args.ChangeType, args.ChangedItem);
        }
    }
}
