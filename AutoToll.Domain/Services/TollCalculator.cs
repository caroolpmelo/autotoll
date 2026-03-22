using AutoToll.Domain.Entities;
using AutoToll.Domain.Interfaces;

namespace AutoToll.Domain.Services
{
    public class TollCalculator
    {
        private readonly IEnumerable<ITollRule> _rules;

        public TollCalculator(IEnumerable<ITollRule> rules)
        {
            _rules = rules;
        }

        /// <summary>
        /// Calculates the toll amount for a specified vehicle at a given transit time.
        /// </summary>
        /// <param name="vehicle">The vehicle for which to calculate the toll.</param>
        /// <param name="transitTime">The date and time of the vehicle's transit.</param>
        /// <returns>The calculated toll amount.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no applicable toll rule exists for the specified vehicle and transit time.</exception>
        public decimal CalculateToll(Vehicle vehicle, DateTime transitTime)
        {
            
            var applicableRule = _rules.FirstOrDefault(r => r.IsApplicable(vehicle, transitTime));

            if (applicableRule == null )
            {
                throw new InvalidOperationException("Nenhuma regra de pedágio aplicável para este veículo.");
            }

            return applicableRule.Calculate(vehicle);
        }

        // TODO
        //public decimal CalculateTotalToll(IEnumerable<Vehicle> vehicles, DateTime transitTime)
        //{
        //    // one possible optimization is to filter applicable rules first, then calculate tolls
        //    decimal totalToll = 0;
        //    foreach (var rule in _rules)
        //    {
        //        if (rule.IsApplicable(vehicle, transitTime))
        //        {
        //            totalToll += rule.Calculate(vehicle);
        //        }
        //    }
        //    return totalToll;
        //}
    }
}
