using AutoToll.Domain.Models;
using AutoToll.Domain.Services;

namespace AutoToll.Tests
{
    public class StandardTollCalculationTests
    {
        [Fact]
        // First scenario: ""Um carro de passeio padrão passando pelo pedágio em horário normal paga uma tarifa fixa de R$ 5,00.""
        public void Calculate_GivenStandardCarInNormalHours_ShouldReturnBaseFare()
        {
            // Arrange
            var vehicle = new Vehicle { Type = Vehicle.VehicleType.StandardCar };
            var tollCalculator = new TollCalculator();
            decimal expectedFare = 5.00m;

            // Act
            var actualFare = tollCalculator.Calculate(vehicle);

            // Assert
            Assert.Equal(expectedFare, actualFare);
            // or using FluentAssertions:
            // actual.Should().Be(expected);
        }

        [Fact]
        public void Calculate_GivenTruckWithThreeAxles_ShouldReturnMultiplierFare()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Type = Vehicle.VehicleType.Truck,
                Axles = 3
            };
            var tollCalculator = new TollCalculator();
            decimal expectedFare = 5.00m + (vehicle.Axles * 2.50m);

            // Act
            var actualFare = tollCalculator.Calculate(vehicle);

            // Assert
            Assert.Equal(expectedFare, actualFare);
        }
    }
}
