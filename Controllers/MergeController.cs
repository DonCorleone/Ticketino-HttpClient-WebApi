using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kinderkultur_TicketinoClient.Contracts;
using Kinderkultur_TicketinoClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

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
                var eventOverviews = await ticketinoService.GetEventGroupOverviews(client, organizerz[0].id.ToString());

                foreach (var eventGroupOverview in eventOverviews)
                {
                    EventOverviewList eventOverviewList = await ticketinoService.GetEventOverviews(client, eventGroupOverview.id.ToString());  

                    foreach (var eventOverview in eventOverviewList.events)
                    {
                        EventDetails eventDetail = await ticketinoService.GetEvent(client, eventOverview.id.ToString());

                        EventInfos eventInfos =
                            await ticketinoService.GetEventInfos(client, eventOverview.id.ToString());
                        
                        eventDetail.eventInfos = eventInfos.eventInfos;

                        TicketTypes ticketTypes =
                            await ticketinoService.GetTicketTypes(client, eventOverview.id.ToString());
                        
                        foreach (TicketType ticketType in ticketTypes.ticketTypes)
                        {
                            var ticketTypeInfos = await ticketinoService.GetTicketTypeInfos(client, ticketType.id.ToString());
                            ticketType.ticketTypeInfos = ticketTypeInfos.ticketTypeInfos;
                        }
                        
                        eventDetail.ticketTypes = ticketTypes.ticketTypes;
                        
                        eventDetailsService.Upsert(eventDetail.id, eventDetail);
                    }
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