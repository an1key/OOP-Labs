using Lab3;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.IO;

namespace Lab3Tests
{
    [TestFixture]
    public class GeneralTests
    {
        [Test]
        public void InterfaceImplementation_AllTransportsImplementCorrectly()
        {
            // Arrange
            var transports = new IPassengerTransport[]
            {
                new Bus(),
                new Taxi(),
                new Train()
            };

            // Act & Assert
            foreach (var transport in transports)
            {
                ClassicAssert.IsNotNull(transport.TransportName);
            }
        }

        [Test]
        public void RevenueCalculation_HandlesEmptyRoutes()
        {
            // Arrange
            var transports = new IPassengerTransport[]
            {
                new Bus(),
                new Taxi(),
                new Train()
            };

            // Act & Assert
            foreach (var transport in transports)
            {
                transport.Reset();
                ClassicAssert.AreEqual(0, transport.GetRevenuePerRoute(), 
                    $"{transport.TransportName} should have 0 revenue on an empty route.");
            }
        }

        [Test]
        public void SequentialRoutes_UpdateStateCorrectly()
        {
            // Arrange
            var bus = new Bus();
            var taxi = new Taxi();
            var train = new Train();

            // Первый маршрут
            Console.SetIn(new StringReader("10\nend\n"));
            bus.StartRoute();

            Console.SetIn(new StringReader("20\nend\n"));
            taxi.StartRoute();

            Console.SetIn(new StringReader("15\n5\nend\n"));
            train.StartRoute();

            // Сброс состояния
            bus.Reset();
            taxi.Reset();
            train.Reset();

            // Второй маршрут
            Console.SetIn(new StringReader("15\nend\n"));
            bus.StartRoute();

            Console.SetIn(new StringReader("30\nend\n"));
            taxi.StartRoute();

            Console.SetIn(new StringReader("10\n2\nend\n"));
            train.StartRoute();

            // Assert
            ClassicAssert.AreEqual(15 * bus.PayPerPassenger, bus.GetRevenuePerRoute(), "Bus revenue mismatch for second route.");
            ClassicAssert.AreEqual((int)(30.0 * taxi.RatePerKm), taxi.GetRevenuePerRoute(), "Taxi revenue mismatch for second route.");
            ClassicAssert.AreEqual(
                10 * train.RegularPayPerPassenger + 2 * train.DiscountedPayPerPassenger,
                train.GetRevenuePerRoute(), "Train revenue mismatch for second route.");
        }
        
    }
}
