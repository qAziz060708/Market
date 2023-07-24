using Market.DataAccess.Models;

namespace Market.DataAccess.Repositories.IRepositories
{
    public interface ITransactionReportRepository
    {
        Task<int> AddTransactionReportAsync(TransactionReport transactionreport);

        Task<int> UpdateTransactionReportAsync(TransactionReport transactionreport);

        Task<int> DeleteTransactionReportAsync(TransactionReport transactionreport);

        Task<TransactionReport> GetTransactionReportByIdAsync(int id);

        Task<List<TransactionReport>> GetAllTransactionReportsAsync();
    }
}