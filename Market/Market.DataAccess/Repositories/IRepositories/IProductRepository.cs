using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
