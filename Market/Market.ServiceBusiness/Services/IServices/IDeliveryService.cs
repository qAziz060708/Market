using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface IDeliveryService
    {
        Task <int> AddDeliveryAsync(DeliveryRequestDTO deliveryRequestDTO);

        Task<int> UpdateDeliveryAsync(DeliveryRequestDTO deliveryRequestDTO, int id);

        Task<int> DeleteDeliveryAsync(int id);

        Task<DeliveryResponseDTO> GetDeliveryByIdAsync(int id);

        Task<List<DeliveryResponseDTO>> GetAllDeliveriesAsync();
    }
}