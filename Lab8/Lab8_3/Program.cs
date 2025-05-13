
namespace Lab8_3;

class Program
{
    static void Main(string[] args)
    {
        // Создаем исходный объект
        var originalComputer = new Computer
        {
            ProcessorType = ProcessorType.Intel,
            Manufacturer = ManufacturerType.Dell,
            OperatingSystem = OperatingSystemType.Windows,
            ClockSpeed = 3500,
            RAMSize = 16,
            InstalledSoftware = new List<string> { "Notepad", "Chrome" },
            Users = new List<string> { "User1", "User2" }
        };

        // Поверхностное клонирование
        var shallowCopy = (Computer)originalComputer.Clone();
        Console.WriteLine("Поверхностная копия:");
        Console.WriteLine($"InstalledSoftware: {string.Join(", ", shallowCopy.InstalledSoftware)}");

        // Глубокое клонирование
        var deepCopy = (Computer)originalComputer.Clone(false);
        Console.WriteLine("\nГлубокая копия:");
        Console.WriteLine($"InstalledSoftware: {string.Join(", ", deepCopy.InstalledSoftware)}");

        // Изменяем данные в оригинальном объекте
        originalComputer.InstalledSoftware.Add("New Software");
        originalComputer.Users.Add("User3");

        // Проверяем результаты
        Console.WriteLine("\nПосле изменения оригинала:");
        Console.WriteLine($"Original InstalledSoftware: {string.Join(", ", originalComputer.InstalledSoftware)}");
        Console.WriteLine($"Shallow Copy InstalledSoftware: {string.Join(", ", shallowCopy.InstalledSoftware)}");
        Console.WriteLine($"Deep Copy InstalledSoftware: {string.Join(", ", deepCopy.InstalledSoftware)}");

        Console.ReadKey();
    }
}