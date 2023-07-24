using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Market.DataAccess.Repositories.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public CustomerRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddCustomerAsync(Customer customer)
        {
            try
            {
                _marketDbContext.Customers.Add(customer);
                await _marketDbContext.SaveChangesAsync();
                return customer.CustomerId;
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

        public async Task<int> DeleteCustomerAsync(Customer customer)
        {
            try
            {
                _marketDbContext.Customers.Remove(customer);
                await _marketDbContext.SaveChangesAsync();
                return customer.CustomerId;
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

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            try
            {
                return await _marketDbContext.Customers
               .Include(u => u.Categories)
               .Include(u => u.Products)
               .Include(u => u.Payments)
               .Include(u => u.Deliveries)
               .Include(u => u.ShoppingOrders)
               .AsSplitQuery()
               .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when was giving customers information");
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            try
            {
                return await _marketDbContext.Customers
               .Include(u => u.Categories)
               .Include(u => u.Products)
               .Include(u => u.Payments)
               .Include(u => u.Deliveries)
               .Include(u => u.ShoppingOrders)
               .AsSplitQuery()
               .FirstOrDefaultAsync(u => u.CustomerId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving CustomerById information");
            }
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                var customerForUpdate = await GetCustomerByIdAsync(customer.CustomerId);
                customerForUpdate.FirstName = customer.FirstName;
                customerForUpdate.LasName = customer.LasName;
                customerForUpdate.Address = customer.Address;
                customerForUpdate.ContactAdd= customer.ContactAdd;
                await _marketDbContext.SaveChangesAsync();
                return customer.CustomerId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was updating changes");
            }
        }
    }
}