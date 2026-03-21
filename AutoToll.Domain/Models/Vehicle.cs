using AutoToll.Domain.Interfaces;

namespace AutoToll.Domain.Models
{
    public class Vehicle
    {
        public enum VehicleType
        {
            None = 0,
            StandardCar = 1,
            Truck = 2,
            Motorcycle = 3
        }

        public VehicleType Type { get; set; }
        public decimal Axles { get; set; } = 0;
        public ITollRule Rule { get; private set; }

        // or make a dictinary, associating Rule with Type, and then in the constructor, assign Rule based on Type
        public Vehicle(ITollRule rule)
        {
            Rule = rule;
        }
    }
}
