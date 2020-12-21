using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Kinderkultur_TicketinoClient.Contracts;
using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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

        public MergeController(
            IMergeService mergeService, 
            IEventGroupOverviewService eventGroupOverviewService, 
            IEventGroupService eventGroupService,
            IEventGroupEventService eventGroupEventService,
            IEventOverviewService eventOverviewService,
            IEventService eventService)
        {
            this.mergeService = mergeService;
            this.eventGroupOverviewService = eventGroupOverviewService;
            this.eventGroupService = eventGroupService;
            this.eventGroupEventService = eventGroupEventService;
            this.eventOverviewService = eventOverviewService;
            this.eventService = eventService;
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
            eventService.RemoveAll();

            foreach (var eventGroupOverview in eventOverviews.eventGroups)
            {
                eventGroupOverviewService.Create(eventGroupOverview);
                
                var eventGroup = await mergeService.GetEventGroup(client, eventGroupOverview.id.ToString());

                eventGroupService.Create(eventGroup);
                
                var eventInfoList = await mergeService.GetEventOverviews(client, eventGroup.id.ToString());

                var newEventGroupEvent = new EventGroupEvents(){
                    events = eventInfoList.events,
                    eventGroupId = eventGroup.id
                };

                eventGroupEventService.Create(newEventGroupEvent);

                foreach (var eventInfo in eventInfoList.events)
                {
                    eventOverviewService.Create(eventInfo);

                    var eventObject = await mergeService.GetEvent(client, eventInfo.id.ToString());

                    eventService.Create(eventObject);
                }
            }
            return base.Ok();
        }
    }
}