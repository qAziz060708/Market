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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public PaymentRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddPaymentAsync(Payment payment)
        {
            _marketDbContext.Payments.Add(payment);
            await _marketDbContext.SaveChangesAsync();
            return payment.PaymentId;
        }

        public async Task<int> DeletePaymentAsync(Payment payment)
        {
            _marketDbContext.Payments.Remove(payment);
            await _marketDbContext.SaveChangesAsync();
            return payment.PaymentId;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _marketDbContext.Payments
               .Include(u => u.Customer)
               .ToListAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _marketDbContext.Payments
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(u => u.PaymentId == id);
        }

        public async Task<int> UpdatePaymentAsync(Payment payment)
        {
            _marketDbContext.Payments.Update(payment);
            await _marketDbContext.SaveChangesAsync();
            return payment.PaymentId;
        }
    }
}
