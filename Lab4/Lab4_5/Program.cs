namespace Lab4_5;

class Program
{
    static void Main(string[] args)
    {
        // Генерируем массив студентов
        Student[] studentArray = new Student[5];
        for (int i = 0; i < studentArray.Length; i++)
        {
            studentArray[i] = Student.GenerateStudent();
        }

        // Создаём обёртку
        StudentWrapper studentWrapper = new StudentWrapper(studentArray);

        Console.WriteLine("Список студентов:");
        for (int i = 0; i < studentWrapper.Length; i++)
        {
            Console.WriteLine($"{i}: {studentWrapper[i].GetStudentInfo()}");
        }

        Console.WriteLine("\nПроверяем студентов на отчисление:");
        for (int i = 0; i < studentWrapper.Length; i++)
        {
            bool decision = studentWrapper[i].GetDecision();
            Console.WriteLine($"{studentWrapper[i].GetStudentInfo()} - {(decision ? "Отчислен" : "Не отчислен")}");
        }

        // Удаляем студента, если он отчислен
        for (int i = 0; i < studentWrapper.Length; i++)
        {
            if (studentWrapper[i].GetDecision())
            {
                Console.WriteLine($"Удаляем студента: {studentWrapper[i].GetStudentInfo()}");
                studentWrapper.RemoveStudentAt(i);
                i--; // После удаления сдвигаем индекс обратно
            }
        }

        Console.WriteLine("\nОставшиеся студенты:");
        for (int i = 0; i < studentWrapper.Length; i++)
        {
            Console.WriteLine($"{studentWrapper[i].GetStudentInfo()}");
        }
    }
}
