using Abanoub.CM.BOL.Models;

namespace Abanoub.CM.DAL.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task InsertAsync(int index, Customer newCustomer, CancellationToken cancellationToken);
        Task AddAsync(Customer newCustomer, CancellationToken cancellationToken);
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken);
        Task<Customer?> GetAsync(int id, CancellationToken cancellationToken);
    }
}
