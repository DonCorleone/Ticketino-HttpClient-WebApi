using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace Kinderkultur_TicketinoClient.Services
{
    public class EventGroupInfoService
    {

        private readonly IMongoCollection<EventGroupInfo> _eventGroupInfo;

        public EventGroupInfoService(IEventDatabaseSettings settings, IConfiguration configuration)
        {
            var client = new MongoClient($"mongodb://{configuration["mongodb-username"]}:{configuration["mongodb-password"]}@192.168.178.12:27017");
            var database = client.GetDatabase(settings.DatabaseName);

            _eventGroupInfo = database.GetCollection<EventGroupInfo>(settings.EventGroupInfoCollectionName);
        }

        public List<EventGroupInfo> Get() =>
            _eventGroupInfo.Find(eventGroupInfo => true).ToList();

        public EventGroupInfo Get(string id) =>
            _eventGroupInfo.Find<EventGroupInfo>(eventGroupInfo => eventGroupInfo.IddB == id).FirstOrDefault();

        public EventGroupInfo Create(EventGroupInfo eventGroupInfo)
        {
            _eventGroupInfo.InsertOne(eventGroupInfo);
            return eventGroupInfo;
        }

        public void Update(string id, EventGroupInfo eventGroupInfoIn) =>
            _eventGroupInfo.ReplaceOne(eventGroupInfo => eventGroupInfo.IddB == id, eventGroupInfoIn);

        public void Remove(EventGroupInfo eventGroupInfoIn) =>
            _eventGroupInfo.DeleteOne(eventGroupInfo => eventGroupInfo.IddB == eventGroupInfoIn.IddB);

        public void Remove(string id) => 
            _eventGroupInfo.DeleteOne(eventGroupInfo => eventGroupInfo.IddB == id);
    }
}