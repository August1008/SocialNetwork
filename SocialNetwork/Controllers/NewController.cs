using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DTOs;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewController : ControllerBase
    {
        private readonly INewService _newService;

        public NewController(INewService newService)
        {
            _newService = newService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(new
                {
                    StatusCode = 200,
                    data = _newService.Get(),
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
                    data = _newService.GetById(id),
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(NewDto dto)
        {
            New? newNew = null;
            try
            {
                newNew = await _newService.Create(dto);
                return Ok(new
                {
                    StatusCode = 200,
                    data = newNew,
                    message = String.Format("Create new New {0} successfully", dto.Id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = newNew,
                    message = ex.Message
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _newService.RemoveAsync(id);
                return Ok(new
                {
                    StatusCode = 200,
                    message = String.Format("Delete the New {0} successfully", id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(NewDto dto)
        {
            New? updateNew = null;
            try
            {
                updateNew = await _newService.Update(dto);
                return Ok(new
                {
                    StatusCode = 200,
                    data = updateNew,
                    message = String.Format("Update new New {0} successfully", dto.Id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = updateNew,
                    message = ex.Message
                });
            }
        }
    }
}
