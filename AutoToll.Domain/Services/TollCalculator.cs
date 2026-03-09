using AutoToll.Domain.Models;

namespace AutoToll.Domain.Services
{
    public class TollCalculator
    {
        public decimal Calculate(Vehicle vehicle)
        {
            if (vehicle.Type == Vehicle.VehicleType.StandardCar)
            {
                return 5.00m; // Tarifa fixa para carro de passeio padrão
            }

            if (vehicle.Type == Vehicle.VehicleType.Truck)
            {
                return 5.00m + (vehicle.Axles * 2.50m); // Tarifa fixa para carro de passeio padrão
            }
            // Lógica para outros tipos de veículos pode ser adicionada aqui
            return 0.00m; // Valor padrão para veículos não especificados
            //return 0.00m; // Valor padrão para veículos não especificados
        }
    }
}
