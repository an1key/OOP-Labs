using Lab3;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            
            // Act
            taxi.StartRoute(["15", "end"]);
            int revenue = taxi.GetRevenuePerRoute();

            // Assert
            ClassicAssert.AreEqual((int)(15 * taxi.RatePerKm), revenue);
        }

        [Test]
        public void StartRoute_HandlesInvalidInputGracefully()
        {
            // Arrange
            var taxi = new Taxi();
            
            using var output = new StringWriter();
            Console.SetOut(output);

            // Act
            taxi.StartRoute(["abc","25","end"]);

            // Assert
            string consoleOutput = output.ToString();
            ClassicAssert.IsTrue(consoleOutput.Contains("Invalid input"));
            ClassicAssert.AreEqual((int)(25 * taxi.RatePerKm), taxi.GetRevenuePerRoute());
        }
    }
}