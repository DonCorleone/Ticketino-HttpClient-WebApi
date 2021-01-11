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
        private readonly IEventGroupOverviewService eventGroupOverviewService;
        private readonly IEventGroupService eventGroupService;
        private readonly IEventGroupEventService eventGroupEventService;
        private readonly IEventEventGroupUsageService eventEventGroupUsageService;
        private readonly IEventGroupEventDetailService eventGroupEventDetailService;
        private readonly IEventOverviewService eventOverviewService;
        private readonly IEventService eventService;
        private readonly IEventInfoService eventInfoService;
        private readonly IEventDetailsService eventDetailsService;

        public MergeController(
            ITicketinoService ticketinoService, 
            IEventGroupOverviewService eventGroupOverviewService, 
            IEventGroupService eventGroupService,
            IEventGroupEventService eventGroupEventService,
            IEventEventGroupUsageService eventEventGroupUsageService,
            IEventGroupEventDetailService eventGroupEventDetailService,
            IEventOverviewService eventOverviewService,
            IEventService eventService,
            IEventInfoService eventInfoService,
            IEventDetailsService eventDetailsService)
        {
            this.ticketinoService = ticketinoService;
            this.eventGroupOverviewService = eventGroupOverviewService;
            this.eventGroupService = eventGroupService;
            this.eventGroupEventService = eventGroupEventService;
            this.eventEventGroupUsageService = eventEventGroupUsageService;
            this.eventGroupEventDetailService = eventGroupEventDetailService;
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
         
            eventGroupOverviewService.RemoveAll();
            eventGroupService.RemoveAll();
            eventGroupEventService.RemoveAll();
            eventEventGroupUsageService.RemoveAll();
            eventGroupEventDetailService.RemoveAll();
            eventOverviewService.RemoveAll();            
            eventInfoService.RemoveAll();
            eventService.RemoveAll();       
            eventInfoService.RemoveAll();
            eventDetailsService.RemoveAll();

            foreach (var eventGroupOverview in eventOverviews.eventGroups)
            {
                eventGroupOverviewService.Create(eventGroupOverview);
                
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
                    EventInfo eventInfo = eventInfos.eventInfos.Find(p => p.languageIsoCode == "de");
                    
                    eventObject.eventDetails.eventInfos.Add(eventInfo);
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
                    eventInfoService.Upsert(eventInfo.id, eventInfo);
                }

                var newEventGroupEventDetail = new EventGroupEventDetails(){
                    eventGroupId = eventGroup.id,
                    events = eventDetails
                };

                eventGroupEventDetailService.Create(newEventGroupEventDetail);
            }
            return base.Ok();
        }
    }
}