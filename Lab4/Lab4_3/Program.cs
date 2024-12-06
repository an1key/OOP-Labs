namespace Lab4_3;

class Program
{
    static void Main(string[] args)
    {
        Queue<Student> students = new Queue<Student>();

        for (int i = 0; i < 5; i++)
            students.Enqueue(Student.GenerateStudent());

        while (students.Count > 0)
        {
            var student = students.Dequeue();
            Console.WriteLine($"{student.GetStudentInfo()}\n- {(student.GetDecision() ? "Отчислен" : "Не отчислен")}");
        }
    }
}
