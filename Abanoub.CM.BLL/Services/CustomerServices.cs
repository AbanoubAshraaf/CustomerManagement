using Abanoub.CM.BLL.Services.Interfaces;
using Abanoub.CM.BOL.Models;
using Abanoub.CM.BOL.Payloads;
using Abanoub.CM.BOL.Utility;
using Abanoub.CM.DAL.Repositories.Interfaces;


namespace Abanoub.CM.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customersRepo;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customersRepo = customerRepository;
        }

        public async Task<ResponseData<IEnumerable<Customer>>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            return new ResponseData<IEnumerable<Customer>>() { Data = await _customersRepo.GetAllAsync(cancellationToken), Success = true, Message = "Success!" };
        }

        public async Task<Response> AddCustomersAsync(CustomersPayload payload, CancellationToken cancellationToken)
        {
            if (payload == null || payload.Customers == null || !payload.Customers.Any())
            {
                return new Response() { Success = false, Message = "Please provide customers List in the body" };
            }
            foreach (var customer in payload.Customers)
            {

                if (IsInvalidCustomer(customer))
                {
                    return new Response() { Success = false, Message = "please make sure that you have supplied all required fields for every customer" };

                }
                else if (customer.Age <= 18)
                {
                    return new Response() { Success = false, Message = "The customer age should be above 18" };
                }
                else if (await _customersRepo.GetAsync(customer.Id, cancellationToken) != null)
                {
                    return new Response() { Success = false, Message = $"Customer with Id {customer.Id} already exist" };

                }
            }

            foreach (var customer in payload.Customers)
            {
                var index = await GetIndexOfNewCustomerAsync(customer, cancellationToken);
                if (index == -1)
                {
                    await _customersRepo.AddAsync(customer, cancellationToken);


                }
                else
                {
                    await _customersRepo.InsertAsync(index, customer, cancellationToken);
                }

            }
            return new Response() { Success = true, Message = "Customers Added Successfully" };
        }

        private bool IsInvalidCustomer(Customer customer)
        {
            return
                   string.IsNullOrEmpty(customer.FirstName) ||
                   string.IsNullOrEmpty(customer.LastName) ||
                   customer.Age <= 0 ||
                   customer.Id <= 0;
        }
        private async Task<int> GetIndexOfNewCustomerAsync(Customer customer, CancellationToken cancellationToken)
        {
            int index = (await _customersRepo.GetAllAsync(cancellationToken)).FindIndex(existedCustomer =>
                              string.Compare(existedCustomer.LastName, customer.LastName, StringComparison.OrdinalIgnoreCase) > 0 ||
                              (string.Compare(existedCustomer.LastName, customer.LastName, StringComparison.OrdinalIgnoreCase) == 0 &&
                              string.Compare(existedCustomer.FirstName, customer.FirstName, StringComparison.OrdinalIgnoreCase) > 0)
                             );

            return index;
        }


    }

}
