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
    public class EventEventGroupUsageService : IEventEventGroupUsageService
    {
        private readonly IMongoCollection<EventEventGroupUsage> _eventEventGroupUsage;

        public EventEventGroupUsageService(IEventDatabaseSettings settings, IConfiguration configuration)
        {
            var client = new MongoClient($"mongodb+srv://ticketinoClient:9sdQuDmQwnvbla4j@cluster0.x3l7f.mongodb.net/{settings.DatabaseName}?retryWrites=true&w=majority");
            
            var database = client.GetDatabase(settings.DatabaseName);

            _eventEventGroupUsage = database.GetCollection<EventEventGroupUsage>(settings.EventEventGroupUsageCollectionName);
        }

        public List<EventEventGroupUsage> Get() =>
            _eventEventGroupUsage.Find(EventEventGroupUsage => true).ToList();

        public EventEventGroupUsage Create(EventEventGroupUsage eventEventGroupUsage)
        {
            _eventEventGroupUsage.InsertOne(eventEventGroupUsage);
            return eventEventGroupUsage;
        }

        public void RemoveAll() => 
            _eventEventGroupUsage.DeleteMany(new BsonDocument());
    }
}