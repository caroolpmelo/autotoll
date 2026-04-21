using AutoToll.Domain.Interfaces;
using AutoToll.Domain.Entities;
using AutoToll.Domain.Services;
using AutoToll.Domain.Models;

namespace AutoToll.Api.Services
{
    public class PaymentOrchestrator
    {
        private readonly TollCalculator _calculator;
        private readonly ITransactionRepository _sqlRepository;
        private readonly IAuditLogRepository _mongoRepository;
        private readonly IExternalPaymentApi _paymentApi; // Simulate external API

        /// <summary>
        /// Initializes a new instance of the PaymentOrchestrator class with the specified dependencies.
        /// </summary>
        /// <param name="calculator">Service for calculating tolls.</param>
        /// <param name="sqlRepository">Repository for transaction data storage.</param>
        /// <param name="mongoRepository">Repository for audit log storage.</param>
        /// <param name="paymentApi">External API for processing payments.</param>
        public PaymentOrchestrator(
            TollCalculator calculator,
            ITransactionRepository sqlRepository,
            IAuditLogRepository mongoRepository,
            IExternalPaymentApi paymentApi)
        {
            _calculator = calculator;
            _sqlRepository = sqlRepository;
            _mongoRepository = mongoRepository;
            _paymentApi = paymentApi;
        }

        /// <summary>
        /// Processes a toll passage by calculating the toll, charging the vehicle, and recording the transaction and
        /// audit events.
        /// </summary>
        /// <param name="vehicle">The vehicle for which the toll passage is being processed.</param>
        /// <param name="rawRequestJson">The raw JSON request representing the toll passage event.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the payment result, including
        /// success status and amount charged.</returns>
        public async Task<PaymentResult> ProcessTollPassageAsync(Vehicle vehicle, string rawRequestJson)
        {
            // 1. Logs audit event in NoSQL
            await _mongoRepository.LogEventAsync("TollPassageReceived", rawRequestJson, "Pending");

            // 2. Rules engine calculates the toll amount
            var amountDue = _calculator.CalculateToll(vehicle, DateTime.UtcNow);

            // 3. Orchestrates payment processing with external API
            var paymentSuccess = await _paymentApi.ChargeAsync(vehicle.LicensePlate, amountDue);

            // 4. Saves result in PostgreSQL
            var transaction = new Transaction
            {
                LicensePlate = vehicle.LicensePlate,
                Amount = amountDue,
                Status = paymentSuccess ? "Paid" : "Failed",
                ProcessedAt = DateTime.UtcNow
            };
            await _sqlRepository.SaveTransactionAsync(transaction);

            // 5. Updates NoSQL Audit Log
            await _mongoRepository.LogEventAsync("TollPassageProcessed", rawRequestJson, transaction.Status);

            return new PaymentResult { Success = paymentSuccess, AmountCharged = amountDue };
        }
    }
}
