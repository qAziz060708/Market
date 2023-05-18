using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;

namespace Market.DataAccess.Repositories.Repositories
{
    public class TransactionReportRepository : ITransactionReportRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public TransactionReportRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddTransactionReportAsync(TransactionReport transactionreport)
        {
            _marketDbContext.TransactionReports.Add(transactionreport);
            await _marketDbContext.SaveChangesAsync();
            return transactionreport.ReportId;
        }

        public async Task<int> DeleteTransactionReportAsync(TransactionReport transactionreport)
        {
            _marketDbContext.TransactionReports.Remove(transactionreport);
            await _marketDbContext.SaveChangesAsync();
            return transactionreport.ReportId;
        }

        public async Task<List<TransactionReport>> GetAllTransactionReportsAsync()
        {
            return await _marketDbContext.TransactionReports
                .Include(u => u.ShoppingOrder)
                .Include(u => u.Products)
                .ToListAsync();
        }

        public async Task<TransactionReport> GetTransactionReportByIdAsync(int id)
        {
            return await _marketDbContext.TransactionReports
                .Include(u => u.ShoppingOrder)
                .Include(u => u.Products)
                .FirstOrDefaultAsync(u => u.ReportId == id);
        }

        public async Task<int> UpdateTransactionReportAsync(TransactionReport transactionreport)
        {
            _marketDbContext.TransactionReports.Update(transactionreport);
            await _marketDbContext.SaveChangesAsync();
            return transactionreport.ReportId;
        }
    }
}
