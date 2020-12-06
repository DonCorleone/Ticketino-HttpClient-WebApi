using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kinderkultur_TicketinoClient.Models
{
    public class EventGroupInfo    {
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