// See https://aka.ms/new-console-template for more information

namespace Lab8_3;
public class Computer : ICloneable
    {
        public ProcessorType ProcessorType { get; set; }
        public ManufacturerType Manufacturer { get; set; }
        public OperatingSystemType OperatingSystem { get; set; }
        public int ClockSpeed { get; set; }
        public int RAMSize { get; set; }
        public List<string> InstalledSoftware { get; set; }
        public List<string> Users { get; set; }

        // Конструктор по умолчанию
        public Computer()
        {
            ProcessorType = ProcessorType.Intel;
            Manufacturer = ManufacturerType.Dell;
            OperatingSystem = OperatingSystemType.Windows;
            ClockSpeed = 3000;
            RAMSize = 8;
            InstalledSoftware = new List<string>();
            Users = new List<string>();
        }

        // Конструктор с параметрами
        public Computer(ProcessorType processorType, ManufacturerType manufacturer, OperatingSystemType operatingSystem, int clockSpeed, int ramSize, List<string> installedSoftware, List<string> users)
        {
            ProcessorType = processorType;
            Manufacturer = manufacturer;
            OperatingSystem = operatingSystem;
            ClockSpeed = clockSpeed;
            RAMSize = ramSize;
            InstalledSoftware = installedSoftware;
            Users = users;
        }

        // Реализация метода Clone
        public object? Clone(bool shallow)
        {
            return shallow ? Clone() : DeepCopy();
        }
        public object Clone()
        {
            // Поверхностное клонирование
            return MemberwiseClone();
        }
        
        // Метод для глубокого клонирования
        public object? DeepCopy()
        {
            // Создаем новый объект и копируем все свойства
            var clonedComputer = (Computer)MemberwiseClone();
            clonedComputer.InstalledSoftware = new List<string>(InstalledSoftware);
            clonedComputer.Users = new List<string>(Users);
            return clonedComputer;
        }
    }

    // Перечисления
    public enum ProcessorType
    {
        Intel,
        AMD,
        ARM
    }

    public enum ManufacturerType
    {
        Dell,
        HP,
        Lenovo,
        Apple,
        Microsoft
    }

    public enum OperatingSystemType
    {
        Windows,
        macOS,
        Linux,
        ChromeOS
    }