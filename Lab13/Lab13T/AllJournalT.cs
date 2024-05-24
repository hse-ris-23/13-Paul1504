using Lab13;
using VehicleLibrary1;
namespace Lab13T
{
    [TestClass]
    public class JournalTests
    {

        private Journal journal;
        private MyObservableCollection<Vehicle> collection1;
        private MyObservableCollection<Vehicle> collection2;

        [TestInitialize]
        public void Initialize()
        {
            journal = new Journal();
            collection1 = new MyObservableCollection<Vehicle>();
            collection2 = new MyObservableCollection<Vehicle>();
        }

        [TestMethod]
        public void AddEntry()
        {
            Journal journal = new Journal();
            string collectionName = "Vehicles";
            string changeType = "Added";
            Vehicle vehicle = new Vehicle();

            journal.AddEntry(collectionName, changeType, vehicle);

            Assert.IsTrue(journal.entries.Count == 1);
        }

        [TestMethod]
        public void ShowEntries()
        {
            Journal journal = new Journal();
            string collectionName = "Vehicles";
            string changeType = "Added";
            Vehicle vehicle = new Vehicle();
            journal.AddEntry(collectionName, changeType, vehicle);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                journal.ShowEntries();
                string expected = $"Коллекция: {collectionName}, Тип изменения: {changeType}, Измененный элемент: {vehicle}";
                string actual = sw.ToString().Trim();

                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void Constructor()
        {
            string collectionName = "Vehicles";
            string changeType = "Added";
            Vehicle vehicle = new Vehicle();

            JournalEntry entry = new JournalEntry(collectionName, changeType, vehicle);

            Assert.AreEqual(collectionName, entry.CollectionName);
            Assert.AreEqual(changeType, entry.ChangeType);
            Assert.AreEqual(vehicle, entry.ChangedItem);
        }

        [TestMethod]
        public void MoveToString()
        {
            string collectionName = "Vehicles";
            string changeType = "Added";
            Vehicle vehicle = new Vehicle();
            JournalEntry entry = new JournalEntry(collectionName, changeType, vehicle);

            string result = entry.ToString();

            string expected = $"Коллекция: {collectionName}, Тип изменения: {changeType}, Измененный элемент: {vehicle}";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void HandleCollectionReferenceChanged()
        {
            collection1.CollectionCountChanged += journal.HandleCollectionReferenceChanged;
            Vehicle vehicle = new Vehicle();

            collection1.Add(vehicle);

            Assert.AreEqual(1, journal.entries.Count);
            Assert.AreEqual("Collection1", journal.entries[0].CollectionName);
        }

        [TestMethod]
        public void HandleCollectionCountChanged()
        {
            collection1.CollectionCountChanged += journal.HandleCollectionCountChanged;
            Vehicle car = new Vehicle();
            collection1.Add(car);

            Assert.AreEqual(1, journal.entries.Count);
            Assert.AreEqual(car, journal.entries[0].ChangedItem);
        }
    }
}