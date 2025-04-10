namespace Lab4_5;

public class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public Dictionary<string, int> Grades { get; set; }

    private static readonly string[] LastNames = { "Баканова", "Васильев", "Гардер", "Зубов", "Зудилин", "Ильичев" };
    private static readonly string[] FirstNames = { "Анастасия", "Андрей", "Александр", "Савелий", "Антон", "Андрей" };
    private static readonly string[] MiddleNames = { "Дмитриевна", "Вадимович", "Денисович", "Павлович", "Вячеславович", "Сергеевич" };
    private static readonly string[] Subjects = { "Программирование", "Философия", "Сети", "Методы оптимизации" };
    private static readonly Dictionary<string, int> SubjectWeights = new()
    {
        { "Программирование", 4 },
        { "Философия", 1 },
        { "Сети", 2 },
        { "Методы оптимизации", 2 }
    };
    private const int ExpulsionThreshold = 35; // Порог для отчисления
    public static Student GenerateStudent()
    {
        var random = new Random();
        var grades = new Dictionary<string, int>();
        foreach (var subject in Subjects)
            grades[subject] = random.Next(2, 6);

        return new Student
        {
            LastName = LastNames[random.Next(LastNames.Length)],
            FirstName = FirstNames[random.Next(FirstNames.Length)],
            MiddleName = MiddleNames[random.Next(MiddleNames.Length)],
            Grades = grades
        };
    }

    public string GetStudentInfo()
    {
        return $"Студент {LastName} {FirstName} {MiddleName}\n" +
               $"Оценки:{Environment.NewLine}" +
               string.Join(Environment.NewLine, Grades.Select(pair => $"{pair.Key}: {pair.Value}"));
    }

    public bool GetDecision()
    {
        int totalRisk = 0;

        foreach (var grade in Grades)
        {

            if (SubjectWeights.TryGetValue(grade.Key, out int weight))
            {
                totalRisk += grade.Value * weight;                
            }
            else
            {
                throw new IndexOutOfRangeException("Такого ключа нет в словаре");
            }
            
        }

        return totalRisk < ExpulsionThreshold;
    }
}


//СЛожность алгоритма поисква в листе и словаре O(n)
//МОжно ли у класса readonly поменять поле? Нельзя, только в конструкторе
//Какой интерфейс должен реализовывать класс, чтобы работал форыч System.Collections.IEnumerable