namespace Kinderkultur_TicketinoClient.Repositories
{
    public class EventDatabaseSettings : IEventDatabaseSettings
    {
        public string EventGroupOverviewCollectionName { get; set; }
        public string EventGroupCollectionName { get; set; }
        public string EventOverviewCollectionName { get; set; }
        public string EventGroupEventCollectionName { get; set; }
        public string EventCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IEventDatabaseSettings
    {
        string EventGroupOverviewCollectionName { get; set; }
        string EventGroupCollectionName { get; set; }
        string EventOverviewCollectionName { get; set; }
        string EventGroupEventCollectionName { get; set; }
        string EventCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}