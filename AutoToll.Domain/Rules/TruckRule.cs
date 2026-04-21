using AutoToll.Domain.Entities;
using AutoToll.Domain.Interfaces;

namespace AutoToll.Domain.Rules
{
    public class TruckRule : ITollRule
    {
        /// <summary>
        /// Calculates the toll amount based on the number of axles of the specified vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle for which to calculate the toll.</param>
        /// <returns>The calculated toll amount.</returns>
        public decimal Calculate(Vehicle vehicle) => 5.00m + (vehicle.Axles * 2.50m);

        /// <summary>
        /// Determines whether the specified vehicle is a truck.
        /// </summary>
        /// <param name="vehicle">The vehicle to evaluate.</param>
        /// <param name="transitTime">The date and time of the transit.</param>
        /// <returns>true if the vehicle is a truck; otherwise, false.</returns>
        public bool IsApplicable(Vehicle vehicle, DateTime transitTime) => vehicle.Type == VehicleType.Truck;
    }
}
