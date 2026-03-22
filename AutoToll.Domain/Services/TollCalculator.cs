using AutoToll.Domain.Interfaces;
using AutoToll.Domain.Models;

namespace AutoToll.Domain.Services
{
    public class TollCalculator
    {
        private readonly IEnumerable<ITollRule> _rules;

        public TollCalculator(IEnumerable<ITollRule> rules)
        {
            _rules = rules;
        }

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
