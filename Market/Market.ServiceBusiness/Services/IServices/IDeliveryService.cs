using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface IDeliveryService
    {
        Task<DeliveryResponseDTO> GetDeliveryByIdAsync(int id);

        Task<List<DeliveryResponseDTO>> GetAllDeliveriesAsync();
    }
}
