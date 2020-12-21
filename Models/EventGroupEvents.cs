using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kinderkultur_TicketinoClient.Models
{
    public class EventGroupEvents
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IddB { get; set; }
        public int eventGroupId { get; set; } 
        public List<EventOverview> events { get; set; }
    }
}