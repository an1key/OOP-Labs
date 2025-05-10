namespace Lab7_1_Test;
using Lab7_1;
using NUnit.Framework;

[TestFixture]
public class DelegateTests
{
    private readonly MyDel _calculateAverage;
    public DelegateTests()
    {
        // Инициализация делегата с анонимным методом
        _calculateAverage = delegate (int[] array)
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
    }

    [Test]
    public void Test_Average_Calculation()
    {
        // Проверка на стандартном массиве
        // Arrange
        int[] numbers = { 1, 2, 3, 4, 5 };
        double expected = 3.0;
        
        // Act
        double result = _calculateAverage(numbers);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Empty_Array_Throws_Exception()
    {
        // Проверка на пустом массиве
        // Arrange
        int[] emptyArray = Array.Empty<int>();
        
        // Act
        var ex = Assert.Throws<ArgumentException>(() => _calculateAverage(emptyArray));
        
        // Assert
        Assert.That(ex.Message, Is.EqualTo("Массив не может быть пустым или null."));
    }

    [Test]
    public void Test_Null_Array_Throws_Exception()
    {
        // Проверка на null-массиве
        // Arrange
        int[] nullArray = null;
        
        // Act
        var ex = Assert.Throws<ArgumentException>(() => _calculateAverage(nullArray));
        
        // Assert
        Assert.That(ex.Message, Is.EqualTo("Массив не может быть пустым или null."));
    }

    [Test]
    public void Test_Single_Element_Array()
    {
        // Проверка на массиве с одним элементом
        // Arrange
        int[] singleElement = { 42 };
        double expected = 42.0;
        
        // Act
        double result = _calculateAverage(singleElement);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Negative_Numbers()
    {
        // Проверка на массиве с отрицательными числами
        // Arrange
        int[] negativeNumbers = { -1, -2, -3, -4, -5 };
        double expected = -3.0;
        
        // Act
        double result = _calculateAverage(negativeNumbers);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Null_Sum_Array()
    {
        // Проверка на массиве с нулевой суммой
        // Arrange
        int[] zeroSumArray = { -1, 1, -2, 2 };
        double expected = 0.0;
        
        // Act
        double result = _calculateAverage(zeroSumArray);
        
        // Assert
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void Test_Mixed_Numbers()
    {
        // Проверка на массиве с смешанными числами
        // Arrange
        int[] mixedNumbers = { 10, -5, 20, -10, 0 };
        double expected = 3.0;
        
        // Act
        double result = _calculateAverage(mixedNumbers);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Large_Array()
    {
        // Проверка на большом массиве
        // Arrange
        int[] largeArray = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
        double expected = 550.0;
        
        // Act
        double result = _calculateAverage(largeArray);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Zero_Sum_Array()
    {
        // Проверка на массиве с нулевой суммой
        // Arrange
        int[] zeroSumArray = { -1, 1, -2, 2 };
        double expected = 0.0;
        
        // Act
        double result = _calculateAverage(zeroSumArray);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Boundary_Condition()
    {
        // Проверка на граничных значениях
        // Arrange
        int[] boundaryArray = { int.MinValue, int.MaxValue };
        double expected = (double)(int.MinValue + int.MaxValue) / 2;
        
        // Act
        double result = _calculateAverage(boundaryArray);
        
        // Assert
        Assert.AreEqual(expected, result);
    }
}