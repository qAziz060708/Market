using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

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
                throw new Exception("Operation was failed when it was adding changes");
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
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            try
            {
                return await _marketDbContext.Payments
               .Include(u => u.Customer)
               .AsSplitQuery()
               .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving payments information");
            }
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.Payments
               .Include(u => u.Customer)
               .AsSplitQuery()
               .FirstOrDefaultAsync(u => u.PaymentId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving PaymentById information");
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
                throw new Exception("Operation was failed when it was updating changes");
            }
        }
    }
}