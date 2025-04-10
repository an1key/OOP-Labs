using System;
using System.Collections.Generic;

namespace Lab6
{
    public class Computer : IComputer, IOverclock
    {
        public ProcessorType ProcessorType { get; set; }
        public ManufacturerType Manufacturer { get; set; }
        public OperatingSystemType OperatingSystem { get; set; }
        public int ClockSpeed { get; set; }
        public int RAMSize { get; set; }
        public List<string> InstalledSoftware { get; set; }
        public List<string> Users { get; set; }

        private bool _overclocked = false;

        // Конструктор по умолчанию
        public Computer()
        {
            ProcessorType = ProcessorType.Intel;
            Manufacturer = ManufacturerType.Chuwi;
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

        // Метод разгона компьютера
        public void OverclockTheComputer()
        {
            if (_overclocked)
            {
                throw new InvalidOperationException("Компьютер уже разогнан.");
            }

            switch (ProcessorType)
            {
                case ProcessorType.Intel:
                    ClockSpeed += 200;
                    break;
                case ProcessorType.AMD:
                    ClockSpeed += 300;
                    break;
                case ProcessorType.ARM:
                    ClockSpeed += 100;
                    break;
                default:
                    throw new NotSupportedException("Тип процессора не поддерживается для разгона.");
            }

            _overclocked = true;
        }

        // Статический метод для генерации случайного компьютера
        public static Computer Generate()
        {
            Random random = new Random();
            return new Computer(
                (ProcessorType)random.Next(0, 3),
                (ManufacturerType)random.Next(0, 5),
                (OperatingSystemType)random.Next(0, 4),
                random.Next(2000, 5000),
                random.Next(4, 64),
                new List<string> { "Notepad", "Chrome" },
                new List<string> { "User1", "User2" }
            );
        }

        // Статический метод для генерации 100 случайных компьютеров
        public static List<Computer> Generate100()
        {
            List<Computer> computers = new List<Computer>();
            for (int i = 0; i < 100; i++)
            {
                computers.Add(Generate());
            }
            return computers;
        }
    }
}