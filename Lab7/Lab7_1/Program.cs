// See https://aka.ms/new-console-template for more information

using System;

namespace Lab7_1
{
    // Объявление делегата
    public delegate double MyDel(int[] a);

    class Program
    {
        static void Main(string[] args)
        {
            // Создание анонимного метода для вычисления среднего значения массива
            MyDel calculateAverage = delegate (int[] array)
            {
                if (array == null || array.Length == 0)
                    throw new ArgumentException("Массив не может быть пустым или null.");

                double sum = 0;
                foreach (var num in array)
                {
                    sum += num;
                }
                return sum / array.Length;
            };

            // Тестирование делегата
            int[] numbers = { 1, 2, 3, 4, 5 };
            double result = calculateAverage(numbers);
            Console.WriteLine($"Среднее значение массива: {result}");
        }
    }
}