using Kinderkultur_TicketinoClient.Contracts;
using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kinderkultur_TicketinoClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGroupOverviewsController : ControllerBase
    {
        private readonly IEventGroupOverviewService _eventGroupOverviewService;

        public EventGroupOverviewsController(IEventGroupOverviewService eventGroupOverviewService)
        {
            _eventGroupOverviewService = eventGroupOverviewService;
        }

        [HttpGet]
        public ActionResult<List<EventGroupOverview>> Get() =>
            _eventGroupOverviewService.Get();

        // [HttpGet("{id:length(24)}", Name = "GetEventGroupOverview")]
        // public ActionResult<EventGroupOverview> Get(string id)
        // {
        //     var eventGroupOverview = _eventGroupOverviewService.Get(id);

        //     if (eventGroupOverview == null)
        //     {
        //         return NotFound();
        //     }

        //     return eventGroupOverview;
        // }

        [HttpPost]
        public ActionResult<EventGroupOverview> Create(EventGroupOverview eventGroupOverview)
        {
            _eventGroupOverviewService.Create(eventGroupOverview);

            return CreatedAtRoute("GetEventGroupOverview", new { id = eventGroupOverview.IddB.ToString() }, eventGroupOverview);
        }

        // [HttpPut("{id:length(24)}")]
        // public IActionResult Update(string id, EventGroupOverview eventGroupOverviewIn)
        // {
        //     var eventGroupOverview = _eventGroupOverviewService.Get(id);

        //     if (eventGroupOverview == null)
        //     {
        //         return NotFound();
        //     }

        //     _eventGroupOverviewService.Update(id, eventGroupOverviewIn);

        //     return NoContent();
        // }

        // [HttpDelete("{id:length(24)}")]
        // public IActionResult Delete(string id)
        // {
        //     var eventGroupOverview = _eventGroupOverviewService.Get(id);

        //     if (eventGroupOverview == null)
        //     {
        //         return NotFound();
        //     }

        //     _eventGroupOverviewService.Remove(eventGroupOverview.IddB);

        //     return NoContent();
        // }

        [HttpGet]
        [Route("RemoveAll")]
        public IActionResult RemoveAll (){
            _eventGroupOverviewService.RemoveAll();
            return NoContent();
        }
    }
}