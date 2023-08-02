using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface ITransactionReportService
    {
        Task<int> AddTransactionReportAsync(TransactionReportRequestDTO transactionReportRequestDTO);

        Task<int> UpdateTransactionReportAsync(TransactionReportRequestDTO transactionReportRequestDTO, int id);

        Task <int> DeleteTransactionReportAsync(int id);

        Task<TransactionReportResponseDTO> GetTransactionReportByIdAsync(int id);

        Task<List<TransactionReportResponseDTO>> GetAllTransactionReportsAsync();
    }
}