using AutoToll.Domain.Entities;

namespace AutoToll.Domain.Interfaces
{
    public interface ITollRule
    {
        /// <summary>
        /// Determines whether the specified vehicle is applicable at the given transit time.
        /// </summary>
        /// <param name="vehicle">The vehicle to evaluate.</param>
        /// <param name="transitTime">The date and time of the transit.</param>
        /// <returns>true if the vehicle is applicable at the specified transit time; otherwise, false.</returns>
        public bool IsApplicable(Vehicle vehicle, DateTime transitTime);

        /// <summary>
        /// Calculates the total cost for the specified vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle for which to calculate the cost.</param>
        /// <returns>The calculated total cost.</returns>
        public decimal Calculate(Vehicle vehicle);
    }
}
