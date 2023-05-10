using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;

namespace Market.DataAccess.Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public ProductRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            _marketDbContext.Products.Add(product);
            await _marketDbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<int> DeleteProductAsync(Product product)
        {
            _marketDbContext.Products.Remove(product);
            await _marketDbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _marketDbContext.Products
                .Include(u => u.Sellers)
                .Include(u => u.TransactionReports)
                .Include(u => u.Customer)
                .Include(u => u.Category)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _marketDbContext.Products
                .Include(u => u.Sellers)
                .Include(u => u.TransactionReports)
                .Include(u => u.Customer)
                .Include(u => u.Category)
                .FirstOrDefaultAsync(u => u.ProductId == id);
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            _marketDbContext.Products.Update(product);
            await _marketDbContext.SaveChangesAsync();
            return product.ProductId;
        }
    }
}
