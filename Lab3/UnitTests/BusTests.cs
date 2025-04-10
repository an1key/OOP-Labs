using Lab3;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            
            // Act
            bus.StartRoute(["10","end"]);
            int revenue = bus.GetRevenuePerRoute();

            // Assert
            ClassicAssert.AreEqual(10 * bus.PayPerPassenger, revenue);
        }

        [Test]
        public void StartRoute_HandlesInvalidInputGracefully()
        {
            // Arrange
            var bus = new Bus();
            
            using var output = new StringWriter();
            Console.SetOut(output);
            
            // Act
            bus.StartRoute(["abc","5","end"]);



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
            
            // Act
            bus.StartRoute(["10","end"]);
            bus.Reset();

            // Assert
            ClassicAssert.AreEqual(0, bus.CurrentPassengers);
            ClassicAssert.AreEqual(0, bus.GetRevenuePerRoute());
        }
    }
}