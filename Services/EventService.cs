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
    public class EventService : IEventService
    {

        private readonly IMongoCollection<EventObject> _event;

        public EventService(IEventDatabaseSettings settings, IConfiguration configuration)
        {
            var client = new MongoClient($"mongodb://{configuration["mongodb-username"]}:{configuration["mongodb-password"]}@192.168.178.12:27017");
            var database = client.GetDatabase(settings.DatabaseName);

            _event = database.GetCollection<EventObject>(settings.EventCollectionName);
        }

        public List<EventObject> Get() =>
            _event.Find(eventGroup => true).ToList();

        // public EventGroupOverview Get(string id) =>
        //     _eventGroupOverview.Find<EventGroupOverview>(eventGroupOverview => eventGroupOverview.IddB == id).FirstOrDefault();

        public EventObject Create(EventObject eventObject)
        {
            _event.InsertOne(eventObject);
            return eventObject;
        }

        // public void Update(string id, EventGroupOverview eventGroupOverviewIn) =>
        //     _eventGroupOverview.ReplaceOne(eventGroupOverview => eventGroupOverview.IddB == id, eventGroupOverviewIn);

        // public void Remove(EventGroupOverview eventGroupOverviewIn) =>
        //     _eventGroupOverview.DeleteOne(eventGroupOverview => eventGroupOverview.IddB == eventGroupOverviewIn.IddB);

        // public void Remove(string id) => 
        //     _eventGroupOverview.DeleteOne(eventGroupOverview => eventGroupOverview.IddB == id);

        public void RemoveAll() => 
            _event.DeleteMany(new BsonDocument());
    }
}