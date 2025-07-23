using LegacyECommerceApi.Models;

namespace LegacyECommerceApi.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Order Add(Order order);
        void Update(Order order);
        void Delete(int id);
        Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId);
        IEnumerable<Order> GetByStatus(string status);
    }
}
