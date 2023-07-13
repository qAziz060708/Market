using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;
namespace Market.ServiceBusiness.Services.IServices
{
    public interface IPaymentService
    {
        Task<int> AddPaymentAsync(PaymentRequestDTO paymentRequestDTO);

        Task<int> UpdatePaymentAsync(PaymentRequestDTO paymentRequestDTO, int id);

        Task<int> DeletePaymentAsync(int id);

        Task<PaymentResponseDTO> GetPaymentByIdAsync(int id);

        Task<List<PaymentResponseDTO>> GetAllPaymentsAsync();
    }
}
