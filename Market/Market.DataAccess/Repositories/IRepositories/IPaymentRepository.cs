using Market.DataAccess.Models;

namespace Market.DataAccess.Repositories.IRepositories
{
    public interface IPaymentRepository
    {
        Task<int> AddPaymentAsync(Payment payment);

        Task<int> UpdatePaymentAsync(Payment payment);

        Task<int> DeletePaymentAsync(Payment payment);

        Task<Payment> GetPaymentByIdAsync(int id);

        Task<List<Payment>> GetAllPaymentsAsync();
    }
}