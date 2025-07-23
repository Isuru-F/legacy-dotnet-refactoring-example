using LegacyECommerceApi.Models;

namespace LegacyECommerceApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Customer Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        Task<Customer?> GetByEmailAsync(string email);
    }
}
