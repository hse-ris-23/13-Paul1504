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

bool running = true;
while (running)
{
    Console.WriteLine("\nМеню:");
    Console.WriteLine("1. Добавить элемент в коллекцию 1");
    Console.WriteLine("2. Добавить элемент в коллекцию 2");
    Console.WriteLine("3. Удалить элемент из коллекции 1");
    Console.WriteLine("4. Удалить элемент из коллекции 2");
    Console.WriteLine("5. Заменить элемент в коллекции 1");
    Console.WriteLine("6. Вывести журнал 1");
    Console.WriteLine("7. Вывести журнал 2");
    Console.WriteLine("0. Выход");

    Console.Write("Введите номер действия: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Введите тип транспортного средства (Truck, SUV, Car): ");
            string type = Console.ReadLine();
            switch (type)
            {
                case "Truck":
                    collection1.Add(new Truck());
                    break;
                case "SUV":
                    collection1.Add(new SUV());
                    break;
                case "Car":
                    collection1.Add(new Car());
                    break;
                default:
                    Console.WriteLine("Некорректный тип транспортного средства");
                    break;
            }
            break;
        case 2:
            Console.WriteLine("Введите тип транспортного средства (Truck, SUV, Car): ");
            type = Console.ReadLine();
            switch (type)
            {
                case "Truck":
                    collection2.Add(new Truck());
                    break;
                case "SUV":
                    collection2.Add(new SUV());
                    break;
                case "Car":
                    collection2.Add(new Car());
                    break;
                default:
                    Console.WriteLine("Некорректный тип транспортного средства");
                    break;
            }
            break;
        case 3:
            Console.WriteLine("Введите тип транспортного средства для удаления (Truck, SUV, Car): ");
            type = Console.ReadLine();
            switch (type)
            {
                case "Truck":
                    collection1.Remove(new Truck());
                    break;
                case "SUV":
                    collection1.Remove(new SUV());
                    break;
                case "Car":
                    collection1.Remove(new Car());
                    break;
                default:
                    Console.WriteLine("Некорректный тип транспортного средства");
                    break;
            }
            break;
        case 4:
            Console.WriteLine("Введите тип транспортного средства для удаления (Truck, SUV, Car): ");
            type = Console.ReadLine();
            switch (type)
            {
                case "Truck":
                    collection2.Remove(new Truck());
                    break;
                case "SUV":
                    collection2.Remove(new SUV());
                    break;
                case "Car":
                    collection2.Remove(new Car());
                    break;
                default:
                    Console.WriteLine("Некорректный тип транспортного средства");
                    break;
            }
            break;
        case 5:
            Console.WriteLine("Введите тип транспортного средства для замены (Truck, SUV, Car): ");
            string oldType = Console.ReadLine();
            Console.WriteLine("Введите новый тип транспортного средства (Truck, SUV, Car): ");
            string newType = Console.ReadLine();
            Vehicle newVehicle = null;
            switch (newType)
            {
                case "Truck":
                    newVehicle = new Truck();
                    break;
                case "SUV":
                    newVehicle = new SUV();
                    break;
                case "Car":
                    newVehicle = new Car();
                    break;
                default:
                    Console.WriteLine("Некорректный тип транспортного средства");
                    break;
            }
            switch (oldType)
            {
                case "Truck":
                    collection1[new Truck()] = newVehicle;
                    break;
                case "SUV":
                    collection1[new SUV()] = newVehicle;
                    break;
                case "Car":
                    collection1[new Car()] = newVehicle;
                    break;
                case "Vehicle":
                    collection1[new Vehicle()] = newVehicle;
                    break;
                default:
                    Console.WriteLine("Некорректный тип транспортного средства");
                    break;
            }
            break;
        case 6:
            Console.WriteLine("Журнал 1:");
            journal1.ShowEntries();
            break;
        case 7:
            Console.WriteLine("Журнал 2:");
            journal2.ShowEntries();
            break;
        case 0:
            running = false;
            break;
        default:
            Console.WriteLine("Некорректный выбор.");
            break;
            }
        }
    }
}
