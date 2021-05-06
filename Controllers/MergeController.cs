using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kinderkultur_TicketinoClient.Contracts;
using Kinderkultur_TicketinoClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kinderkultur_TicketinoClient.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        private readonly ITicketinoService ticketinoService;
        private readonly IEventDetailsService eventDetailsService;

        public MergeController(
                ITicketinoService ticketinoService,
                IEventDetailsService eventDetailsService
            )
        {
            this.ticketinoService = ticketinoService;
            this.eventDetailsService = eventDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            HttpClient client = new HttpClient();

            try
            {
                var token = await ticketinoService.GetTokenAsync(client);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("text/plain"));

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");
            }
            catch (System.Exception ex)
            {
                return base.Problem(ex.ToString());
            }

            try
            {
                var organizerz = await ticketinoService.GetOrganizers(client);
                var eventOverviews = await ticketinoService.GetEventIdDistributors(client, organizerz[0].id.ToString());

                foreach (var eventOverview in eventOverviews.events)
                {
                    EventDetails eventDetail = await ticketinoService.GetEvent(client, eventOverview.id.ToString());
                    eventDetailsService.Upsert(eventDetail.id, eventDetail);
                }

                return base.Ok();
            }
            catch (System.Exception ex)
            {
                return base.Problem(ex.ToString());
            }
        }
    }
}