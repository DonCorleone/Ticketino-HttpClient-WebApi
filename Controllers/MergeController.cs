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
        private readonly IEventGroupService eventGroupService;
        private readonly IEventGroupEventService eventGroupEventService;
        private readonly IEventEventGroupUsageService eventEventGroupUsageService;
        private readonly IEventOverviewService eventOverviewService;
        private readonly IEventService eventService;
        private readonly IEventInfoService eventInfoService;
        private readonly IEventDetailsService eventDetailsService;

        public MergeController(
            ITicketinoService ticketinoService, 
            IEventGroupService eventGroupService,
            IEventGroupEventService eventGroupEventService,
            IEventEventGroupUsageService eventEventGroupUsageService,
            IEventOverviewService eventOverviewService,
            IEventService eventService,
            IEventInfoService eventInfoService,
            IEventDetailsService eventDetailsService)
        {
            this.ticketinoService = ticketinoService;
            this.eventGroupService = eventGroupService;
            this.eventGroupEventService = eventGroupEventService;
            this.eventEventGroupUsageService = eventEventGroupUsageService;
            this.eventOverviewService = eventOverviewService;
            this.eventService = eventService;
            this.eventInfoService = eventInfoService;
            this.eventDetailsService = eventDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            HttpClient client = new HttpClient();

            var token = await ticketinoService.GetTokenAsync(client);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");

            var organizerz = await ticketinoService.GetOrganizers(client);
            var eventOverviews = await ticketinoService.GetEventGroupOverviews(client, organizerz[0].id.ToString());
             
            eventGroupService.RemoveAll();
            eventGroupEventService.RemoveAll();
            eventEventGroupUsageService.RemoveAll();
            eventOverviewService.RemoveAll();        
            eventService.RemoveAll();           
                    
            eventInfoService.RemoveAll();
            eventDetailsService.RemoveAll();

            foreach (var eventGroupOverview in eventOverviews.eventGroups)
            {
                
                EventGroup eventGroup = await ticketinoService.GetEventGroup(client, eventGroupOverview.id.ToString());

                eventGroupService.Create(eventGroup);
                
                EventOverviewList eventOverviewList = await ticketinoService.GetEventOverviews(client, eventGroup.id.ToString());

                EventGroupEvents newEventGroupEvent = new EventGroupEvents(){
                    events = eventOverviewList.events,
                    eventGroupId = eventGroup.id
                };

                eventGroupEventService.Create(newEventGroupEvent);

                var eventDetails = new List<EventDetails>();

                foreach (var eventOverview in eventOverviewList.events)
                {
                    eventOverviewService.Upsert(eventOverview.id, eventOverview);

                    EventObject eventObject = await ticketinoService.GetEvent(client, eventOverview.id.ToString());

                    eventObject.eventDetails.eventInfos.Clear();

                    EventInfos eventInfos = await ticketinoService.GetEventInfos(client, eventOverview.id.ToString());
                   // EventInfo eventInfo = eventInfos.eventInfos.Find(p => p.languageIsoCode == "de" || p.languageIsoCode == null);

                    foreach (var eventInfo in eventInfos.eventInfos)
                    {
                        eventObject.eventDetails.eventInfos.Add(eventInfo);
                        eventInfoService.Upsert(eventInfo.id, eventInfo);
                    }

                    eventDetails.Add(eventObject.eventDetails); 

                    if(eventObject.eventDetails.facebookPixelId != ""){
                        var eventGroupUsage = new EventEventGroupUsage(){
                            eventId = eventObject.eventDetails.id,
                            eventGroupId = eventGroup.id,
                            usage = eventObject.eventDetails.facebookPixelId
                        };

                        eventEventGroupUsageService.Create(eventGroupUsage);
                    }

                    if(eventObject.eventDetails.googleAnalyticsTracker != ""){
                        var eventGroupUsage = new EventEventGroupUsage(){
                            eventId = eventObject.eventDetails.id,
                            eventGroupId = eventGroup.id,
                            usage = eventObject.eventDetails.googleAnalyticsTracker
                        };

                        eventEventGroupUsageService.Create(eventGroupUsage);
                    }

                    eventDetailsService.Upsert(eventObject.eventDetails.id, eventObject.eventDetails);

                 }
            }
            return base.Ok();
        }
    }
}