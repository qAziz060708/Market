using Market.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface ITransactionReportService
    {
        Task<int> AddTransactionReportAsync(TransactionReport transactionreport);

        Task<int> UpdateTransactionReportAsync(TransactionReport transactionreport, int id);

        Task<int> DeleteTransactionReportAsync(int id);

        Task<TransactionReport> GetTransactionReportByIdAsync(int id);

        Task<List<TransactionReport>> GetAllTransactionReportsAsync();
    }
}
