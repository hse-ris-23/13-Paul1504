using Lab13;
using VehicleLibrary1;
namespace Lab13T
{
    [TestClass]
        public class MyObservableCollectionTests
        {
            private MyObservableCollection<Vehicle> collection;
            private List<JournalEntry> journalEntries;

            [TestInitialize]
            public void Initialize()
            {
                collection = new MyObservableCollection<Vehicle>();
                journalEntries = new List<JournalEntry>();

                collection.CollectionCountChanged += OnCollectionCountChanged;
                collection.CollectionReferenceChanged += OnCollectionReferenceChanged;
            }

            [TestMethod]
            public void Add()
            {
                Vehicle car = new Car();

                collection.Add(car);

                Assert.IsTrue(collection.Contains(car));
                Assert.AreEqual(1, collection.Count);
            }

            [TestMethod]
            public void Remove()
            {
                Vehicle car = new Car();
                collection.Add(car);

                collection.Remove(car);

                Assert.IsFalse(collection.Contains(car));
                Assert.AreEqual(0, collection.Count);
            }

            [TestMethod]
            public void Indexer1()
            {
                Vehicle car1 = new Car();
                collection.Add(car1);

                Vehicle car2 = collection[car1];

                Assert.AreEqual(car1, car2);
            }

            [TestMethod]
            public void Indexer2()
            {
                Vehicle car1 = new Car();
                collection.Add(car1);
                Vehicle car2 = new Car();

                collection[car1] = car2;

                Assert.AreEqual(car2, collection[car2]);
            }

            [TestMethod]
            public void CollectionCountChanged()
            {
                Vehicle car = new Car();

                collection.Add(car);

                Assert.AreEqual(1, journalEntries.Count);
                Assert.AreEqual("Добавлен элемент", journalEntries[0].ChangeType);
                Assert.AreEqual(car, journalEntries[0].ChangedItem);
            }

            [TestMethod]
            public void CollectionCountChanged2()
            {
                Vehicle car = new Car();
                collection.Add(car);

                collection.Remove(car);

                Assert.AreEqual(2, journalEntries.Count);
                Assert.AreEqual("Удален элемент", journalEntries[1].ChangeType);
                Assert.AreEqual(car, journalEntries[1].ChangedItem);
            }

            [TestMethod]
            public void CollectionReferenceChanged()
            {
                Vehicle car1 = new Car();
                collection.Add(car1);
                Vehicle car2 = new Car();

                collection[car1] = car2;

                Assert.AreEqual(2, journalEntries.Count);
                Assert.AreEqual("Изменен элемент", journalEntries[1].ChangeType);
                Assert.AreEqual(car2, journalEntries[1].ChangedItem);
            }

            private void OnCollectionCountChanged(object sender, CollectionHandlerEventArgs args)
            {
                journalEntries.Add(new JournalEntry("MyObservableCollection", args.ChangeType, args.ChangedItem));
            }

            private void OnCollectionReferenceChanged(object sender, CollectionHandlerEventArgs args)
            {
                journalEntries.Add(new JournalEntry("MyObservableCollection", args.ChangeType, args.ChangedItem));
            }
        }
}