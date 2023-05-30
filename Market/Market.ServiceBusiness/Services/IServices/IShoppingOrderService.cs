using Market.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface IShoppingOrderService
    {
        Task<int> AddShoppingOrderAsync(ShoppingOrder shoppingOrder);

        Task<int> UpdateShoppingOrderAsync(ShoppingOrder shoppingOrder, int id);

        Task<int> DeleteShoppingOrderAsync(int id);

        Task<ShoppingOrder> GetShoppingOrderByIdAsync(int id);

        Task<List<ShoppingOrder>> GetAllShoppingOrdersAsync();
    }
}
