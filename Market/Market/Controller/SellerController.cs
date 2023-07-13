using Microsoft.AspNetCore.Mvc;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;
using Market.ServiceBusiness.Services.IServices;
namespace Market.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddSeller(SellerRequestDTO sellerRequestDTO)
        {
            try
            {
                return await _sellerService.AddSellerAsync(sellerRequestDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<SellerResponseDTO>>> GetAllSellers()
        {
            try
            {
                return await _sellerService.GetAllSellersAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<SellerResponseDTO>> GetSellerById(int id)
        {
            try
            {
                return await _sellerService.GetSellerByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateSeller(SellerRequestDTO sellerRequestDTO, int id)
        {
            try
            {
                return await _sellerService.UpdateSellerAsync(sellerRequestDTO, id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteSeller(int id)
        {
            try
            {
                return await _sellerService.DeleteSellerAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
