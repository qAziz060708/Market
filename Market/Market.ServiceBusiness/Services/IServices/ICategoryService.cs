using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface ICategoryService
    {
        Task<int> AddCategoryAsync(CategoryRequestDTO categoryRequestDTO);

        Task<int> UpdateCategoryAsync(CategoryRequestDTO categoryRequestDTO, int id);

        Task<int> DeleteCategoryAsync(int id);

        Task<CategoryResponseDTO> GetCategoryByIdAsync(int id);

        Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();
    }
}
