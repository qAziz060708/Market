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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public PaymentRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddPaymentAsync(Payment payment)
        {
            try
            {
                _marketDbContext.Payments.Add(payment);
                await _marketDbContext.SaveChangesAsync();
                return payment.PaymentId;
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

        public async Task<int> DeletePaymentAsync(Payment payment)
        {
            try
            {
                _marketDbContext.Payments.Remove(payment);
                await _marketDbContext.SaveChangesAsync();
                return payment.PaymentId;
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

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            try
            {
                return await _marketDbContext.Payments
               .Include(u => u.Customer)
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

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.Payments
               .Include(u => u.Customer)
               .FirstOrDefaultAsync(u => u.PaymentId == id);
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

        public async Task<int> UpdatePaymentAsync(Payment payment)
        {
            try
            {
                var paymentForUpdate = await GetPaymentByIdAsync(payment.PaymentId);
                paymentForUpdate.PaymentDate = payment.PaymentDate;
                await _marketDbContext.SaveChangesAsync();
                return payment.PaymentId;
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
