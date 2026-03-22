using AutoToll.Domain.Interfaces;
using MongoDB.Driver;

namespace AutoToll.Infrastructure.Data.Mongo
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly IMongoCollection<AuditLogDocument> _collection;

        /// <summary>
        /// Initializes a new instance of the AuditLogRepository class using the specified MongoDB database.
        /// </summary>
        /// <param name="database">The MongoDB database instance to use for audit log storage.</param>
        public AuditLogRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<AuditLogDocument>("TollAuditLogs");
        }

        /// <summary>
        /// Asynchronously logs an audit event to the MongoDB collection.
        /// </summary>
        /// <param name="eventType">The type of event being logged.</param>
        /// <param name="rawPayload">The raw payload data associated with the event.</param>
        /// <param name="resultStatus">The result status of the event.</param>
        /// <returns>A task that represents the asynchronous log operation.</returns>
        public async Task LogEventAsync(string eventType, string rawPayload, string resultStatus)
        {
            var logDocument = new AuditLogDocument
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                EventType = eventType,
                RawPayload = rawPayload,
                ResultStatus = resultStatus
            };

            await _collection.InsertOneAsync(logDocument); // Records on MongoDB, optimized for high write throughput and flexible schema for audit logs
        }
    }
}
