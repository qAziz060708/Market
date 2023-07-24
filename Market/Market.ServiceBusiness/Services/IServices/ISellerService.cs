using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface ISellerService
    {
        Task<int> AddSellerAsync(SellerRequestDTO sellerRequestDTO);

        Task<int> UpdateSellerAsync(SellerRequestDTO sellerRequestDTO, int id);

        Task<int> DeleteSellerAsync(int id);

        Task<SellerResponseDTO> GetSellerByIdAsync(int id);

        Task<List<SellerResponseDTO>> GetAllSellersAsync();
    }
}