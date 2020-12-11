using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Kinderkultur_TicketinoClient.Contracts;
using Kinderkultur_TicketinoClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Kinderkultur_TicketinoClient.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        private readonly IMergeService mergeService;

        public MergeController(IMergeService mergeService)
        {
            this.mergeService = mergeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(){

            HttpClient client = new HttpClient();

            var token = await mergeService.GetTokenAsync(client);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));       

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");

            var organizerz = await mergeService.GetOrganizers(client);
            var eventGroupInfos = await mergeService.GetEventGroupInfos(client, organizerz[0].id.ToString());

            foreach (var eventGroupInfo in eventGroupInfos.eventGroups)
            {
                var EventGroup = await mergeService.GetEventGroup(client, eventGroupInfo.id.ToString());
            }
            return base.Ok();
        }
    }
}