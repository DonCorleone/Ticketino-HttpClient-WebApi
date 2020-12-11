using Kinderkultur_TicketinoClient.Models;
using Kinderkultur_TicketinoClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kinderkultur_TicketinoClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGroupInfosController : ControllerBase
    {
        private readonly EventGroupInfoService _eventGroupInfoService;

        public EventGroupInfosController(EventGroupInfoService eventGroupInfoService)
        {
            _eventGroupInfoService = eventGroupInfoService;
        }

        [HttpGet]
        public ActionResult<List<EventGroupOverview>> Get() =>
            _eventGroupInfoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetEventGroupInfo")]
        public ActionResult<EventGroupOverview> Get(string id)
        {
            var eventGroupInfo = _eventGroupInfoService.Get(id);

            if (eventGroupInfo == null)
            {
                return NotFound();
            }

            return eventGroupInfo;
        }

        [HttpPost]
        public ActionResult<EventGroupOverview> Create(EventGroupOverview eventGroupInfo)
        {
            _eventGroupInfoService.Create(eventGroupInfo);

            return CreatedAtRoute("GetEventGroupInfo", new { id = eventGroupInfo.IddB.ToString() }, eventGroupInfo);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, EventGroupOverview eventGroupInfoIn)
        {
            var eventGroupInfo = _eventGroupInfoService.Get(id);

            if (eventGroupInfo == null)
            {
                return NotFound();
            }

            _eventGroupInfoService.Update(id, eventGroupInfoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var eventGroupInfo = _eventGroupInfoService.Get(id);

            if (eventGroupInfo == null)
            {
                return NotFound();
            }

            _eventGroupInfoService.Remove(eventGroupInfo.IddB);

            return NoContent();
        }

        [HttpGet]
        [Route("RemoveAll")]
        public IActionResult RemoveAll (){
            _eventGroupInfoService.RemoveAll();
            return NoContent();
        }
    }
}