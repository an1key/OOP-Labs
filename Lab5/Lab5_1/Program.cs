namespace Lab5_1;

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        string groupName = "GroupName"; // Укажите название группы
        string fileName = $"{groupName}.txt";
        string backupFileName = $"{groupName}_backup.txt";

        // Список группы
        string[] students = new string[]
        {
            "Баканова Анастасия Дмитриевна",
            "Васильев Андрей Вадимович",
            "Гардер Александр Денисович",
            "Зубов Савелий Павлович",
            "Зудилин Антон Вячеславович",
            "Ильичев Андрей Сергеевич",
            "Кайгородов Денис Вадимович",
            "Калмышева Анжелика Алексеевна",
            "Каргина Анастасия Ивановна",
            "Карпова Анфиса Евгеньевна",
            "Клишева Александра Владимировна",
            "Колмогорова Виктория Григорьевна",
            "Митрофанов Тимофей Николаевич",
            "Наумчук Арина Семеновна",
            "Овсиенко Роман Русланович",
            "Прокофьев Максим Вячеславович",
            "Ремеслова Вероника Александровна",
            "Стерженченко Илья Русланович",
            "Ходыкин Петр Артемович",
            "Егоров Никита Андреевич"
        };

        try
        {
            // 1. Создание текстового файла
            File.WriteAllLines(fileName, students);
            Console.WriteLine($"Файл {fileName} создан и заполнен.");
            Thread.Sleep(1000); 
            // 2. Создание резервной копии
            File.Copy(fileName, backupFileName, overwrite: true);
            Console.WriteLine($"Резервная копия {backupFileName} создана.");
            Thread.Sleep(1000);
            // 3. Удаление оригинального файла
            File.Delete(fileName);
            Console.WriteLine($"Файл {fileName} удалён.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
