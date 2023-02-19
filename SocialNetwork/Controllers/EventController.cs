using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DTOs;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(new
                {
                    StatusCode = 200,
                    data = _eventService.Get(),
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(new
                {
                    StatusCode = 200,
                    data = _eventService.GetById(id),
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(EventDto dto)
        {
            Event? Event = null;
            try
            {
                Event = await _eventService.Create(dto);
                return Ok(new
                {
                    StatusCode = 200,
                    data = Event,
                    message = String.Format("Create new Event {0} successfully", dto.Id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = Event,
                    message = ex.Message
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _eventService.RemoveAsync(id);
                return Ok(new
                {
                    StatusCode = 200,
                    message = String.Format("Delete the Event {0} successfully", id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EventDto dto)
        {
            Event? Event = null;
            try
            {
                Event = await _eventService.Update(dto);
                return Ok(new
                {
                    StatusCode = 200,
                    data = Event,
                    message = String.Format("Update new Event {0} successfully", dto.Id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = Event,
                    message = ex.Message
                });
            }
        }
    }
}
