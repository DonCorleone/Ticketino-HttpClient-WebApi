using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kinderkultur_TicketinoClient.Models
{
    public class TicketTypeInfo    {
        public int id { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string name { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int languageId { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string description { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string imageUrl { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string image { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string additionalFile { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string additionalFileUrl { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string alternateImageUrl { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string customtext1 { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string customtext2 { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string customtext3 { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string customtext4 { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool customtext1Mandatory { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool customtext2Mandatory { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string originalFileData { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string originalImageData { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string croppedImageData { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int ticketTypeId { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string presentation { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool deleted { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string emailSubject { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string senderName { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime modifiedDate { get; set; } 
    }

    public class TicketType    {
        [JsonConverter(typeof(IntConverter))]
        public int id { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int eventId { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int ticketsTotal { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string currency { get; set; } 
        [JsonConverter(typeof(DoubleConverter))]
        public double price { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime start { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime end { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int vatTypeId { get; set; } 
        [JsonConverter(typeof(DoubleConverter))]
        public double vatPercentage { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int maxMemberTickets { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int bookWithTicketTypeId { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int sortOrder { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime presaleStart { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime presaleEnd { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime openDoor { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime invoiceEnd { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime callcenterEnd { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime sofortEnd { get; set; } 
        public int promoCodeIdToPrint { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string ticketTemplate { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int maxNumberOfTicketsPerOrder { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int numberOfTicketsToBasket { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string festivalEventIds { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool hidePriceOnTicket { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool hideOnPcClient { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool generateNoTicket { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool ticketByEmail { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool hideReceipt { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool noConfirmationEmail { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool useWorkflow { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool companyRequired { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool companyMandatory { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool firstNameRequired { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool firstNameMandatory { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool nameRequired { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool nameMandatory { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool birthDateRequired { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool birthDateMandatory { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool addressRequired { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool postalCodeAndCityRequired { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool addressMandatory { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool postalCodeAndCityMandatory { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool emailRequired { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool emailMandatory { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool isActive { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool hideDateTime { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool isOverheadCalculateActive { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int numberOfTicketsSold { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string colorCode { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool isSoldOut { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool showImageOnTop { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool blockAutoMailer { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool dontShowInsurance { get; set; } 
        [JsonConverter(typeof(DecimalConverter))]
        public decimal vatInGivenAmount { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string senderEmail { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string replyTo { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string emailTemplate { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime modifiedDate { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime dateCreated { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool hidePassbook { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string externalTicketCode { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool sendSMSOrder { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool phoneRequired { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool phoneMandatory { get; set; } 
        public List<TicketTypeInfo> ticketTypeInfos { get; set; } 
    }

    public class EventDetails    {
        [JsonConverter(typeof(IntConverter))]
        public int id { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int defaultLanguageId { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int organizerId { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int status { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int maxTickets { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int maxTicketsProOrder { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int countryId { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime openDoor { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime start { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime end { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int eventGenreValue { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string googleCoordinates { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool isActiveForSale { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string googleAnalyticsTracker { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool hideOnEventList { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool hideEventInfoOnSoldOut { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime dateCreated { get; set; } 
        [JsonConverter(typeof(DateConverter))]
        public DateTime dateModified { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int zoneMapId { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int postSaleCloseStatus { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int masterEventId { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string organizerGoogleAnalyticsDomain { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool isCompanyNameMandatory { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool isPhoneMandatory { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int tenantId { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int locationId { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool noVatOnCommission { get; set; } 
        [JsonConverter(typeof(DoubleConverter))]
        public double shippingFee { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool sendNotificationByEmail { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string notificationEmail { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string vatNumber { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool sendWarning { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int salesWarningLevel { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string warningSendDate { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int salesRegionId { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string emailTemplate { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool showLinkToGoogleMap { get; set; } 
        [JsonConverter(typeof(DoubleConverter))]
        public double latitude { get; set; } 
        [JsonConverter(typeof(DoubleConverter))]
        public double longitude { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string facebookPixelId { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool stay22Active { get; set; } 
        [JsonConverter(typeof(BoolConverter))]
        public bool isBankInternalEvent { get; set; } 
        [JsonConverter(typeof(StringConverter))]
        public string externalEventCode { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int forceEmptySeats { get; set; } 
        public List<EventInfo> eventInfos { get; set; } 
        public List<TicketType> ticketTypes { get; set; } 
    }

    public class EventCalculationDefinition    {
        [JsonConverter(typeof(StringConverter))]
        public string currency { get; set; } 
        [JsonConverter(typeof(DoubleConverter))]
        public double fromAmount { get; set; } 
        [JsonConverter(typeof(DoubleConverter))]
        public double toAmount { get; set; } 
        [JsonConverter(typeof(DoubleConverter))]
        public double clickPrice { get; set; } 
        [JsonConverter(typeof(DoubleConverter))]
        public double commission { get; set; } 
        [JsonConverter(typeof(DoubleConverter))]
        public double vat { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int organizerId { get; set; } 
        [JsonConverter(typeof(IntConverter))]
        public int eventId { get; set; } 
    }

    public class EventObject    {
        public EventDetails eventDetails { get; set; } 
        public List<int> paymentMethodGroupIds { get; set; } 
        public List<EventCalculationDefinition> eventCalculationDefinitions { get; set; } 
    }

    public class StringConverter : JsonConverter<string>
    {
        public override bool HandleNull => true;

        public override string Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            reader.GetString() ?? "";

        public override void Write(
            Utf8JsonWriter writer,
            string value,
            JsonSerializerOptions options) =>
            writer.WriteStringValue(value);
    }

    public class BoolConverter : JsonConverter<bool>
    {
        public override bool HandleNull => true;

        public override bool Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            reader.TokenType == JsonTokenType.Null ? false : reader.GetBoolean();

        public override void Write(
            Utf8JsonWriter writer,
            bool value,
            JsonSerializerOptions options) =>
            writer.WriteBooleanValue(value);
    }

    public class DateConverter : JsonConverter<DateTime>
    {
        public override bool HandleNull => true;

        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            reader.TokenType == JsonTokenType.Null ? DateTime.MinValue : reader.GetDateTime();

        public override void Write(
            Utf8JsonWriter writer,
            DateTime value,
            JsonSerializerOptions options) =>
            writer.WriteNullValue();
    }

    public class IntConverter : JsonConverter<int>
    {
        public override bool HandleNull => true;

        public override int Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            reader.TokenType == JsonTokenType.Null ? int.MinValue : reader.GetInt32();

        public override void Write(
            Utf8JsonWriter writer,
            int value,
            JsonSerializerOptions options) =>
            writer.WriteNumberValue(value);
    }

    public class DecimalConverter : JsonConverter<decimal>
    {
        public override bool HandleNull => true;

        public override decimal Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            reader.TokenType == JsonTokenType.Null ? decimal.MinValue : reader.GetDecimal();

        public override void Write(
            Utf8JsonWriter writer,
            decimal value,
            JsonSerializerOptions options) =>
            writer.WriteNumberValue(value);
    }

    public class DoubleConverter : JsonConverter<double>
    {
        public override bool HandleNull => true;

        public override double Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            reader.TokenType == JsonTokenType.Null ? double.MinValue : reader.GetDouble();

        public override void Write(
            Utf8JsonWriter writer,
            double value,
            JsonSerializerOptions options) =>
            writer.WriteNumberValue(value);
    }
}