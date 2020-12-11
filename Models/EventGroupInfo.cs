using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kinderkultur_TicketinoClient.Models
{
    public class EventGroup {
        public int id { get; set; } 
        public int organizerId { get; set; } 
        public string name { get; set; } 
        public string bannerImagePath { get; set; } 
    }

    public class EventGroupInfo {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IddB { get; set; }
        public int id { get; set; } 
        public string name { get; set; } 
        public DateTime dateCreated { get; set; } 
    }

    public class EventGroupInfoList    {
        public List<EventGroupInfo> eventGroups { get; set; } 
        public int numberOfEventGroups { get; set; } 
        public bool canCrudEventGroups { get; set; } 
    }
}