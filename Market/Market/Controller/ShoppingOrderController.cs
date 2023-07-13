using Microsoft.AspNetCore.Mvc;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;
using Market.ServiceBusiness.Services.IServices;
namespace Market.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingOrderController : ControllerBase
    {
        private readonly IShoppingOrderService _shoppingOrderService;
        public ShoppingOrderController(IShoppingOrderService shoppingOrderService)
        {
            _shoppingOrderService = shoppingOrderService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddShoppingOrder(ShoppingOrderRequestDTO shoppingOrderRequestDTO)
        {
            try
            {
                return await _shoppingOrderService.AddShoppingOrderAsync(shoppingOrderRequestDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ShoppingOrderResponseDTO>>> GetAllShoppingOrders()
        {
            try
            {
                return await _shoppingOrderService.GetAllShoppingOrdersAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<ShoppingOrderResponseDTO>> GetShoppingOrderById(int id)
        {
            try
            {
                return await _shoppingOrderService.GetShoppingOrderByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateShoppingOrder(ShoppingOrderRequestDTO shoppingOrderRequestDTO, int id)
        {
            try
            {
                return await _shoppingOrderService.UpdateShoppingOrderAsync(shoppingOrderRequestDTO, id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteShoppingOrder(int id)
        {
            try
            {
                return await _shoppingOrderService.DeleteShoppingOrderAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
