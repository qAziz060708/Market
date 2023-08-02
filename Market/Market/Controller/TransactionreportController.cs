using Microsoft.AspNetCore.Mvc;
using Market.ServiceBusiness.DTO.Response_DTO;
using Market.ServiceBusiness.Services.IServices;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.Services.Services;

namespace Market.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionReportController : ControllerBase
    {
        private readonly ITransactionReportService _transactionReportService;

        public TransactionReportController(ITransactionReportService transactionReportService)
        {
            _transactionReportService = transactionReportService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddTransactionReport(TransactionReportRequestDTO transactionReportRequestDTO)
        {
            try
            {
                return await _transactionReportService.AddTransactionReportAsync(transactionReportRequestDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionReportResponseDTO>>> GetAllTransactionsReports()
        {
            try
            {
                return await _transactionReportService.GetAllTransactionReportsAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<TransactionReportResponseDTO>> GetTransactionReportById(int id)
        {
            try
            {
                return await _transactionReportService.GetTransactionReportByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateTransactionReport(TransactionReportRequestDTO transactionReportRequestDTO, int id)
        {
            try
            {
                return await _transactionReportService.UpdateTransactionReportAsync(transactionReportRequestDTO, id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteTransactionReport(int id)
        {
            try
            {
                return await _transactionReportService.DeleteTransactionReportAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}