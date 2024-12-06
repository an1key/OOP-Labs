using Lab3;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.IO;

namespace Lab3Tests
{
    [TestFixture]
    public class TrainTests
    {
        [Test]
        public void GetRevenuePerRoute_CalculatesCorrectly()
        {
            // Arrange
            var train = new Train();

            // Симулируем ввод данных
            var input = new StringReader("15\n5\nend\n");
            Console.SetIn(input);

            // Act
            train.StartRoute();
            int revenue = train.GetRevenuePerRoute();

            // Assert
            ClassicAssert.AreEqual(
                15 * train.RegularPayPerPassenger + 5 * train.DiscountedPayPerPassenger,
                revenue);
        }

        [Test]
        public void StartRoute_HandlesInvalidInputGracefully()
        {
            // Arrange
            var train = new Train();

            // Симулируем некорректный ввод данных
            var input = new StringReader("abc\n10\n3\nend\n");
            Console.SetIn(input);

            using var output = new StringWriter();
            Console.SetOut(output);

            // Act
            train.StartRoute();

            // Assert
            string consoleOutput = output.ToString();
            ClassicAssert.IsTrue(consoleOutput.Contains("Invalid input"));
            ClassicAssert.AreEqual(
                10 * train.RegularPayPerPassenger + 3 * train.DiscountedPayPerPassenger,
                train.GetRevenuePerRoute());
        }
    }
}