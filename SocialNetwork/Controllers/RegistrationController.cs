using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DTOs;
using SocialNetwork.DTOs.APIModels;
using SocialNetwork.Models;
using SocialNetwork.Services;
using System.Collections;


namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            this._registrationService = registrationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = _registrationService.GetByUsernameAndPasswordAsync(loginModel.email, loginModel.password).Result;
            return Ok(new
            {
                success = user != null,
                User = user
            });
        }
        [HttpGet("get_all")]
        public async Task<IEnumerable<Registration>> Get()
        {
            return await _registrationService.Get();
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Registration? registration = null;
            try
            {
                registration = await _registrationService.GetById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new
            {
                data = registration
            });
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]RegistrationDto registrationDto)
        {
            Registration? registration = null;
            try
            {
                registration = _registrationService.Create(registrationDto).Result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new
            {
                respone = true,
                data = registration,
                message = String.Format("Create new registration {0} successfully.", registrationDto.Email)
            });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _registrationService.RemoveAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { respone = true, message = String.Format("Delete the registration {0} successfully.", id) });
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(RegistrationDto registrationDto)
        {
            Registration? registration = null;
            try
            {
                registration = _registrationService.Update(registrationDto).Result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new
            {
                respone = true,
                data = registration,
                message = String.Format("Update the registration {0} unsuccessfully", registrationDto.Email)
            });
        }
    }
}
