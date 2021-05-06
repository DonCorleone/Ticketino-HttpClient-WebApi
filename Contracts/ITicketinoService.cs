using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Kinderkultur_TicketinoClient.Models;
using Microsoft.Extensions.Configuration;

namespace Kinderkultur_TicketinoClient.Contracts
{
    public interface ITicketinoService
    {
        Task<Token> GetTokenAsync(HttpClient client);
        Task<IList<Organizer>> GetOrganizers(HttpClient client);
        Task<EventIdDistributors> GetEventIdDistributors(HttpClient client, string organizerId);
        Task<EventDetails> GetEvent(HttpClient client, string eventId);
    }
}