using AutoToll.Domain.Entities;
using AutoToll.Domain.Interfaces;

namespace AutoToll.Domain.Rules
{
    public class StandardCarRule : ITollRule
    {
        /// <summary>
        /// Calculates the toll for the specified vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle for which to calculate the toll.</param>
        /// <returns>The calculated fee.</returns>
        public decimal Calculate(Vehicle vehicle) => 5.00m;

        /// <summary>
        /// Determines whether the specified vehicle is a standard car.
        /// </summary>
        /// <param name="vehicle">The vehicle to evaluate.</param>
        /// <param name="transitTime">The date and time of the vehicle's transit.</param>
        /// <returns>true if the vehicle is a standard car; otherwise, false.</returns>
        public bool IsApplicable(Vehicle vehicle, DateTime transitTime) => vehicle.Type == VehicleType.StandardCar;
    }
}
