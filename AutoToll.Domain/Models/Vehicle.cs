namespace AutoToll.Domain.Models
{
    public class Vehicle
    {
        public enum VehicleType
        {
            None = 0,
            StandardCar = 1,
            Truck = 2
        }

        public VehicleType Type { get; set; }
        public decimal Axles { get; set; }
    }
}
