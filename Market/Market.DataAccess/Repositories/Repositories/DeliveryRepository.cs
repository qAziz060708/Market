using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.DataAccess.Repositories.IRepositories;
using Market.DataAccess.Models;
using Market.DataAccess.DbConnection;
using System.Data.Entity;

namespace Market.DataAccess.Repositories.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public DeliveryRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddDeliveryAsync(Delivery delivery)
        {
            _marketDbContext.Deliveries.Add(delivery);
            await _marketDbContext.SaveChangesAsync();
            return delivery.DeliveryId;
        }

        public async Task<int> DeleteDeliveryAsync(Delivery delivery)
        {
            _marketDbContext.Deliveries.Remove(delivery);
            await _marketDbContext.SaveChangesAsync();
            return delivery.DeliveryId;
        }

        public async Task<List<Delivery>> GetAllDeliveriesAsync()
        {
            return await _marketDbContext.Deliveries
                .Include(u => u.Customer)
                .ToListAsync();
        }

        public async Task<Delivery> GetDeliveryByIdAsync(int id)
        {
            return await _marketDbContext.Deliveries
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(u =>u.DeliveryId == id);
        }

        public async Task<int> UpdateDeliveryAsync(Delivery delivery)
        {
            _marketDbContext.Deliveries.Update(delivery);
            await _marketDbContext.SaveChangesAsync();
            return delivery.DeliveryId;
        }
    }
}
