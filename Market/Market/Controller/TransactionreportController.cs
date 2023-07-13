using Microsoft.AspNetCore.Mvc;
using Market.ServiceBusiness.DTO.Response_DTO;
using Market.ServiceBusiness.Services.IServices;
namespace Market.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionReportController : ControllerBase
    {
        private readonly ITransactionReportService _transactionReport;

        public TransactionReportController(ITransactionReportService transactionReport)
        {
            _transactionReport = transactionReport;
        }

        [HttpGet]

        public async Task<ActionResult<List<TransactionReportResponseDTO>>> GetAllTransactionsReports()
        {
            try
            {
                return await _transactionReport.GetAllTransactionReportsAsync();
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
                return await _transactionReport.GetTransactionReportByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
