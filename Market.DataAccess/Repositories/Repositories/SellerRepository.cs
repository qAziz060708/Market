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
    public class SellerRepository:ISellerRepository
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
                throw new Exception("Operation was failed when it saved changes");
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
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<List<Seller>> GetAllSellersAsync()
        {
            try
            {
                return await _marketDbContext.Sellers
               .Include(u => u.Products)
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

        public async Task<Seller> GetSellerByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.Sellers
               .Include(u => u.Products)
               .FirstOrDefaultAsync(u => u.SellerId == id);
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
                throw new Exception("Operation was failed when it saved changes");
            }
        }
    }
}
