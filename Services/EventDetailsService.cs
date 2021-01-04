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
    public class EventDetailsService : IEventDetailsService
    {

        private readonly IMongoCollection<EventDetails> _event;

        public EventDetailsService(IEventDatabaseSettings settings, IConfiguration configuration)
        {
            // local var client = new MongoClient($"mongodb://{configuration["mongodb-username"]}:{configuration["mongodb-password"]}@192.168.178.12:27017");
            var client = new MongoClient($"mongodb+srv://ticketinoClient:9sdQuDmQwnvbla4j@cluster0.x3l7f.mongodb.net/{settings.DatabaseName}?retryWrites=true&w=majority");
         
            var database = client.GetDatabase(settings.DatabaseName);

            _event = database.GetCollection<EventDetails>(settings.EventDetailsCollectionName);
        }

        public List<EventDetails> Get() =>
            _event.Find(eventDetails => true).ToList();

        public EventDetails Get(int id) =>
            _event.Find<EventDetails>(eventDetails => eventDetails.id == id).FirstOrDefault();

        public EventDetails Create(EventDetails eventDetails)
        {
            _event.InsertOne(eventDetails);
            return eventDetails;
        }

        public void Update(int id, EventDetails eventDetailsIn) =>
            _event.ReplaceOne(eventOverview => eventOverview.id == id, eventDetailsIn, new ReplaceOptions(){
                IsUpsert = true
            });

        public void Upsert(int id, EventDetails eventDetailsIn){
            
            var found = this.Get(id);
            if (found != null){
                this.Update(id, eventDetailsIn);
            }else{
                this.Create(eventDetailsIn);
            }
        }
        // public void Remove(EventGroupOverview eventGroupOverviewIn) =>
        //     _eventGroupOverview.DeleteOne(eventGroupOverview => eventGroupOverview.IddB == eventGroupOverviewIn.IddB);

        // public void Remove(string id) => 
        //     _eventGroupOverview.DeleteOne(eventGroupOverview => eventGroupOverview.IddB == id);

        public void RemoveAll() => 
            _event.DeleteMany(new BsonDocument());
    }
}