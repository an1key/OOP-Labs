using System;
using System.IO;
using System.Security.Cryptography;

namespace Lab5_3
{
    class Program
    {
        static void Main()
        {
            string targetFilePath = "/Users/an1key/docy/study/test/Paste.app";

            string targetMd5Hash = GetMd5Hash(targetFilePath); // Искомая MD5-сумма

            if (targetMd5Hash == null)
            {
                Console.WriteLine("Не удалось получить MD5-хэш целевого файла.");
                return;
            }

            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    try
                    {
                        foreach (string dir in Directory.GetDirectories("/Users/an1key/docy/study", "*.app", SearchOption.AllDirectories))
                        {
                            string hash = GetMd5Hash(dir);
                            if (hash == targetMd5Hash)
                            {
                                Directory.Delete(dir, true);
                                Console.WriteLine($"Пакет {dir} удалён.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при доступе к диску {drive.Name}: {ex.Message}");
                    }
                }
            }
        }

        static string GetMd5Hash(string filePath)
        {
            try
            {
                // Проверяем, является ли путь директорией (пакетом приложения)
                if (Directory.Exists(filePath))
                {
                    Console.WriteLine($"{filePath} — это пакет приложения. Используем его содержимое.");
                    string mainExecutablePath = Path.Combine(filePath, "Contents/MacOS/Paste");

                    if (File.Exists(mainExecutablePath))
                    {
                        filePath = mainExecutablePath;
                    }
                    else
                    {
                        Console.WriteLine("Основной исполняемый файл в пакете не найден.");
                        return null;
                    }
                }

                // Считаем MD5
                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Нет доступа к файлу или директории: {filePath}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return null;
            }
        }

    }
}
