using MongoDB.Bson.Serialization.Attributes;

namespace AutoToll.Infrastructure.Data.Mongo
{
    public class AuditLogDocument
    {
        [BsonId] // Indicates that this property is the document's unique identifier in MongoDB
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string RawPayload { get; set; } = string.Empty;
        public string ResultStatus { get; set; } = string.Empty;
    }
}
