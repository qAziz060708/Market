using Market.DataAccess.Models;

namespace Market.DataAccess.Repositories.IRepositories
{
    public interface IShoppingOrdersAndProductsRepository
    {
        Task<int> AddShoppingOrdersAndProductsAsync(ShoppingOrdersAndProducts shoppingOrdersAndProducts);

        Task<int> UpdateShoppingOrdersAndProductsAsync(ShoppingOrdersAndProducts shoppingOrdersAndProducts);

        Task<int> DeleteShoppingOrdersAndProductsAsync(ShoppingOrdersAndProducts shoppingOrdersAndProducts);

        Task<ShoppingOrdersAndProducts> GetShoppingOrdersAndProductsByIdAsync(int id);

        Task<List<ShoppingOrdersAndProducts>> GetAllShoppingOrdersAndProductsAsync();
    }
}