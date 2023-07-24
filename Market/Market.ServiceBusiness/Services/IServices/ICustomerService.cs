using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface ICustomerService
    {
        Task<int> AddCustomerAsync(CustomerRequestDTO customerRequestDTO);

        Task<int> UpdateCustomerAsync(CustomerRequestDTO customerRequestDTO, int id);

        Task<int> DeleteCustomerAsync(int id);

        Task<CustomerResponseDTO> GetCustomerByIdAsync(int id);

        Task<List<CustomerResponseDTO>> GetAllCustomersAsync();
    }
}