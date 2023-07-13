using Market.DataAccess.Models;

namespace Market.DataAccess.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<int> AddCategoryAsync(Category category);

        Task<int> UpdateCategoryAsync(Category category);

        Task<int> DeleteCategoryAsync(Category category);

        Task<Category> GetCategoryByIdAsync(int id);

        Task<List<Category>> GetAllCategoriesAsync();
    }
}
