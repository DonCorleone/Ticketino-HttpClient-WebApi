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
    public class EventInfoService : IEventInfoService
    {

        private readonly IMongoCollection<EventInfo> _eventInfo;

        public EventInfoService(IEventDatabaseSettings settings, IConfiguration configuration)
        {
            // local var client = new MongoClient($"mongodb://{configuration["mongodb-username"]}:{configuration["mongodb-password"]}@192.168.178.12:27017");
            // atlas 
            var client = new MongoClient($"mongodb+srv://ticketinoClient:9sdQuDmQwnvbla4j@cluster0.x3l7f.mongodb.net/{settings.DatabaseName}?retryWrites=true&w=majority");
         
            var database = client.GetDatabase(settings.DatabaseName);

            _eventInfo = database.GetCollection<EventInfo>(settings.EventInfoCollectionName);
        }

        public List<EventInfo> Get() =>
            _eventInfo.Find(eventInfo => true).ToList();

        public EventInfo Get(int id) =>
            _eventInfo.Find<EventInfo>(eventInfo => eventInfo.id == id).FirstOrDefault();

        public EventInfo Create(EventInfo eventInfo)
        {
            _eventInfo.InsertOne(eventInfo);
            return eventInfo;
        }
        public void Update(int id, EventInfo eventInfoIn) =>
            _eventInfo.ReplaceOne(eventInfo => eventInfo.id == id, eventInfoIn, new ReplaceOptions(){ IsUpsert = true });

        public void Upsert(int id, EventInfo eventInfoIn){
            
            var found = this.Get(id);
            if (found != null){
                this.Update(id, eventInfoIn);
            }else{
                this.Create(eventInfoIn);
            }
        }

        // public void Remove(EventGroupOverview eventGroupOverviewIn) =>
        //     _eventGroupOverview.DeleteOne(eventGroupOverview => eventGroupOverview.IddB == eventGroupOverviewIn.IddB);

        // public void Remove(string id) => 
        //     _eventGroupOverview.DeleteOne(eventGroupOverview => eventGroupOverview.IddB == id);

        public void RemoveAll() => 
            _eventInfo.DeleteMany(new BsonDocument());
    }
}