using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Kinderkultur_TicketinoClient.Contracts
{
    public interface IEventInfoService
    {      
        List<EventInfo> Get();
        EventInfo Get(int id);
        EventInfo Create(EventInfo eventInfo);
        void Update(int id, EventInfo eventInfoIn);
        void Upsert(int id, EventInfo eventInfoIn);
        void RemoveAll();
    }
}