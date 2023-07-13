using AutoMapper;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<int> AddPaymentAsync(PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                return await _paymentRepository.AddPaymentAsync(_mapper.Map<Payment>(paymentRequestDTO));
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

        public async Task<List<PaymentResponseDTO>> GetAllPaymentsAsync()
        {
            try
            {
                return _mapper.Map<List<PaymentResponseDTO>>(await _paymentRepository.GetAllPaymentsAsync());
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

        public async Task<PaymentResponseDTO> GetPaymentByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<PaymentResponseDTO>(await _paymentRepository.GetPaymentByIdAsync(id));
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

        public async Task<int> UpdatePaymentAsync(PaymentRequestDTO paymentRequestDTO, int id)
        {
            try
            {
                var paymentResult = await _paymentRepository.GetPaymentByIdAsync(id);
                if (paymentResult is not null)
                {
                    paymentResult.PaymentType = paymentRequestDTO.PaymentType;
                    return await _paymentRepository.UpdatePaymentAsync(paymentResult);
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
