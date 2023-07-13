using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
                throw new Exception("Operation was failed when it saved changes");
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
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<List<TransactionReport>> GetAllTransactionReportsAsync()
        {
            try
            {
                return await _marketDbContext.TransactionReports
               .Include(u => u.ShoppingOrder)
               .Include(u => u.Products)
               .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed wnet it was given the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
            }
        }

        public async Task<TransactionReport> GetTransactionReportByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.TransactionReports
               .Include(u => u.ShoppingOrder)
               .Include(u => u.Products)
               .FirstOrDefaultAsync(u => u.TransactionReportId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed wnet it was given the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
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
                throw new Exception("Operation was failed when it saved changes");
            }
        }
    }
}
