namespace Lab4_5;

class StudentWrapper
{
    private Student[] _students;

    public StudentWrapper(Student[] students)
    {
        _students = students;
    }

    // Индексатор для доступа к студентам
    public Student this[int index]
    {
        get
        {
            if (index < 0 || index >= _students.Length)
                throw new IndexOutOfRangeException("Индекс вне диапазона массива студентов.");
            return _students[index];
        }
        set
        {
            if (index < 0 || index >= _students.Length)
                throw new IndexOutOfRangeException("Индекс вне диапазона массива студентов.");
            _students[index] = value;
        }
    }

    public int Length => _students.Length;

    // Метод для удаления студента
    public void RemoveStudentAt(int index)
    {
        if (index < 0 || index >= _students.Length)
            throw new IndexOutOfRangeException("Индекс вне диапазона массива студентов.");

        for (int i = index; i < _students.Length - 1; i++)
        {
            _students[i] = _students[i + 1];
        }

        // Уменьшаем массив
        Array.Resize(ref _students, _students.Length - 1);
    }
}
