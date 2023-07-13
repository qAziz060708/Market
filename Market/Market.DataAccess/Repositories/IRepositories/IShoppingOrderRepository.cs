using Market.DataAccess.Models;

namespace Market.DataAccess.Repositories.IRepositories
{
    public interface IShoppingOrderRepository
    {
        Task<int> AddShoppingOrderAsync(ShoppingOrder shoppingOrder);

        Task<int> UpdateShoppingOrderAsync(ShoppingOrder shoppingOrder);

        Task<int> DeleteShoppingOrderAsync(ShoppingOrder shoppingOrder);

        Task<ShoppingOrder> GetShoppingOrderByIdAsync(int id);

        Task<List<ShoppingOrder>> GetAllShoppingOrdersAsync();
    }
}
