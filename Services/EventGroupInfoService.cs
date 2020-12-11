using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace Kinderkultur_TicketinoClient.Services
{
    public class EventGroupInfoService
    {

        private readonly IMongoCollection<EventGroupOverview> _eventGroupInfo;

        public EventGroupInfoService(IEventDatabaseSettings settings, IConfiguration configuration)
        {
            var client = new MongoClient($"mongodb://{configuration["mongodb-username"]}:{configuration["mongodb-password"]}@192.168.178.12:27017");
            var database = client.GetDatabase(settings.DatabaseName);

            _eventGroupInfo = database.GetCollection<EventGroupOverview>(settings.EventGroupInfoCollectionName);
        }

        public List<EventGroupOverview> Get() =>
            _eventGroupInfo.Find(eventGroupInfo => true).ToList();

        public EventGroupOverview Get(string id) =>
            _eventGroupInfo.Find<EventGroupOverview>(eventGroupInfo => eventGroupInfo.IddB == id).FirstOrDefault();

        public EventGroupOverview Create(EventGroupOverview eventGroupInfo)
        {
            _eventGroupInfo.InsertOne(eventGroupInfo);
            return eventGroupInfo;
        }

        public void Update(string id, EventGroupOverview eventGroupInfoIn) =>
            _eventGroupInfo.ReplaceOne(eventGroupInfo => eventGroupInfo.IddB == id, eventGroupInfoIn);

        public void Remove(EventGroupOverview eventGroupInfoIn) =>
            _eventGroupInfo.DeleteOne(eventGroupInfo => eventGroupInfo.IddB == eventGroupInfoIn.IddB);

        public void Remove(string id) => 
            _eventGroupInfo.DeleteOne(eventGroupInfo => eventGroupInfo.IddB == id);

        public void RemoveAll() => 
            _eventGroupInfo.DeleteMany(new BsonDocument());
    }
}