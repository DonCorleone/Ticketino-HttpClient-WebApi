using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Kinderkultur_TicketinoClient.Contracts
{
    public interface IEventGroupEventService
    {
        List<EventGroupEvents> Get();
        //  EventGroupOverview Get(string id);
        EventGroupEvents Create(EventGroupEvents eventGroupEvents);
        // void Update(string id, EventGroupOverview eventGroupOverviewIn);
        // void Remove(EventGroupOverview eventGroupOverviewIn);
        // void Remove(string id);
        void RemoveAll();
    }
}