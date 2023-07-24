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
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<PaymentResponseDTO>> GetAllPaymentsAsync()
        {
            try
            {
                return _mapper.Map<List<PaymentResponseDTO>>(await _paymentRepository.GetAllPaymentsAsync());
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PaymentResponseDTO> GetPaymentByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<PaymentResponseDTO>(await _paymentRepository.GetPaymentByIdAsync(id));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdatePaymentAsync(PaymentRequestDTO paymentRequestDTO, int id)
        {
            try
            {
                var paymentResult = await _paymentRepository.GetPaymentByIdAsync(id);
                if (paymentResult is not null)
                {
                    paymentResult = _mapper.Map<Payment>(paymentRequestDTO);
                    paymentResult.PaymentId = id;
                    return await _paymentRepository.UpdatePaymentAsync(paymentResult);
                }
                else
                {
                    throw new Exception("Object cannot be updated");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was updating changes");
            }
        }
    }
}