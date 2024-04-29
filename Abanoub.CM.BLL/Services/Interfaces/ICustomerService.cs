using Abanoub.CM.BOL.Models;
using Abanoub.CM.BOL.Payloads;
using Abanoub.CM.BOL.Utility;

namespace Abanoub.CM.BLL.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<ResponseData<IEnumerable<Customer>>> GetAllCustomersAsync(CancellationToken cancellationToken);
        Task<Response> AddCustomersAsync(CustomersPayload payload, CancellationToken cancellationToken);
    }
}
