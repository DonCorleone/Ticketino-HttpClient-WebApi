using System.Collections.Generic;

namespace Kinderkultur_TicketinoClient.Models
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class EventInfo    {
        public int id { get; set; } 
        public string organizerName { get; set; } 
        public string eventName { get; set; } 
        public string shortDescription { get; set; } 
        public string importantNotes { get; set; } 
        public string longDescription { get; set; } 
        public string artists { get; set; } 
        public string url { get; set; } 
        public string city { get; set; } 
        public string location { get; set; } 
        public string address { get; set; } 
        public string postalCode { get; set; } 
        public string bannerImagePath { get; set; } 
        public string flyerImagePath { get; set; } 
        public object bannerImage { get; set; } 
        public object flyerImage { get; set; } 
        public int languageId { get; set; } 
        public string languageIsoCode { get; set; } 
        public object googleMapLink { get; set; } 
        public object organizerRemark { get; set; } 
        public object posRemark { get; set; } 
    }

    public class EventInfos    {
        public string defaultLanguageCode { get; set; } 
        public bool isEditable { get; set; } 
        public List<EventInfo> eventInfos { get; set; } 
    }
}