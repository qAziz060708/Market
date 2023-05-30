using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.Services
{
    internal class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<int> AddSellerAsync(Seller seller)
        {
            try
            {
                return await _sellerRepository.AddSellerAsync(seller);
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

        public async Task<int> DeleteSellerAsync(int id)
        {
            try
            {
                var sellerResult = await _sellerRepository.GetSellerByIdAsync(id);
                if(sellerResult is not null)
                {
                    return await _sellerRepository.DeleteSellerAsync(sellerResult);
                }
                else
                {
                    throw new Exception("Object cannot be deleted");
                }
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
                return await _sellerRepository.GetAllSellersAsync();
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
                return await _sellerRepository.GetSellerByIdAsync(id);
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

        public async Task<int> UpdateSellerAsync(Seller seller, int id)
        {
            try
            {
                var sellerResult = await _sellerRepository.GetSellerByIdAsync(id);
                if(sellerResult is not null)
                {
                    return await _sellerRepository.UpdateSellerAsync(seller);
                }
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
