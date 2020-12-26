using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kinderkultur_TicketinoClient.Models
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class EventInfo    {
        [JsonConverter(typeof(IntConverter))]
        public int id { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string organizerName { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string eventName { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string shortDescription { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string importantNotes { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string longDescription { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string artists { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string url { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string city { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string location { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string address { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string postalCode { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string bannerImagePath { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string flyerImagePath { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string bannerImage { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string flyerImage { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int languageId { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string languageIsoCode { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string googleMapLink { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string organizerRemark { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string posRemark { get; set; } 
    }

    public class EventInfos    {
        [JsonConverter(typeof(StringConverter))]
        public string defaultLanguageCode { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool isEditable { get; set; } 
        public List<EventInfo> eventInfos { get; set; } 
    }
}