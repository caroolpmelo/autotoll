using AutoToll.Domain.Interfaces;
using AutoToll.Domain.Models;

namespace AutoToll.Domain.Rules
{
    public class StandardCarRule : ITollRule
    {
        public decimal Calculate(Vehicle vehicle) => 5.00m;

        public bool IsApplicable(Vehicle vehicle, DateTime transitTime) => vehicle.Type == Vehicle.VehicleType.StandardCar;
    }
}
