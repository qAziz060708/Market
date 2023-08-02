using Microsoft.AspNetCore.Mvc;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;
using Market.ServiceBusiness.Services.IServices;

namespace Market.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class DeliveryControlller : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryControlller(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddDelivery(DeliveryRequestDTO deliveryRequestDTO)
        {
            try
            {
                return await _deliveryService.AddDeliveryAsync(deliveryRequestDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DeliveryResponseDTO>>> GetAllDeliveries()
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
        public async Task<ActionResult<DeliveryResponseDTO>> GetDeliveryById(int id)
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
        public async Task<ActionResult<int>> UpdateDelivery(DeliveryRequestDTO deliveryRequestDTO, int id)
        {
            try
            {
                return await _deliveryService.UpdateDeliveryAsync(deliveryRequestDTO, id);
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