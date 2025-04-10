using Lab3;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            bus.StartRoute(["10","end"]);

            taxi.StartRoute(["20","end"]);

            train.StartRoute(["15","5","end"]);

            // Сброс состояния
            bus.Reset();
            taxi.Reset();
            train.Reset();

            // Второй маршрут
            bus.StartRoute(["15","end"]);


            taxi.StartRoute(["30","end"]);


            train.StartRoute(["10","2","end"]);

            // Assert
            ClassicAssert.AreEqual(15 * bus.PayPerPassenger, bus.GetRevenuePerRoute(), "Bus revenue mismatch for second route.");
            ClassicAssert.AreEqual((int)(30.0 * taxi.RatePerKm), taxi.GetRevenuePerRoute(), "Taxi revenue mismatch for second route.");
            ClassicAssert.AreEqual(
                10 * train.RegularPayPerPassenger + 2 * train.DiscountedPayPerPassenger,
                train.GetRevenuePerRoute(), "Train revenue mismatch for second route.");
        }
        
    }
}
