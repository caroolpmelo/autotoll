namespace AutoToll.Domain.Entities
{
    public class Transaction
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public int Id { get; set; } // Primary key for SQL DB

        /// <summary>
        /// Gets or sets the vehicle's license plate number.
        /// </summary>
        public string LicensePlate { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the monetary amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        public string Status { get; set; } = string.Empty; // "Paid", "Failed", etc.

        /// <summary>
        /// Gets or sets the date and time when the item was processed.
        /// </summary>
        public DateTime ProcessedAt { get; set; }
    }
}
