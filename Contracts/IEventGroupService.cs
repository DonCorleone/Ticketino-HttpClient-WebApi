using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Kinderkultur_TicketinoClient.Contracts
{
    public interface IEventGroupService
    {
        EventGroup Create(EventGroup eventGroup);
        List<EventGroup> Get();
        EventGroup Get(int id);
        void Update(int id, EventGroup eventGroupIn);
        void Upsert(int id, EventGroup eventGroupIn);
        void RemoveAll();
    }
}