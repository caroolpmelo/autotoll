using AutoToll.Domain.Interfaces;

public enum VehicleType
{
    None = 0,
    StandardCar = 1,
    Truck = 2,
    Motorcycle = 3
}

namespace AutoToll.Domain.Entities
{
    public class Vehicle
    {
        /// <summary>
        /// Gets or sets the vehicle's license plate number.
        /// </summary>
        public string LicensePlate { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of the vehicle.
        /// </summary>
        public VehicleType Type { get; set; }

        /// <summary>
        /// Gets or sets the number of axles, if different from zero, vehicle is a truck.
        /// </summary>
        public decimal Axles { get; set; } = 0;
    }
}
