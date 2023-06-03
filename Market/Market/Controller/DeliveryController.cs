using Microsoft.AspNetCore.Mvc;
using Market.DataAccess.Models;
using Market.ServiceBusiness.Services.IServices;
namespace Market.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddDelivery(Delivery delivery)
        {
            try
            {
                return await _deliveryService.AddDeliveryAsync(delivery);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Delivery>>> GetAllDeliveries()
        {
            try
            {
                return await _deliveryService.GetAllDeliveriesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult<Delivery>> GetDeliveryById(int id)
        {
            try
            {
                return await _deliveryService.GetDeliveryByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<int>> UpdateDelivery(Delivery delivery,int id)
        {
            try
            {
                return await _deliveryService.UpdateDeliveryAsync(delivery, id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteDelivery(int id)
        {
            try
            {
                return await _deliveryService.DeleteDeliveryAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
