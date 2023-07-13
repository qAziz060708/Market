using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;
using AutoMapper;

namespace Market.ServiceBusiness.Services.Services
{
    public class TransactionReportService : ITransactionReportService
    {
        private readonly ITransactionReportRepository _transactionReportRepository;
        private readonly IMapper _mapper;
        public TransactionReportService(ITransactionReportRepository transactionReportRepository, IMapper mapper)
        {
            _transactionReportRepository = transactionReportRepository;
            _mapper = mapper;
        }

        public async Task<List<TransactionReportResponseDTO>> GetAllTransactionReportsAsync()
        {
            try
            {
                return _mapper.Map<List<TransactionReportResponseDTO>>(await _transactionReportRepository.GetAllTransactionReportsAsync());
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

        public async Task<TransactionReportResponseDTO> GetTransactionReportByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<TransactionReportResponseDTO>(await _transactionReportRepository.GetTransactionReportByIdAsync(id));
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
    }
}
//tester
