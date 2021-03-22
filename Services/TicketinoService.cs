using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Kinderkultur_TicketinoClient.Contracts;
using Kinderkultur_TicketinoClient.Models;
using Microsoft.Extensions.Configuration;

namespace Kinderkultur_TicketinoClient.Services
{
    public class TicketinoService : ITicketinoService
    {
   
        private readonly IConfiguration configuration;

        public TicketinoService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public async Task<Token> GetTokenAsync(HttpClient client){

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencode"));

            var url = configuration.GetValue<String>("token_Url");

            var dict = new List<KeyValuePair<string, string>>();       
            dict.Add(new KeyValuePair<string, string>("grant_type", "password"));
            dict.Add(new KeyValuePair<string, string>("username", configuration["ticketino-auth:username"]));
            dict.Add(new KeyValuePair<string, string>("password", configuration["ticketino-auth:password"]));
            dict.Add(new KeyValuePair<string, string>("scope", "api"));            
            dict.Add(new KeyValuePair<string, string>("client_id", "public-access-api"));
            dict.Add(new KeyValuePair<string, string>("client_secret", "secret"));

            HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(dict)).Result;

            return await JsonSerializer.DeserializeAsync<Token>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<IList<Organizer>> GetOrganizers(HttpClient client){

            var url = "/LoginUser/Organizers";

            return await BaseUrlCaller<IList<Organizer>>.GetFromBaseUrl(configuration, client, url);
        }

        public async Task<EventGroupOverviewList> GetEventGroupOverviews(HttpClient client, string organizerId)
        {        
            var url = "/EventGroups?organizerId=" + organizerId;

            return await BaseUrlCaller<EventGroupOverviewList>.GetFromBaseUrl(configuration, client, url);
        }

        public async Task<EventGroup> GetEventGroup(HttpClient client, string eventGroupId)
        {        
            var url = "/EventGroup/" + eventGroupId;

            return await BaseUrlCaller<EventGroup>.GetFromBaseUrl(configuration, client, url);
        }

        public async Task<EventOverviewList> GetEventOverviews(HttpClient client, string eventGroupId)
        {           
            var url = $"/EventGroup/Events?eventGroupId={eventGroupId}&languageCode=de";

            return await BaseUrlCaller<EventOverviewList>.GetFromBaseUrl(configuration, client, url);
        }

        public async Task<EventDetails> GetEvent(HttpClient client, string eventId)
        {        
            var url = $"/Event/" + eventId;

            return await BaseUrlCaller<EventDetails>.GetFromBaseUrl(configuration, client, url);
        }

        public async Task<EventInfos> GetEventInfos(HttpClient client, string eventId)
        {
            var url = $"/Event/{eventId}/EventInfos";

            return await BaseUrlCaller<EventInfos>.GetFromBaseUrl(configuration, client, url);
        }
    }
}