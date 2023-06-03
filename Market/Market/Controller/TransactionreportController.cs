using Microsoft.AspNetCore.Mvc;
using Market.DataAccess.Models;
using Market.ServiceBusiness.Services.IServices;
namespace Market.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionreportController : ControllerBase
    {
        private readonly ITransactionReportService _transactionReport;
        public TransactionreportController(ITransactionReportService transactionReport)
        {
            _transactionReport = transactionReport;
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddTransactionReport(TransactionReport transactionReport)
        {
            try
            {
                return await _transactionReport.AddTransactionReportAsync(transactionReport);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<TransactionReport>>> GetAllTransactionsReports()
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
        public async Task<ActionResult<TransactionReport>> GetTransactionReportById(int id)
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
        [HttpPut]
        public async Task<ActionResult<int>> UpdateTransactionReport(TransactionReport transactionReport, int id)
        {
            try
            {
                return await _transactionReport.UpdateTransactionReportAsync(transactionReport, id);
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
                return await _transactionReport.DeleteTransactionReportAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
