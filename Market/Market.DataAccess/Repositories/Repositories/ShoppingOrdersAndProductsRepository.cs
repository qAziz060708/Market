using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Market.DataAccess.Repositories.Repositories
{
    public class ShoppingOrdersAndProductsRepository : IShoppingOrdersAndProductsRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public ShoppingOrdersAndProductsRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddShoppingOrdersAndProductsAsync(ShoppingOrdersAndProducts shoppingOrdersAndProducts)
        {
            try
            {
                _marketDbContext.ShoppingOrdersAndProducts.Add(shoppingOrdersAndProducts);
                await _marketDbContext.SaveChangesAsync();
                return shoppingOrdersAndProducts.ShoppingOrdersAndProductsId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was adding changes");
            }
        }

        public async Task<int> DeleteShoppingOrdersAndProductsAsync(ShoppingOrdersAndProducts shoppingOrdersAndProducts)
        {
            try
            {
                _marketDbContext.ShoppingOrdersAndProducts.Remove(shoppingOrdersAndProducts);
                await _marketDbContext.SaveChangesAsync();
                return shoppingOrdersAndProducts.ShoppingOrdersAndProductsId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<ShoppingOrdersAndProducts>> GetAllShoppingOrdersAndProductsAsync()
        {
            try
            {
                return await _marketDbContext.ShoppingOrdersAndProducts
                    .Include(u => u.Product)
                    .Include(u => u.ShoppingOrder)
                    .AsSplitQuery()
                    .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving ShoppingOrdersAndProducts information");
            }
        }

        public async Task<ShoppingOrdersAndProducts> GetShoppingOrdersAndProductsByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.ShoppingOrdersAndProducts
                    .Include(u => u.Product)
                    .Include(u => u.ShoppingOrder)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(u => u.ShoppingOrdersAndProductsId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving ShoppingOrdersAndProductsById information");
            }
        }

        public async Task<int> UpdateShoppingOrdersAndProductsAsync(ShoppingOrdersAndProducts shoppingOrdersAndProducts)
        {
            try
            {
                var shoppingOrdersAndProductsForUpdate = await GetShoppingOrdersAndProductsByIdAsync(shoppingOrdersAndProducts.ShoppingOrderId);
                await _marketDbContext.SaveChangesAsync();
                return shoppingOrdersAndProducts.ShoppingOrdersAndProductsId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was updating changes");
            }
        }
    }
}