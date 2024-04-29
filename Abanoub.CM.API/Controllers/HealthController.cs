using Microsoft.AspNetCore.Mvc;

namespace Abanoub.CM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        // GET: api/<HealthController>
        [HttpGet]
        public string Get()
        {
            return "OK";
        }
    }
}
