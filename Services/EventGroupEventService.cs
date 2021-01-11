using Kinderkultur_TicketinoClient.Contracts;
using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace Kinderkultur_TicketinoClient.Services
{
    public class EventGroupEventService : IEventGroupEventService
    {
        private readonly IMongoCollection<EventGroupEvents> _eventOverview;

        public EventGroupEventService(IEventDatabaseSettings settings, IConfiguration configuration)
        {
           var client = new MongoClient($"mongodb+srv://ticketinoClient:9sdQuDmQwnvbla4j@cluster0.x3l7f.mongodb.net/{settings.DatabaseName}?retryWrites=true&w=majority");
            
            var database = client.GetDatabase(settings.DatabaseName);

            _eventOverview = database.GetCollection<EventGroupEvents>(settings.EventGroupEventCollectionName);
        }

        public List<EventGroupEvents> Get() =>
            _eventOverview.Find(eventGroupEvents => true).ToList();

        public EventGroupEvents Create(EventGroupEvents eventGroupEvents)
        {
            _eventOverview.InsertOne(eventGroupEvents);
            return eventGroupEvents;
        }

        public void RemoveAll() => 
            _eventOverview.DeleteMany(new BsonDocument());
    }
}