using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Kinderkultur_TicketinoClient.Contracts
{
    public interface IEventDetailsService
    {
        List<EventDetails> Get();
        EventDetails Get(int id);
        EventDetails Create(EventDetails eventDetails);
        void Update(int id, EventDetails eventDetailsIn);
        void Upsert(int id, EventDetails eventDetailsIn);
        void RemoveAll();
    }
}