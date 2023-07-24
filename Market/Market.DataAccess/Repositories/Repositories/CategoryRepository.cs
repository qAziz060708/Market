using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                _marketDbContext.Categories.Add(category);
                await _marketDbContext.SaveChangesAsync();
                return category.CategoryId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was adding changes");
            }
        }

        public async Task<int> DeleteCategoryAsync(Category category)
        {
            try
            {
                _marketDbContext.Categories.Remove(category);
                await _marketDbContext.SaveChangesAsync();
                return category.CategoryId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            try
            {
                return await _marketDbContext.Categories
               .Include(u => u.Products)
               .Include(u => u.Customer)
               .AsSplitQuery()
               .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving categories information");
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.Categories
               .Include(u => u.Products)
               .Include(u => u.Customer)
               .AsSplitQuery()
               .FirstOrDefaultAsync(u => u.CategoryId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving CategoryById information");
            }
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            try
            {
                var categoryForUpdate = await GetCategoryByIdAsync(category.CategoryId);
                categoryForUpdate.CategoryName = category.CategoryName;
                categoryForUpdate.CategoryType = category.CategoryType;
                await _marketDbContext.SaveChangesAsync();
                return category.CategoryId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it updating changes");
            }
        }
    }
}