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
            var client = new MongoClient($"mongodb://{configuration["mongodb-username"]}:{configuration["mongodb-password"]}@192.168.178.12:27017");
            var database = client.GetDatabase(settings.DatabaseName);

            _eventOverview = database.GetCollection<EventGroupEvents>(settings.EventGroupEventCollectionName);
        }

        public List<EventGroupEvents> Get() =>
            _eventOverview.Find(eventGroupEvents => true).ToList();

        // public EventGroupOverview Get(string id) =>
        //     _eventGroupOverview.Find<EventGroupOverview>(eventGroupOverview => eventGroupOverview.IddB == id).FirstOrDefault();

        public EventGroupEvents Create(EventGroupEvents eventGroupEvents)
        {
            _eventOverview.InsertOne(eventGroupEvents);
            return eventGroupEvents;
        }

        // public void Update(string id, EventGroupOverview eventGroupOverviewIn) =>
        //     _eventGroupOverview.ReplaceOne(eventGroupOverview => eventGroupOverview.IddB == id, eventGroupOverviewIn);

        // public void Remove(EventGroupOverview eventGroupOverviewIn) =>
        //     _eventGroupOverview.DeleteOne(eventGroupOverview => eventGroupOverview.IddB == eventGroupOverviewIn.IddB);

        // public void Remove(string id) => 
        //     _eventGroupOverview.DeleteOne(eventGroupOverview => eventGroupOverview.IddB == id);

        public void RemoveAll() => 
            _eventOverview.DeleteMany(new BsonDocument());
    }
}