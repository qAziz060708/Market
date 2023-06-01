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
    public class ShoppingOrderService : IShoppingOrderService
    {
        private readonly IShoppingOrderRepository _shoppingOrderRepository;
        public ShoppingOrderService(IShoppingOrderRepository shoppingOrderRepository)
        {
            _shoppingOrderRepository= shoppingOrderRepository;
        }

        public async Task<int> AddShoppingOrderAsync(ShoppingOrder shoppingOrder)
        {
            try
            {
                return await _shoppingOrderRepository.AddShoppingOrderAsync(shoppingOrder);
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

        public async Task<int> DeleteShoppingOrderAsync(int id)
        {
            try
            {
                var shoppingOrderResult = await _shoppingOrderRepository.GetShoppingOrderByIdAsync(id);
                if (shoppingOrderResult is not null)
                {
                    return await _shoppingOrderRepository.DeleteShoppingOrderAsync(shoppingOrderResult);
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

        public async Task<List<ShoppingOrder>> GetAllShoppingOrdersAsync()
        {
            try
            {
                return await _shoppingOrderRepository.GetAllShoppingOrdersAsync();
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
                return await _shoppingOrderRepository.GetShoppingOrderByIdAsync(id);
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

        public async Task<int> UpdateShoppingOrderAsync(ShoppingOrder shoppingOrder, int id)
        {
            try
            {
                var shoppingOrderResult = await _shoppingOrderRepository.GetShoppingOrderByIdAsync(id);
                if(shoppingOrderResult is not null)
                {
                    return await _shoppingOrderRepository.UpdateShoppingOrderAsync(shoppingOrder);
                }
                else
                {
                    throw new Exception("Object cannot be updated");
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
