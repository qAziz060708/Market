using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                _marketDbContext.TransactionReports.Add(transactionreport);
                await _marketDbContext.SaveChangesAsync();
                return transactionreport.TransactionReportId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was adding changes");
            }
        }

        public async Task<int> DeleteTransactionReportAsync(TransactionReport transactionreport)
        {
            try
            {
                _marketDbContext.TransactionReports.Remove(transactionreport);
                await _marketDbContext.SaveChangesAsync();
                return transactionreport.TransactionReportId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<TransactionReport>> GetAllTransactionReportsAsync()
        {
            try
            {
                return await _marketDbContext.TransactionReports
                   .Include(u => u.ShoppingOrder)
                   .AsSplitQuery()
                   .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving transactionReports information");
            }
        }

        public async Task<TransactionReport> GetTransactionReportByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.TransactionReports
                   .Include(u => u.ShoppingOrder)
                   .AsSplitQuery()
                   .FirstOrDefaultAsync(u => u.TransactionReportId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving TransactionReportById information");
            }
        }

        public async Task<int> UpdateTransactionReportAsync(TransactionReport transactionreport)
        {
            try
            {
                var transactionreportForUpdate = await GetTransactionReportByIdAsync(transactionreport.TransactionReportId);
                await _marketDbContext.SaveChangesAsync();
                return transactionreport.TransactionReportId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was updating changes");
            }
        }
    }
}