using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Kinderkultur_TicketinoClient.Models;
using Microsoft.Extensions.Configuration;

namespace Kinderkultur_TicketinoClient.Contracts
{
    public interface IMergeService
    {
        Task<Token> GetTokenAsync(HttpClient client);
        Task<IList<Organizer>> GetOrganizers(HttpClient client);
        Task<EventGroupOverviewList> GetEventGroupOverviews(HttpClient client, string organizerId);
        Task<EventGroup> GetEventGroup(HttpClient client, string eventGroupId);
        Task<EventOverviewList> GetEventOverviews(HttpClient client, string eventGroupId);
        Task<EventObject> GetEvent(HttpClient client, string eventId);
        Task<EventInfos> GetEventInfos(HttpClient client, string eventId);
    }
}