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
        private readonly IMergeService mergeService;
        private readonly IEventGroupOverviewService eventGroupOverviewService;
        private readonly IEventGroupService eventGroupService;
        private readonly IEventGroupEventService eventGroupEventService;
        private readonly IEventOverviewService eventOverviewService;
        private readonly IEventService eventService;
        private readonly IEventInfoService eventInfoService;
        private readonly IEventDetailsService eventDetailsService;

        public MergeController(
            IMergeService mergeService, 
            IEventGroupOverviewService eventGroupOverviewService, 
            IEventGroupService eventGroupService,
            IEventGroupEventService eventGroupEventService,
            IEventOverviewService eventOverviewService,
            IEventService eventService,
            IEventInfoService eventInfoService,
            IEventDetailsService eventDetailsService)
        {
            this.mergeService = mergeService;
            this.eventGroupOverviewService = eventGroupOverviewService;
            this.eventGroupService = eventGroupService;
            this.eventGroupEventService = eventGroupEventService;
            this.eventOverviewService = eventOverviewService;
            this.eventService = eventService;
            this.eventInfoService = eventInfoService;
            this.eventDetailsService = eventDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            HttpClient client = new HttpClient();

            var token = await mergeService.GetTokenAsync(client);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");

            var organizerz = await mergeService.GetOrganizers(client);
            var eventOverviews = await mergeService.GetEventGroupOverviews(client, organizerz[0].id.ToString());

            eventGroupOverviewService.RemoveAll();
            eventGroupService.RemoveAll();
            eventGroupEventService.RemoveAll();
            eventOverviewService.RemoveAll();            
            eventInfoService.RemoveAll();
            eventService.RemoveAll();       
            eventInfoService.RemoveAll();
            eventDetailsService.RemoveAll();

            foreach (var eventGroupOverview in eventOverviews.eventGroups)
            {
                eventGroupOverviewService.Create(eventGroupOverview);
                
                EventGroup eventGroup = await mergeService.GetEventGroup(client, eventGroupOverview.id.ToString());

                eventGroupService.Create(eventGroup);
                
                EventOverviewList eventOverviewList = await mergeService.GetEventOverviews(client, eventGroup.id.ToString());

                EventGroupEvents newEventGroupEvent = new EventGroupEvents(){
                    events = eventOverviewList.events,
                    eventGroupId = eventGroup.id
                };

                eventGroupEventService.Create(newEventGroupEvent);

                foreach (var eventOverview in eventOverviewList.events)
                {
                    eventOverviewService.Create(eventOverview);

                    EventObject eventObject = await mergeService.GetEvent(client, eventOverview.id.ToString());

                    eventDetailsService.Create(eventObject.eventDetails);

                    EventInfos eventInfos = await mergeService.GetEventInfos(client, eventOverview.id.ToString());

                    EventInfo eventInfo = eventInfos.eventInfos.Find(p => p.languageIsoCode == "de");

                    eventInfoService.Create(eventInfo);
                }
            }
            return base.Ok();
        }
    }
}