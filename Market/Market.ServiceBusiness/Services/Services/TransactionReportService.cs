using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.Services
{
    internal class TransactionReportService : ITransactionReportService
    {
        private readonly ITransactionReportRepository _transactionReportRepository;
        public TransactionReportService(ITransactionReportRepository transactionReportRepository)
        {
            _transactionReportRepository = transactionReportRepository;
        }

        public async Task<int> AddTransactionReportAsync(TransactionReport transactionreport)
        {
            try
            {
                return await _transactionReportRepository.AddTransactionReportAsync(transactionreport);
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

        public async Task<int> DeleteTransactionReportAsync(int id)
        {
            try
            {
                var transactionReportResult = await _transactionReportRepository.GetTransactionReportByIdAsync(id);
                if (transactionReportResult is not null)
                {
                    return await _transactionReportRepository.DeleteTransactionReportAsync(transactionReportResult);
                }
                else
                {
                    throw new Exception("Object cannot be deleted");
                }
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
                return await _transactionReportRepository.GetAllTransactionReportsAsync();
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
                return await _transactionReportRepository.GetTransactionReportByIdAsync(id);
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

        public async Task<int> UpdateTransactionReportAsync(TransactionReport transactionreport, int id)
        {
            try
            {
                var transactionReportResult = await _transactionReportRepository.GetTransactionReportByIdAsync(id);
                if(transactionReportResult is not null)
                {
                    return await _transactionReportRepository.UpdateTransactionReportAsync(transactionreport);
                }
                else
                {
                    throw new Exception("Object cannot be updated");
                }
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
