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
        Task<IList<Organizer>> GetOrganizers(HttpClient client, string token);
    }
}