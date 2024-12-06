namespace Lab4Tests;
using Lab4_3;
using NUnit.Framework;

using System.Collections.Generic;

[TestFixture]
public class StudentTests
{
    [Test]
    public void GetDecision_ShouldExpel_WhenAllGradesAreLow()
    {
        // Arrange: низкие оценки по всем предметам
        var student = new Student
        {
            Grades = new Dictionary<string, int>
            {
                { "Программирование", 2 },
                { "Философия", 2 },
                { "Сети", 2 },
                { "Методы оптимизации", 2 }
            }
        };

        // Act
        bool decision = student.GetDecision();

        // Assert: студент должен быть отчислен
        Assert.IsTrue(decision, "Студент должен быть отчислен из-за низких оценок");
    }

    [Test]
    public void GetDecision_ShouldNotExpel_WhenGradesAreHigh()
    {
        // Arrange: высокие оценки по всем предметам
        var student = new Student
        {
            Grades = new Dictionary<string, int>
            {
                { "Программирование", 5 },
                { "Философия", 4 },
                { "Сети", 5 },
                { "Методы оптимизации", 5 }
            }
        };

        // Act
        bool decision = student.GetDecision();

        // Assert: студент не должен быть отчислен
        Assert.IsFalse(decision, "Студент не должен быть отчислен при высоких оценках");
    }

    [Test]
    public void GetDecision_ShouldExpel_WhenProgrammingGradeIsLow()
    {
        // Arrange: низкая оценка по программированию, остальные средние
        var student = new Student
        {
            Grades = new Dictionary<string, int>
            {
                { "Программирование", 2 },
                { "Философия", 4 },
                { "Сети", 4 },
                { "Методы оптимизации", 4 }
            }
        };

        // Act
        bool decision = student.GetDecision();

        // Assert: студент должен быть отчислен
        Assert.IsTrue(decision, "Студент должен быть отчислен из-за низкой оценки по программированию");
    }

    [Test]
    public void GetDecision_ShouldNotExpel_WhenPhilosophyGradeIsLow()
    {
        // Arrange: низкая оценка по философии, остальные высокие
        var student = new Student
        {
            Grades = new Dictionary<string, int>
            {
                { "Программирование", 5 },
                { "Философия", 2 },
                { "Сети", 5 },
                { "Методы оптимизации", 4 }
            }
        };

        // Act
        bool decision = student.GetDecision();

        // Assert: студент не должен быть отчислен
        Assert.IsFalse(decision, "Студент не должен быть отчислен при низкой оценке по философии");
    }

    [Test]
    public void GetDecision_ShouldExpel_WhenRiskIsExactlyThreshold()
    {
        // Arrange: оценки дают ровно 20 баллов
        var student = new Student
        {
            Grades = new Dictionary<string, int>
            {
                { "Программирование", 5 }, // 3 * 3 = 9
                { "Философия", 2 },       // 4 * 1 = 4
                { "Сети", 3 },            // 3 * 2 = 6
                { "Методы оптимизации", 3 } // 1 * 2 = 2
            }
        };

        // Act
        bool decision = student.GetDecision();

        // Assert: студент должен быть отчислен
        Assert.IsTrue(decision, "Студент должен быть отчислен при риске, равном порогу");
    }
}
