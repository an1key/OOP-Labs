using Lab3;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            
            // Act
            train.StartRoute(["15", "5", "end"]);
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


            using var output = new StringWriter();
            Console.SetOut(output);

            // Act
            train.StartRoute(["aw","10", "3"]);


            // Assert
            string consoleOutput = output.ToString();
            ClassicAssert.IsTrue(consoleOutput.Contains("Invalid input"));
            ClassicAssert.AreEqual(
                10 * train.RegularPayPerPassenger + 3 * train.DiscountedPayPerPassenger,
                train.GetRevenuePerRoute());
        }
    }
}