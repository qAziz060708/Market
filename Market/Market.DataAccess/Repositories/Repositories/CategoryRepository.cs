using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.DataAccess.DbConnection;
using System.Data.Entity;

namespace Market.DataAccess.Repositories.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public CategoryRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;  
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            _marketDbContext.Categories.Add(category);
            await _marketDbContext.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task<int> DeleteCategoryAsync(Category category)
        {
            _marketDbContext.Categories.Remove(category);
            await _marketDbContext.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _marketDbContext.Categories
                .Include(u => u.Products)
                .Include(u => u.Customer)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _marketDbContext.Categories
                .Include(u => u.Products)
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(u => u.CategoryId == id);
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            _marketDbContext.Categories.Update(category);
            await _marketDbContext.SaveChangesAsync();
            return category.CategoryId;
        }
    }
}
