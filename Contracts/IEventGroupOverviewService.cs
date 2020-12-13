using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Kinderkultur_TicketinoClient.Contracts
{
    public interface IEventGroupOverviewService
    {
        List<EventGroupOverview> Get();
        EventGroupOverview Get(string id);
        EventGroupOverview Create(EventGroupOverview eventGroupOverview);
        void Update(string id, EventGroupOverview eventGroupOverviewIn);
        void Remove(EventGroupOverview eventGroupOverviewIn);
        void Remove(string id);
        void RemoveAll();
    }
}