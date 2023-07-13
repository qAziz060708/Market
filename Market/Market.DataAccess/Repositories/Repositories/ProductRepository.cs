using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                _marketDbContext.Products.Add(product);
                await _marketDbContext.SaveChangesAsync();
                return product.ProductId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<int> DeleteProductAsync(Product product)
        {
            try
            {
                _marketDbContext.Products.Remove(product);
                await _marketDbContext.SaveChangesAsync();
                return product.ProductId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _marketDbContext.Products
               .Include(u => u.Sellers)
               .Include(u => u.TransactionReports)
               .Include(u => u.Customer)
               .Include(u => u.Category)
               .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed wnet it was given the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.Products
               .Include(u => u.Sellers)
               .Include(u => u.TransactionReports)
               .Include(u => u.Customer)
               .Include(u => u.Category)
               .FirstOrDefaultAsync(u => u.ProductId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed wnet it was given the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            try
            {
                var productForUpdate = await GetProductByIdAsync(product.ProductId);
                productForUpdate.ProductName = product.ProductName;
                await _marketDbContext.SaveChangesAsync();
                return product.ProductId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }
    }
}
