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
    public class ShoppingOrderRepository : IShoppingOrderRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public ShoppingOrderRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddShoppingOrderAsync(ShoppingOrder shoppingOrder)
        {
            _marketDbContext.ShoppingOrders.Add(shoppingOrder);
            await _marketDbContext.SaveChangesAsync();
            return shoppingOrder.OrderId;
        }

        public async Task<int> DeleteShoppingOrderAsync(ShoppingOrder shoppingOrder)
        {
            _marketDbContext.ShoppingOrders.Remove(shoppingOrder);
            await _marketDbContext.SaveChangesAsync();
            return shoppingOrder.OrderId;
        }

        public async Task<List<ShoppingOrder>> GetAllShoppingOrdersAsync()
        {
            return await _marketDbContext.ShoppingOrders
                .Include(u => u.TransactionReports)
                .Include(u => u.Customer)
                .ToListAsync();
        }

        public async Task<ShoppingOrder> GetShoppingOrderByIdAsync(int id)
        {
            return await _marketDbContext.ShoppingOrders
                .Include(u => u.TransactionReports)
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(u => u.OrderId == id);
        }

        public async Task<int> UpdateShoppingOrderAsync(ShoppingOrder shoppingOrder)
        {
            _marketDbContext.ShoppingOrders.Update(shoppingOrder);
            await _marketDbContext.SaveChangesAsync();
            return shoppingOrder.OrderId;
        }
    }
}
