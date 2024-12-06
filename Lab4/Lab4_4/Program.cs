namespace Lab4_4;


class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            { "hello", "привет" },
            { "world", "мир" },
            { "student", "студент" },
            { "university", "университет" },
            { "teacher", "учитель" }
        };

        foreach (var entry in dictionary)
        {
            Console.WriteLine($"{entry.Key} - {entry.Value}");
        }
    }
}