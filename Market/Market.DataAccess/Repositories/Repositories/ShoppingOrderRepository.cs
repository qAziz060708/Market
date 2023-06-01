using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;

namespace Market.DataAccess.Repositories.Repositories
{
    public class ShoppingOrderRepository : IShoppingOrderRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public ShoppingOrderRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddShoppingOrderAsync(ShoppingOrder shoppingOrder)
        {
            try
            {
                _marketDbContext.ShoppingOrders.Add(shoppingOrder);
                await _marketDbContext.SaveChangesAsync();
                return shoppingOrder.OrderId;
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

        public async Task<int> DeleteShoppingOrderAsync(ShoppingOrder shoppingOrder)
        {
            try
            {
                _marketDbContext.ShoppingOrders.Remove(shoppingOrder);
                await _marketDbContext.SaveChangesAsync();
                return shoppingOrder.OrderId;
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

        public async Task<List<ShoppingOrder>> GetAllShoppingOrdersAsync()
        {
            try
            {
                return await _marketDbContext.ShoppingOrders
               .Include(u => u.TransactionReports)
               .Include(u => u.Customer)
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

        public async Task<ShoppingOrder> GetShoppingOrderByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.ShoppingOrders
               .Include(u => u.TransactionReports)
               .Include(u => u.Customer)
               .FirstOrDefaultAsync(u => u.OrderId == id);
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

        public async Task<int> UpdateShoppingOrderAsync(ShoppingOrder shoppingOrder)
        {
            try
            {
                var shoppingForUpdate = await GetShoppingOrderByIdAsync(shoppingOrder.OrderId);
                shoppingForUpdate.ShoppingDate = shoppingOrder.ShoppingDate;
                await _marketDbContext.SaveChangesAsync();
                return shoppingOrder.OrderId;
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
