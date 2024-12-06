namespace Lab4_2;

using System;

class Program
{
    static void Main(string[] args)
    {
        string[] lastNames = { "Ильичев", "Васильев", "Зубов", "Зудилин", "Гардер", "Баканова" };

        BubbleSort(lastNames);

        Console.WriteLine("Отсортированный массив:");
        foreach (var name in lastNames)
            Console.WriteLine(name);
    }

    static void BubbleSort(string[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (string.Compare(array[j], array[j + 1]) > 0)
                {
                    string temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}
