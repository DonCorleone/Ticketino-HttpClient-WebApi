using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kinderkultur_TicketinoClient.Models
{
    public class EventGroupOverview {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IddB { get; set; }
        public int id { get; set; } 
        public string name { get; set; } 
        public DateTime dateCreated { get; set; } 
        public int organizerId { get; set; }
    }

    // public class EventGroupOverviewList    {
    //     public List<EventGroupOverview> eventGroups { get; set; } 
    //     public int numberOfEventGroups { get; set; } 
    //     public bool canCrudEventGroups { get; set; } 
    // }
}