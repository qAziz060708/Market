using Microsoft.AspNetCore.Mvc;
using Market.DataAccess.Models;
using Market.ServiceBusiness.Services.IServices;
namespace Market.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddCategory(Category category)
        {
            try
            {
                return await _categoryService.AddCategoryAsync(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            try
            {
                return await _categoryService.GetAllCategoriesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            try
            {
                return await _categoryService.GetCategoryByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<int>> UpdateCategory(int id, Category category)
        {
            try
            {
                return await _categoryService.UpdateCategoryAsync(category, id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteCategory(int id)
        {
            try
            {
                return await _categoryService.DeleteCategoryAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}