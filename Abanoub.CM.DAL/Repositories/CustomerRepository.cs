using Abanoub.CM.BOL.Models;
using Abanoub.CM.DAL.Repositories.Interfaces;

namespace Abanoub.CM.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task InsertAsync(int index, Customer newCustomer, CancellationToken cancellationToken)
        {
            CustomersDB.Customers.Insert(index, newCustomer);
            await CustomersDB.SaveCustomersDataToFileSync(CustomersDB.Customers, cancellationToken);
        }

        public async Task AddAsync(Customer newCustomer, CancellationToken cancellationToken)
        {
            CustomersDB.Customers.Add(newCustomer);
            await CustomersDB.SaveCustomersDataToFileSync(CustomersDB.Customers, cancellationToken);
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(() => CustomersDB.Customers);
        }

        public async Task<Customer?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => CustomersDB.Customers.FirstOrDefault(customer => customer.Id == id));
        }
      }
}
