using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Kinderkultur_TicketinoClient.Contracts
{
    public interface IEventOverviewService
    {
        List<EventOverview> Get();
        EventOverview Get(int id);
        EventOverview Create(EventOverview eventOverview);
        
        void Update(int id, EventOverview eventOverviewIn);
 
        void Upsert(int id, EventOverview eventOverviewIn);
        // void Remove(EventGroupOverview eventGroupOverviewIn);
        // void Remove(string id);
        void RemoveAll();
    }
}