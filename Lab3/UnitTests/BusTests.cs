using Lab3;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.IO;

namespace Lab3Tests
{
    [TestFixture]
    public class BusTests
    {
        [Test]
        public void GetRevenuePerRoute_CalculatesCorrectly()
        {
            // Arrange
            var bus = new Bus();

            // Simулируем ввод данных
            var input = new StringReader("10\nend\n");
            Console.SetIn(input);
            
            // Act
            bus.StartRoute();
            int revenue = bus.GetRevenuePerRoute();

            // Assert
            ClassicAssert.AreEqual(10 * bus.PayPerPassenger, revenue);
        }

        [Test]
        public void StartRoute_HandlesInvalidInputGracefully()
        {
            // Arrange
            var bus = new Bus();

            // Симулируем некорректный ввод данных
            var input = new StringReader("abc\n5\nend\n");
            
            Console.SetIn(input);
            using var output = new StringWriter();
            Console.SetOut(output);
            
            // Act
            bus.StartRoute();



            // Assert
            string consoleOutput = output.ToString();
            ClassicAssert.IsTrue(consoleOutput.Contains("Invalid input"));
            ClassicAssert.AreEqual(5 * bus.PayPerPassenger, bus.GetRevenuePerRoute());
        }

        [Test]
        public void ResetRoute_ResetsStateCorrectly()
        {
            // Arrange
            var bus = new Bus();

            // Симулируем ввод данных
            var input = new StringReader("10\nend\n");
            Console.SetIn(input);

            // Act
            bus.StartRoute();
            bus.Reset();

            // Assert
            ClassicAssert.AreEqual(0, bus.CurrentPassengers);
            ClassicAssert.AreEqual(0, bus.GetRevenuePerRoute());
        }
    }
}