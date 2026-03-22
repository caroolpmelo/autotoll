namespace AutoToll.Domain.Models
{
    public class PaymentResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the total amount charged.
        /// </summary>
        public decimal AmountCharged { get; set; }
    }
}
