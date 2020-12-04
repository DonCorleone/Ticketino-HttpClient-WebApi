using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Kinderkultur_TicketinoClient.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IHttpClientFactory httpClientFactory;

        public MergeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync(){
            await ProcessRepositories(new HttpClient(), configuration);
            return base.Ok();
        }

        private static async Task ProcessRepositories(HttpClient client, IConfiguration configuration)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencode"));

            var url = "https://accounts.ticketino.com/connect/token";

            var dict = new List<KeyValuePair<string, string>>();       
            dict.Add(new KeyValuePair<string, string>("grant_type", "password"));
            dict.Add(new KeyValuePair<string, string>("username", configuration["ticketino-auth:username"]));
            dict.Add(new KeyValuePair<string, string>("password", configuration["ticketino-auth:password"]));
            dict.Add(new KeyValuePair<string, string>("scope", "api"));            
            dict.Add(new KeyValuePair<string, string>("client_id", "public-access-api"));
            dict.Add(new KeyValuePair<string, string>("client_secret", "secret"));

            HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(dict)).Result;

            var token = response.Content.ReadAsStringAsync().Result;
            Console.Write(token);
        }
    }
}