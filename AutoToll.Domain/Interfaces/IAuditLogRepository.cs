namespace AutoToll.Domain.Interfaces
{
    public interface IAuditLogRepository // Interface for NoSQL DB (Logs/Audits)
    {
        /// <summary>
        /// Asynchronously logs an event with the specified type, payload, and result status.
        /// </summary>
        /// <param name="eventType">The type of event to log.</param>
        /// <param name="rawPayload">The raw payload data associated with the event.</param>
        /// <param name="resultStatus">The result status of the event.</param>
        /// <returns>A task that represents the asynchronous log operation.</returns>
        Task LogEventAsync(string eventType, string rawPayload, string resultStatus);
    }
}
