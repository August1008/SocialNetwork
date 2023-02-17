using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("get_all")]
        public ActionResult<List<Registration>> Get()
        {
            return _registrationService.Get().ToList();
        }
    }
}
