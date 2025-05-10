using System;

namespace Lab7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем компьютер
            var computer = new Computer();

            // Подписываемся на события
            computer.UserAdded += OnUserAdded;
            computer.ProcessorReplaced += OnProcessorReplaced;
            computer.SoftwareInstalled += OnSoftwareInstalled;
            computer.RAMReplaced += OnRAMReplaced;

            // Добавляем нового пользователя
            computer.AddUser("Alice");

            // Заменяем процессор
            computer.ReplaceProcessor(ProcessorType.AMD);

            // Устанавливаем новое ПО
            computer.InstallSoftware("Notepad++");

            // Заменяем ОЗУ
            computer.ReplaceRAM(16);

            Console.ReadLine();
        }

        // Обработчик события добавления пользователя
        static void OnUserAdded(object sender, UserEventArgs e)
        {
            Console.WriteLine($"Новый пользователь добавлен: {e.UserName}");
        }

        // Обработчик события замены процессора
        static void OnProcessorReplaced(object sender, ProcessorChangedEventArgs e)
        {
            Console.WriteLine($"Процессор заменен: {e.OldProcessor} -> {e.NewProcessor}");
        }

        // Обработчик события установки ПО
        static void OnSoftwareInstalled(object sender, SoftwareEventArgs e)
        {
            Console.WriteLine($"Установлено новое ПО: {e.SoftwareName}");
        }

        // Обработчик события замены ОЗУ
        static void OnRAMReplaced(object sender, RAMChangedEventArgs e)
        {
            Console.WriteLine($"ОЗУ заменена: {e.OldRAMSize} ГБ -> {e.NewRAMSize} ГБ");
        }
    }
}