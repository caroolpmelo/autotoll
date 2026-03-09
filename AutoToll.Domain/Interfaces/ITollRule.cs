using AutoToll.Domain.Models;

namespace AutoToll.Domain.Interfaces
{
    public interface ITollRule
    {
        public bool IsApplicable(Vehicle vehicle, DateTime transitTime);

        public decimal Calculate(Vehicle vehicle);
    }
}
