namespace Kinderkultur_TicketinoClient.Repositories
{
    public class EventDatabaseSettings : IEventDatabaseSettings
    {
        public string EventGroupInfoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IEventDatabaseSettings
    {
        string EventGroupInfoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}