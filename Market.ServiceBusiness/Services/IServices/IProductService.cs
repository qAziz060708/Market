using Market.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface IProductService
    {
        Task<int> AddProductAsync(Product product);

        Task<int> UpdateProductAsync(Product product, int id);

        Task<int> DeleteProductAsync(int id);

        Task<Product> GetProductByIdAsync(int id);

        Task<List<Product>> GetAllProductsAsync();
    }
}
