using System.Text.Json.Serialization;

namespace Kinderkultur_TicketinoClient.Models
{
    public class Organizer
    {
        [JsonConverter(typeof(StringConverter))]
        public string organizerName { get; set; } 
        public int id { get; set; } 
        public int addressId { get; set; } 
        public string username { get; set; } 
        public int tenantId { get; set; } 
    }
}