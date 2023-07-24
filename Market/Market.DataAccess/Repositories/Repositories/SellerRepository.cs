using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Market.DataAccess.Repositories.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public SellerRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddSellerAsync(Seller seller)
        {
            try
            {
                _marketDbContext.Sellers.Add(seller);
                await _marketDbContext.SaveChangesAsync();
                return seller.SellerId;
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

        public async Task<int> DeleteSellerAsync(Seller seller)
        {
            try
            {
                _marketDbContext.Sellers.Remove(seller);
                await _marketDbContext.SaveChangesAsync();
                return seller.SellerId;
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

        public async Task<List<Seller>> GetAllSellersAsync()
        {
            try
            {
                return await _marketDbContext.Sellers
               .Include(u => u.Products)
               .AsSplitQuery()
               .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving sellers information");
            }
        }

        public async Task<Seller> GetSellerByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.Sellers
               .Include(u => u.Products)
               .AsSplitQuery()
               .FirstOrDefaultAsync(u => u.SellerId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving SellerById information");
            }
        }

        public async Task<int> UpdateSellerAsync(Seller seller)
        {
            try
            {
                var sellerForUpdate = await GetSellerByIdAsync(seller.SellerId);
                sellerForUpdate.FirstName = seller.FirstName;
                sellerForUpdate.LasName = seller.LasName;
                await _marketDbContext.SaveChangesAsync();
                return seller.SellerId;
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