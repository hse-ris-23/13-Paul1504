using Lab13;
using VehicleLibrary1;

public class Program
{
    public static void Main(string[] args)
    {
        MyObservableCollection<Vehicle> collection1 = new MyObservableCollection<Vehicle>();
        MyObservableCollection<Vehicle> collection2 = new MyObservableCollection<Vehicle>();

        Journal journal1 = new Journal();
        Journal journal2 = new Journal();

        collection1.CollectionCountChanged += journal1.HandleCollectionCountChanged;
        collection1.CollectionReferenceChanged += journal1.HandleCollectionReferenceChanged;
        collection2.CollectionReferenceChanged += journal2.HandleCollectionReferenceChanged;

        collection1.Add(new Truck());
        collection1.Add(new SUV());
        collection2.Add(new Car());
        collection2.Add(new Vehicle());

        collection1.Remove(new Truck());
        collection2.Remove(new Car());

        collection1[new SUV()] = new Vehicle();

        Console.WriteLine("Журнал 1:");
        journal1.ShowEntries();

        Console.WriteLine("\nЖурнал 2:");
        journal2.ShowEntries();

        Console.ReadKey();
    }
}