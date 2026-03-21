using AutoToll.Domain.Interfaces;
using AutoToll.Domain.Models;

namespace AutoToll.Domain.Rules
{
    public class MotorcycleRule : ITollRule
    {
        public decimal Calculate(Vehicle vehicle) => 5.00m / 2;

        public bool IsApplicable(Vehicle vehicle, DateTime transitTime) => vehicle.Type == Vehicle.VehicleType.Motorcycle;
    }
}
