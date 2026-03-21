using AutoToll.Domain.Interfaces;
using AutoToll.Domain.Models;
using AutoToll.Domain.Rules;
using AutoToll.Domain.Services;

namespace AutoToll.Tests
{
    public class StandardTollCalculationTests
    {
        private readonly decimal baseFare = 5.00m;

        [Fact]
        // First scenario: ""Um carro de passeio padrão passando pelo pedágio em horário normal paga uma tarifa fixa de R$ 5,00.""
        public void Calculate_GivenStandardCarInNormalHours_ShouldReturnBaseFare()
        {
            // Arrange
            var vehicle = new Vehicle { Type = Vehicle.VehicleType.StandardCar };
            var rules = new List<ITollRule> { new StandardCarRule() };
            var tollCalculator = new TollCalculator(rules);
            decimal expectedFare = baseFare;

            // Act
            var actualFare = tollCalculator.CalculateToll(vehicle, DateTime.UtcNow);

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
            var rules = new List<ITollRule> { new TruckRule() };
            var tollCalculator = new TollCalculator(rules);
            decimal expectedFare = baseFare + (vehicle.Axles * baseFare/2);

            // Act
            var actualFare = tollCalculator.CalculateToll(vehicle, DateTime.UtcNow);

            // Assert
            Assert.Equal(expectedFare, actualFare);
        }

        [Fact]
        public void Calculate_GivenMotorcycle_ShouldReturnHalfFare()
        {
            // Arrange
            var vehicle = new Vehicle { Type = Vehicle.VehicleType.Motorcycle };
            var rules = new List<ITollRule> { new MotorcycleRule() };
            var tollCalculator = new TollCalculator(rules);
            decimal expectedFare = baseFare / 2;

            // Act
            var actualFare = tollCalculator.CalculateToll(vehicle, DateTime.UtcNow);

            // Assert
            Assert.Equal(expectedFare, actualFare);
        }
    }
}
