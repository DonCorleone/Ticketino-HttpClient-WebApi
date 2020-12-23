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
    public class EventOverviewService : IEventOverviewService
    {

        private readonly IMongoCollection<EventOverview> _eventOverview;

        public EventOverviewService(IEventDatabaseSettings settings, IConfiguration configuration)
        {
            // local var client = new MongoClient($"mongodb://{configuration["mongodb-username"]}:{configuration["mongodb-password"]}@192.168.178.12:27017");
            var client = new MongoClient($"mongodb+srv://ticketinoClient:9sdQuDmQwnvbla4j@cluster0.x3l7f.mongodb.net/{settings.DatabaseName}?retryWrites=true&w=majority");
         
            var database = client.GetDatabase(settings.DatabaseName);

            _eventOverview = database.GetCollection<EventOverview>(settings.EventOverviewCollectionName);
        }

        public List<EventOverview> Get() =>
            _eventOverview.Find(eventOverview => true).ToList();

        // public EventGroupOverview Get(string id) =>
        //     _eventGroupOverview.Find<EventGroupOverview>(eventGroupOverview => eventGroupOverview.IddB == id).FirstOrDefault();

        public EventOverview Create(EventOverview eventOverview)
        {
            _eventOverview.InsertOne(eventOverview);
            return eventOverview;
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