using System;

namespace Lab4_1;

class Program
{
    static void Main(string[] args)
    {
        string[] lastNames = { "Баканова", "Васильев", "Гардер", "Зубов", "Зудилин", "Ильичев" };
        string[] firstNames = { "Анастасия", "Андрей", "Александр", "Савелий", "Антон", "Андрей" };

        string[] combinedArray = new string[lastNames.Length + firstNames.Length];

        for (int i = 0, j = 0; i < combinedArray.Length; i++)
        {
            if (i % 2 == 0)
                combinedArray[i] = lastNames[j];
            else
                combinedArray[i] = firstNames[j++];
        }

        Console.WriteLine("Объединённый массив:");
        foreach (var entry in combinedArray)
            Console.WriteLine(entry);
    }
}
