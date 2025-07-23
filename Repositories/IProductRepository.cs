using LegacyECommerceApi.Models;

namespace LegacyECommerceApi.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Product Add(Product product);
        void Update(Product product);
        void Delete(int id);
        IEnumerable<Product> GetByCategory(string category);
        Task<IEnumerable<Product>> GetActiveProductsAsync();
    }
}
