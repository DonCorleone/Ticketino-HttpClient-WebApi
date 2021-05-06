using System;
using System.Collections.Generic;

namespace Kinderkultur_TicketinoClient.Models
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Turnover
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class EventIdDistributor
    {
        public int numberOfTicketsSold { get; set; }
        public List<Turnover> turnover { get; set; }
        public int id { get; set; }
        public int defaultLanguageId { get; set; }
        public int organizerId { get; set; }
        public int status { get; set; }
        public int maxTickets { get; set; }
        public int maxTicketsProOrder { get; set; }
        public int countryId { get; set; }
        public DateTime openDoor { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int eventGenreValue { get; set; }
        public object googleCoordinates { get; set; }
        public string googleAnalyticsTracker { get; set; }
        public bool hideOnEventList { get; set; }
        public bool hideEventInfoOnSoldOut { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public int? zoneMapId { get; set; }
        public int postSaleCloseStatus { get; set; }
        public object masterEventId { get; set; }
        public object organizerGoogleAnalyticsDomain { get; set; }
        public bool isCompanyNameMandatory { get; set; }
        public bool isPhoneMandatory { get; set; }
        public int tenantId { get; set; }
        public object locationId { get; set; }
        public bool noVatOnCommission { get; set; }
        public double shippingFee { get; set; }
        public bool sendNotificationByEmail { get; set; }
        public string notificationEmail { get; set; }
        public string vatNumber { get; set; }
        public bool sendWarning { get; set; }
        public int salesWarningLevel { get; set; }
        public object warningSendDate { get; set; }
        public int salesRegionId { get; set; }
        public object emailTemplate { get; set; }
        public bool showLinkToGoogleMap { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string facebookPixelId { get; set; }
        public bool stay22Active { get; set; }
        public bool isBankInternalEvent { get; set; }
        public object externalEventCode { get; set; }
        public int forceEmptySeats { get; set; }
    }

    public class EventIdDistributors
    {
        public IList<EventIdDistributor> events { get; set; }
    }

}