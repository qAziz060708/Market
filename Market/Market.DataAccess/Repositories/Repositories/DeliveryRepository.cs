using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                _marketDbContext.Deliveries.Add(delivery);
                await _marketDbContext.SaveChangesAsync();
                return delivery.DeliveryId;
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

        public async Task<int> DeleteDeliveryAsync(Delivery delivery)
        {
            try
            {
                _marketDbContext.Deliveries.Remove(delivery);
                await _marketDbContext.SaveChangesAsync();
                return delivery.DeliveryId;
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

        public async Task<List<Delivery>> GetAllDeliveriesAsync()
        {
            try
            {
                return await _marketDbContext.Deliveries
               .Include(u => u.Customer)
               .AsSplitQuery()
               .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving deliveries information");
            }
        }

        public async Task<Delivery> GetDeliveryByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.Deliveries
               .Include(u => u.Customer)
               .AsSplitQuery()
               .FirstOrDefaultAsync(u => u.DeliveryId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving DeliveryById information");
            }
        }

        public async Task<int> UpdateDeliveryAsync(Delivery delivery)
        {
            try
            {
                var deliveryForUpdate = await GetDeliveryByIdAsync(delivery.DeliveryId);
                deliveryForUpdate.DeliveryDate = delivery.DeliveryDate;
                await _marketDbContext.SaveChangesAsync();
                return delivery.DeliveryId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it updating changes");
            }
        }
    }
}