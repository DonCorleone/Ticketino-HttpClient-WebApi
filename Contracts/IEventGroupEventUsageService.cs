using Kinderkultur_TicketinoClient.Models;
using System.Collections.Generic;

namespace Kinderkultur_TicketinoClient.Contracts
{
    public interface IEventEventGroupUsageService
    {
        List<EventEventGroupUsage> Get();
        EventEventGroupUsage Create(EventEventGroupUsage eventEventGroupUsage);

        void RemoveAll();
    }
}