using AutoMapper;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.DTO.Response_DTO;
using Market.ServiceBusiness.Services.IServices;
using Microsoft.EntityFrameworkCore;

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

        public async Task<TransactionReportResponseDTO> GetTransactionReportByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<TransactionReportResponseDTO>(await _transactionReportRepository.GetTransactionReportByIdAsync(id));
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
    }
}