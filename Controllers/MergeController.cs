using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Kinderkultur_TicketinoClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Kinderkultur_TicketinoClient.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public MergeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(){
            HttpClient client = new HttpClient();
            var token = await PrcessToken(client, configuration);
            var organizer = await ProcessOrgnizer(client, configuration, token.access_token);
            return base.Ok();
        }

        private static async Task<Token> PrcessToken(HttpClient client, IConfiguration configuration)
        {
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

        private static async Task<IList<Organizer>> ProcessOrgnizer(HttpClient client, IConfiguration configuration, string token){

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