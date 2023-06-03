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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<int> AddPaymentAsync(Payment payment)
        {
            try
            {
                return await _paymentRepository.AddPaymentAsync(payment);
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

        public async Task<int> DeletePaymentAsync(int id)
        {
            try
            {
                var paymentResult = await _paymentRepository.GetPaymentByIdAsync(id);
                if (paymentResult is not null)
                {
                    return await _paymentRepository.DeletePaymentAsync(paymentResult);
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

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            try
            {
                return await _paymentRepository.GetAllPaymentsAsync();
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
                return await _paymentRepository.GetPaymentByIdAsync(id);
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

        public async Task<int> UpdatePaymentAsync(Payment payment, int id)
        {
            try
            {
                var paymentResult = await _paymentRepository.GetPaymentByIdAsync(id);
                if(paymentResult is not null)
                {
                    return await _paymentRepository.UpdatePaymentAsync(payment);
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
