using System;
using System.Collections.Generic;

namespace Kinderkultur_TicketinoClient.Models
{
    public class EventOverview    {
        public int id { get; set; } 
        public string name { get; set; } 
        public DateTime start { get; set; } 
        public bool canBeRemovedFromEventGroup { get; set; } 
    }

    public class EventOverviewList    {
        public List<EventOverview> events { get; set; } 
        public int numberOfEvents { get; set; } 
    }
}