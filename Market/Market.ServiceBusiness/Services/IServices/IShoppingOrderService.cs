using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface IShoppingOrderService
    {
        Task<int> AddShoppingOrderAsync(ShoppingOrderRequestDTO shoppingOrderRequestDTO);

        Task<int> UpdateShoppingOrderAsync(ShoppingOrderRequestDTO shoppingOrderRequestDTO, int id);

        Task<int> DeleteShoppingOrderAsync(int id);

        Task<ShoppingOrderResponseDTO> GetShoppingOrderByIdAsync(int id);

        Task<List<ShoppingOrderResponseDTO>> GetAllShoppingOrdersAsync();
    }
}