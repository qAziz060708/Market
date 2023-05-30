using Market.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface IPaymentService
    {
        Task<int> AddPaymentAsync(Payment payment);

        Task<int> UpdatePaymentAsync(Payment payment, int id);

        Task<int> DeletePaymentAsync(int id);

        Task<Payment> GetPaymentByIdAsync(int id);

        Task<List<Payment>> GetAllPaymentsAsync();
    }
}
