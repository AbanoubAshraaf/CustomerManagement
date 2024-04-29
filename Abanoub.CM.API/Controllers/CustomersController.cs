using Abanoub.CM.BLL.Services.Interfaces;
using Abanoub.CM.BOL.Payloads;
using Abanoub.CM.BOL.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Abanoub.CM.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync(CancellationToken cancellationToken)
        {
            return Ok(await _customerService.GetAllCustomersAsync(cancellationToken));
            
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomersAsync([FromBody] CustomersPayload payload, CancellationToken cancellationToken)
        {
            Response response = await _customerService.AddCustomersAsync(payload, cancellationToken);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }

}
