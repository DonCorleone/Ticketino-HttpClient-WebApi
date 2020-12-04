using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Kinderkultur_TicketinoClient.Contracts;
using Kinderkultur_TicketinoClient.Models;
using Microsoft.Extensions.Configuration;

namespace Kinderkultur_TicketinoClient
{
    public class MergeService : IMergeService
    {
        private readonly IConfiguration configuration;

        public MergeService(IConfiguration configuration)
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

        public async Task<IList<Organizer>> GetOrganizers(HttpClient client, string token){

            var url = configuration.GetValue<String>("Base_URL");
            
            url = url + "/LoginUser/Organizers";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));       

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage responseResult = client.GetAsync(url).Result;

            return await JsonSerializer.DeserializeAsync<IList<Organizer>>(await responseResult.Content.ReadAsStreamAsync());
        }
    }
}