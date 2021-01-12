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
    public class EventGroupService : IEventGroupService
    {

        private readonly IMongoCollection<EventGroup> _eventGroup;

        public EventGroupService(IEventDatabaseSettings settings, IConfiguration configuration)
        {
            // local var client = new MongoClient($"mongodb://{configuration["mongodb-username"]}:{configuration["mongodb-password"]}@192.168.178.12:27017");
            var client = new MongoClient($"mongodb+srv://ticketinoClient:9sdQuDmQwnvbla4j@cluster0.x3l7f.mongodb.net/{settings.DatabaseName}?retryWrites=true&w=majority");
            
            var database = client.GetDatabase(settings.DatabaseName);

            _eventGroup = database.GetCollection<EventGroup>(settings.EventGroupCollectionName);
        }

        public List<EventGroup> Get() =>
            _eventGroup.Find(eventGroup => true).ToList();

        public EventGroup Create(EventGroup eventGroup)
        {
            _eventGroup.InsertOne(eventGroup);
            return eventGroup;
        }

        public EventGroup Get(int id) =>
            _eventGroup.Find<EventGroup>(eventGroup => eventGroup.id == id).FirstOrDefault();

        public void Update(int id, EventGroup eventGroupIn) =>
            _eventGroup.ReplaceOne(eventGroup => eventGroup.id == id, eventGroupIn, new ReplaceOptions(){
                IsUpsert = true
            });
 
        public void Upsert(int id, EventGroup eventGroupIn){
            var found = this.Get(id);
            if (found != null){
                this.Update(id, eventGroupIn);
            }else{
                this.Create(eventGroupIn);
            }
        }
        public void RemoveAll() => 
            _eventGroup.DeleteMany(new BsonDocument());
    }
}