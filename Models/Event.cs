using System;
using System.Collections.Generic;

namespace Kinderkultur_TicketinoClient.Models
{
    public class EventInfo    {
        public int id { get; set; } 
        public int eventId { get; set; } 
        public int languageId { get; set; } 
        public string name { get; set; } 
        public string organizerNameOnTickets { get; set; } 
        public string shortDescription { get; set; } 
        public string importantNotes { get; set; } 
        public string longDescription { get; set; } 
        public string artists { get; set; } 
        public string url { get; set; } 
        public string city { get; set; } 
        public string location { get; set; } 
        public string address { get; set; } 
        public string zipCode { get; set; } 
        public object bannerImagePath { get; set; } 
        public object flyerImagePath { get; set; } 
        public object bannerImage { get; set; } 
        public object flyerImage { get; set; } 
        public object organizerRemark { get; set; } 
        public object posRemark { get; set; } 
        public object googleMapLink { get; set; } 
        public DateTime dateCreated { get; set; } 
        public DateTime dateModified { get; set; } 
    }

    public class TicketTypeInfo    {
        public int id { get; set; } 
        public string name { get; set; } 
        public int languageId { get; set; } 
        public object description { get; set; } 
        public string imageUrl { get; set; } 
        public object image { get; set; } 
        public object additionalFile { get; set; } 
        public string additionalFileUrl { get; set; } 
        public object alternateImageUrl { get; set; } 
        public object customtext1 { get; set; } 
        public object customtext2 { get; set; } 
        public object customtext3 { get; set; } 
        public object customtext4 { get; set; } 
        public bool customtext1Mandatory { get; set; } 
        public bool customtext2Mandatory { get; set; } 
        public object originalFileData { get; set; } 
        public object originalImageData { get; set; } 
        public object croppedImageData { get; set; } 
        public int ticketTypeId { get; set; } 
        public object presentation { get; set; } 
        public bool deleted { get; set; } 
        public object emailSubject { get; set; } 
        public object senderName { get; set; } 
        public DateTime modifiedDate { get; set; } 
    }

    public class TicketType    {
        public int id { get; set; } 
        public int eventId { get; set; } 
        public int ticketsTotal { get; set; } 
        public string currency { get; set; } 
        public double price { get; set; } 
        public DateTime start { get; set; } 
        public DateTime end { get; set; } 
        public int vatTypeId { get; set; } 
        public double vatPercentage { get; set; } 
        public int maxMemberTickets { get; set; } 
        public int bookWithTicketTypeId { get; set; } 
        public int sortOrder { get; set; } 
        public DateTime presaleStart { get; set; } 
        public DateTime presaleEnd { get; set; } 
        public DateTime openDoor { get; set; } 
        public DateTime invoiceEnd { get; set; } 
        public DateTime callcenterEnd { get; set; } 
        public DateTime sofortEnd { get; set; } 
        public int promoCodeIdToPrint { get; set; } 
        public string ticketTemplate { get; set; } 
        public int maxNumberOfTicketsPerOrder { get; set; } 
        public int numberOfTicketsToBasket { get; set; } 
        public object festivalEventIds { get; set; } 
        public bool hidePriceOnTicket { get; set; } 
        public bool hideOnPcClient { get; set; } 
        public bool generateNoTicket { get; set; } 
        public bool ticketByEmail { get; set; } 
        public bool hideReceipt { get; set; } 
        public bool noConfirmationEmail { get; set; } 
        public bool useWorkflow { get; set; } 
        public bool companyRequired { get; set; } 
        public bool companyMandatory { get; set; } 
        public bool firstNameRequired { get; set; } 
        public bool firstNameMandatory { get; set; } 
        public bool nameRequired { get; set; } 
        public bool nameMandatory { get; set; } 
        public bool birthDateRequired { get; set; } 
        public bool birthDateMandatory { get; set; } 
        public bool addressRequired { get; set; } 
        public bool postalCodeAndCityRequired { get; set; } 
        public bool addressMandatory { get; set; } 
        public bool postalCodeAndCityMandatory { get; set; } 
        public bool emailRequired { get; set; } 
        public bool emailMandatory { get; set; } 
        public bool isActive { get; set; } 
        public bool hideDateTime { get; set; } 
        public bool isOverheadCalculateActive { get; set; } 
        public int numberOfTicketsSold { get; set; } 
        public object colorCode { get; set; } 
        public object isSoldOut { get; set; } 
        public object showImageOnTop { get; set; } 
        public bool blockAutoMailer { get; set; } 
        public object dontShowInsurance { get; set; } 
        public object vatInGivenAmount { get; set; } 
        public object senderEmail { get; set; } 
        public object replyTo { get; set; } 
        public object emailTemplate { get; set; } 
        public object modifiedDate { get; set; } 
        public object dateCreated { get; set; } 
        public object hidePassbook { get; set; } 
        public object externalTicketCode { get; set; } 
        public bool sendSMSOrder { get; set; } 
        public bool phoneRequired { get; set; } 
        public bool phoneMandatory { get; set; } 
        public List<TicketTypeInfo> ticketTypeInfos { get; set; } 
    }

    public class EventDetails    {
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
        public object isActiveForSale { get; set; } 
        public object googleAnalyticsTracker { get; set; } 
        public bool hideOnEventList { get; set; } 
        public bool hideEventInfoOnSoldOut { get; set; } 
        public DateTime dateCreated { get; set; } 
        public DateTime dateModified { get; set; } 
        public object zoneMapId { get; set; } 
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
        public object notificationEmail { get; set; } 
        public object vatNumber { get; set; } 
        public bool sendWarning { get; set; } 
        public int salesWarningLevel { get; set; } 
        public object warningSendDate { get; set; } 
        public int salesRegionId { get; set; } 
        public object emailTemplate { get; set; } 
        public bool showLinkToGoogleMap { get; set; } 
        public double latitude { get; set; } 
        public double longitude { get; set; } 
        public object facebookPixelId { get; set; } 
        public bool stay22Active { get; set; } 
        public bool isBankInternalEvent { get; set; } 
        public object externalEventCode { get; set; } 
        public int forceEmptySeats { get; set; } 
        public List<EventOverview> eventInfos { get; set; } 
        public List<TicketType> ticketTypes { get; set; } 
    }

    public class EventCalculationDefinition    {
        public string currency { get; set; } 
        public double fromAmount { get; set; } 
        public double toAmount { get; set; } 
        public double clickPrice { get; set; } 
        public double commission { get; set; } 
        public double vat { get; set; } 
        public object organizerId { get; set; } 
        public object eventId { get; set; } 
    }

    public class Event    {
        public EventDetails eventDetails { get; set; } 
        public List<int> paymentMethodGroupIds { get; set; } 
        public List<EventCalculationDefinition> eventCalculationDefinitions { get; set; } 
    }
}