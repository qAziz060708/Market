using Market.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface ICategoryService
    {
        Task<int> AddCategoryAsync(Category category);

        Task<int> UpdateCategoryAsync(Category category, int id);

        Task<int> DeleteCategoryAsync(int id);

        Task<Category> GetCategoryByIdAsync(int id);

        Task<List<Category>> GetAllCategoriesAsync();
    }
}
