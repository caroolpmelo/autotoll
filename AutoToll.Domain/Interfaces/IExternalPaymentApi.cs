namespace AutoToll.Domain.Interfaces
{
    public interface IExternalPaymentApi
    {
        /// <summary>
        /// Asynchronously charges the specified vehicle's account for the given amount using an external payment
        /// service.
        /// </summary>
        /// <param name="licensePlate">The license plate number of the vehicle to charge.</param>
        /// <param name="amountDue">The amount to be charged to the vehicle's account.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains true if the charge was
        /// successful; otherwise, false.</returns>
        Task<bool> ChargeAsync(string licensePlate, decimal amountDue); // Simulates charging the vehicle's account via an external payment API, returns success status
    }
}
