using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface ITransactionReportService
    {
        Task<TransactionReportResponseDTO> GetTransactionReportByIdAsync(int id);

        Task<List<TransactionReportResponseDTO>> GetAllTransactionReportsAsync();
    }
}
