using Market.DataAccess.Models;

namespace Market.DataAccess.Repositories.IRepositories
{
    public interface IProductRepository
    {
        Task<int> AddProductAsync(Product product);

        Task<int> UpdateProductAsync(Product product);

        Task<int> DeleteProductAsync(Product product);

        Task<Product> GetProductByIdAsync(int id);

        Task<List<Product>> GetAllProductsAsync();
    }
}
