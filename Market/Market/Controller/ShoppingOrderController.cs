using Microsoft.AspNetCore.Mvc;
using Market.DataAccess.Models;
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
        public async Task<ActionResult<int>> AddShoppingOrder(ShoppingOrder shoppingOrder)
        {
            try
            {
                return await _shoppingOrderService.AddShoppingOrderAsync(shoppingOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ShoppingOrder>>> GetAllShoppingOrders()
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
        public async Task<ActionResult<ShoppingOrder>> GetShoppingOrderById(int id)
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
        public async Task<ActionResult<int>> UpdateShoppingOrder(ShoppingOrder shoppingOrder, int id)
        {
            try
            {
                return await _shoppingOrderService.UpdateShoppingOrderAsync(shoppingOrder, id);
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
