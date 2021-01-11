namespace Kinderkultur_TicketinoClient.Repositories
{
    public class EventDatabaseSettings : IEventDatabaseSettings
    {
        public string EventGroupOverviewCollectionName { get; set; }
        public string EventGroupCollectionName { get; set; }
        public string EventOverviewCollectionName { get; set; }
        public string EventGroupEventCollectionName { get; set; }
        public string EventEventGroupUsageCollectionName { get; set; }
        public string EventGroupEventDetailCollectionName { get; set; }
        public string EventCollectionName { get; set; }
        public string EventInfoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string EventDetailsCollectionName { get; set; }
    }

    public interface IEventDatabaseSettings
    {
        string EventGroupOverviewCollectionName { get; set; }
        string EventGroupCollectionName { get; set; }
        string EventOverviewCollectionName { get; set; }
        string EventGroupEventCollectionName { get; set; }
        string EventEventGroupUsageCollectionName { get; set; }
        string EventGroupEventDetailCollectionName { get; set; }
        string EventCollectionName { get; set; }
        string EventInfoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string EventDetailsCollectionName { get; set; }
    }
}