namespace Lab5_2;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<string> docs = new List<string>();
        int maxResults = 1000000; // Максимальное количество результатов для предотвращения переполнения

        try
        {
            // Обход всех дисков
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (!drive.IsReady) continue;

                Console.WriteLine($"Обрабатываю диск: {drive.Name}");
                try
                {
                    ProcessDirectory("/", docs, maxResults);

                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Нет доступа к диску {drive.Name}");
                }
            }

            // Сохранение списка в файл
            string outputFile = "docs_list.txt";
            File.WriteAllLines(outputFile, docs);
            Console.WriteLine($"Список документов сохранён в файл {outputFile}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    static void ProcessDirectory(string directory, List<string> docs, int maxResults)
    {
        if (docs.Count >= maxResults)
        {
            Console.WriteLine("Достигнут лимит количества результатов.");
            return;
        }

        try
        {
            // Добавление файлов с нужными расширениями
            foreach (var file in Directory.GetFiles(directory))
            {
                if (file.ToLower().EndsWith(".doc") || file.ToLower().EndsWith(".docx") || file.ToLower().EndsWith(".pdf"))
                {
                    docs.Add(file);
                    if (docs.Count >= maxResults) return;
                }
            }

            // Рекурсивный обход директорий
            foreach (var subDir in Directory.GetDirectories(directory))
            {
                ProcessDirectory(subDir, docs, maxResults);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Нет доступа к папке {directory}.");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine($"Слишком длинный путь: {directory}");
        }
        catch (System.IO.IOException ex)
        {
            if (ex.Message.Contains("Result too large"))
            {
                Console.WriteLine("Слишком большой результат. Идем дальше");
            }
        }
        
    }
}


