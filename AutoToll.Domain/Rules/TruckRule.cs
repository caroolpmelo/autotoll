using AutoToll.Domain.Interfaces;
using AutoToll.Domain.Models;
using static AutoToll.Domain.Models.Vehicle;

namespace AutoToll.Domain.Rules
{
    public class TruckRule : ITollRule
    {
        public decimal Calculate(Vehicle vehicle) => 5.00m + (vehicle.Axles * 2.50m);

        public bool IsApplicable(Vehicle vehicle, DateTime transitTime) => vehicle.Type == VehicleType.Truck;
    }
}
