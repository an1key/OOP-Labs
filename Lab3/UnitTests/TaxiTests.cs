using Lab3;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.IO;

namespace Lab3Tests
{
    [TestFixture]
    public class TaxiTests
    {
        [Test]
        public void GetRevenuePerRoute_CalculatesCorrectly()
        {
            // Arrange
            var taxi = new Taxi();

            // Симулируем ввод данных
            var input = new StringReader("15\nend\n");
            Console.SetIn(input);

            // Act
            taxi.StartRoute();
            int revenue = taxi.GetRevenuePerRoute();

            // Assert
            ClassicAssert.AreEqual((int)(15 * taxi.RatePerKm), revenue);
        }

        [Test]
        public void StartRoute_HandlesInvalidInputGracefully()
        {
            // Arrange
            var taxi = new Taxi();

            // Симулируем некорректный ввод данных
            var input = new StringReader("abc\n25\nend\n");
            Console.SetIn(input);

            using var output = new StringWriter();
            Console.SetOut(output);

            // Act
            taxi.StartRoute();

            // Assert
            string consoleOutput = output.ToString();
            ClassicAssert.IsTrue(consoleOutput.Contains("Invalid input"));
            ClassicAssert.AreEqual((int)(25 * taxi.RatePerKm), taxi.GetRevenuePerRoute());
        }
    }
}