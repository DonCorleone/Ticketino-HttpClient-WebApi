using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Kinderkultur_TicketinoClient.Services
{
    public static class BaseUrlCaller<T>
    {
        public static async Task<T> GetFromBaseUrl(IConfiguration configuration, HttpClient client, string urlParam)
        {        
            var url = configuration.GetValue<String>("Base_URL");
            
            url = url + urlParam;

            HttpResponseMessage responseResult = client.GetAsync(url).Result;

            return await JsonSerializer.DeserializeAsync<T>(await responseResult.Content.ReadAsStreamAsync());
        }
    }
}