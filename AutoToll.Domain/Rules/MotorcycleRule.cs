using AutoToll.Domain.Entities;
using AutoToll.Domain.Interfaces;

namespace AutoToll.Domain.Rules
{
    public class MotorcycleRule : ITollRule
    {
        /// <summary>
        /// Calculates a value based on the specified vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to use in the calculation.</param>
        /// <returns>The calculated value.</returns>
        public decimal Calculate(Vehicle vehicle) => 5.00m / 2;

        /// <summary>
        /// Determines whether the specified vehicle is a motorcycle.
        /// </summary>
        /// <param name="vehicle">The vehicle to evaluate.</param>
        /// <param name="transitTime">The date and time of the transit.</param>
        /// <returns>true if the vehicle is a motorcycle; otherwise, false.</returns>
        public bool IsApplicable(Vehicle vehicle, DateTime transitTime) => vehicle.Type == VehicleType.Motorcycle;
    }
}
