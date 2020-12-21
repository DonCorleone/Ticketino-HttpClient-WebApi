using System.Collections.Generic;

namespace Kinderkultur_TicketinoClient.Models
{
    public class EventGroupEvents
    {
        public int eventGroupId { get; set; } 
        public List<EventOverview> events { get; set; }
    }
}