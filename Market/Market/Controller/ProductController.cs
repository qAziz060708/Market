using Microsoft.AspNetCore.Mvc;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;
using Market.ServiceBusiness.Services.IServices;

namespace Market.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddProduct(ProductRequestDTO productRequestDTO)
        {
            try
            {
                return await _productService.AddProductAsync(productRequestDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ProductResponseDTO>>> GetAllProducts()
        {
            try
            {
                return await _productService.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductResponseDTO>> GetProductById(int id)
        {
            try
            {
                return await _productService.GetProductByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateProduct(int id, ProductRequestDTO productRequestDTO)
        {
            try
            {
                return await _productService.UpdateProductAsync(productRequestDTO, id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteProduct(int id)
        {
            try
            {
                return await _productService.DeleteProductAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
