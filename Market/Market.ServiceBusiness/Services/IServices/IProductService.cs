using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface IProductService
    {
        Task<int> AddProductAsync(ProductRequestDTO productRequestDTO);

        Task<int> UpdateProductAsync(ProductRequestDTO productRequestDTO, int id);

        Task<int> DeleteProductAsync(int id);

        Task<ProductResponseDTO> GetProductByIdAsync(int id);

        Task<List<ProductResponseDTO>> GetAllProductsAsync();
    }
}