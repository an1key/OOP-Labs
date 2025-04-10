using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем коллекцию из 100 случайных компьютеров
            List<Computer> computers1 = Computer.Generate100();

            // 1. Фильтрация по типу процессора
            
            /*
             var filteredByProcessor = (from computer in computers1
               where computer.ProcessorType == ProcessorType.Intel
               select computer).ToList();
             */
            var filteredByProcessor = computers1.Where(c => c.ProcessorType == ProcessorType.Intel).ToList();
            Console.WriteLine("Компьютеры с процессором Intel:");
            foreach (var computer in filteredByProcessor)
            {
                Console.WriteLine($"Процессор: {computer.ProcessorType}, Производитель: {computer.Manufacturer}");
            }

            // 2. Фильтрация по типу процессора и производителю
            /*
             var filteredByProcessorAndManufacturer = (from computer in computers1
               where computer.ProcessorType == ProcessorType.AMD &&
                     computer.Manufacturer == ManufacturerType.HP
               select computer).ToList();
             */
            var filteredByProcessorAndManufacturer = computers1
                .Where(c => c.ProcessorType == ProcessorType.AMD && c.Manufacturer == ManufacturerType.HP)
                .ToList();
            Console.WriteLine("\nКомпьютеры с процессором AMD и производителем HP:");
            foreach (var computer in filteredByProcessorAndManufacturer)
            {
                Console.WriteLine($"Процессор: {computer.ProcessorType}, Производитель: {computer.Manufacturer}");
            }

            // 3. Фильтрация по коллекции пользователей и объёму ОЗУ
            /*
             var filteredByUsersAndRAM = (from computer in computers1
               where computer.Users.Contains("User1") && computer.RAMSize > 16
               select computer).ToList();
             */
            var filteredByUsersAndRAM = computers1
                .Where(c => c.Users.Contains("User1") && c.RAMSize > 16)
                .ToList();
            Console.WriteLine("\nКомпьютеры с пользователем User1 и ОЗУ > 16 ГБ:");
            foreach (var computer in filteredByUsersAndRAM)
            {
                Console.WriteLine($"Пользователи: {string.Join(", ", computer.Users)}, ОЗУ: {computer.RAMSize} ГБ");
            }

            List<Computer> computers2 = Computer.Generate100();  
            
            // 4. Сортировка по типу процессора
            /*
             var sortedByProcessor = (from computer in computers2
               orderby computer.ProcessorType
               select computer).ToList();
             */
            var sortedByProcessor = computers2.OrderBy(c => c.ProcessorType).ToList();
            Console.WriteLine("\nКомпьютеры отсортированы по типу процессора:");
            foreach (var computer in sortedByProcessor)
            {
                Console.WriteLine($"Процессор: {computer.ProcessorType}");
            }

            // 5. Сортировка по типу процессора и производителю
            /*
             var sortedByProcessorAndManufacturer = (from computer in computers2
               orderby computer.ProcessorType, computer.Manufacturer
               select computer).ToList();
             */
            var sortedByProcessorAndManufacturer = computers2
                .OrderBy(c => c.ProcessorType)
                .ThenBy(c => c.Manufacturer)
                .ToList();
            Console.WriteLine("\nКомпьютеры отсортированы по типу процессора и производителю:");
            foreach (var computer in sortedByProcessorAndManufacturer)
            {
                Console.WriteLine($"Процессор: {computer.ProcessorType}, Производитель: {computer.Manufacturer}");
            }

            List<Computer> computers3 = Computer.Generate100();
            // 6. SELECT для получения нужных полей
            /*
             var selectedFields = (from computer in computers3
               select new
               {
                   ClockSpeed = computer.ClockSpeed,
                   RAMSize = computer.RAMSize,
                   InstalledSoftware = computer.InstalledSoftware
               }).ToList();
             */
            var selectedFields = computers3.Select(c => new
            {
                ClockSpeed = c.ClockSpeed,
                RAMSize = c.RAMSize,
                InstalledSoftware = c.InstalledSoftware
            }).ToList();
            Console.WriteLine("\nВыбранные поля:");
            foreach (var item in selectedFields)
            {
                Console.WriteLine($"Частота процессора: {item.ClockSpeed}, ОЗУ: {item.RAMSize} ГБ, ПО: {string.Join(", ", item.InstalledSoftware)}");
            }
            
            // 7. Внутреннее соединение
            // Создаем коллекцию производителей
            List<Manufacturer> manufacturers = new List<Manufacturer>
            {
                new Manufacturer("Dell", Country.USA, 150000),
                new Manufacturer("HP", Country.USA, 120000),
                new Manufacturer("Lenovo", Country.China, 70000),
                new Manufacturer("Apple", Country.USA, 140000),
                new Manufacturer("Microsoft", Country.USA, 180000)
            };

            // Внутреннее соединение по производителю
            /*
             var joinedResult = (from computer in computers3
               join manufacturer in manufacturers
               on computer.Manufacturer.ToString() equals manufacturer.Name
               select new
               {
                   ComputerName = computer.ProcessorType.ToString(),
                   ManufacturerName = manufacturer.Name,
                   Country = manufacturer.Country
               }).ToList();
             */
            var joinedResult = computers3.Join(manufacturers,
                computer => computer.Manufacturer.ToString(),
                manufacturer => manufacturer.Name,
                (computer, manufacturer) => new
                {
                    ComputerName = computer.ProcessorType.ToString(),
                    ManufacturerName = manufacturer.Name,
                    Country = manufacturer.Country
                });

            Console.WriteLine("\nВнутреннее соединение по производителю:");
            foreach (var item in joinedResult)
            {
                Console.WriteLine($"Компьютер: {item.ComputerName}, Производитель: {item.ManufacturerName}, Страна: {item.Country}");
            }

            string testString = "Hello русский world!";
            Console.WriteLine(testString.RemoveRussianLetters());
        }
    }
}