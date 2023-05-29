using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.DataAccess.DbConnection;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
                throw new Exception("Operation was failed when it saved changes");
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
                throw new Exception("Operation was failed when it saved changes");
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
               .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed wnet it was given the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
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
               .FirstOrDefaultAsync(u => u.CustomerId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed wnet it was given the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it saved changes");
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
                throw new Exception("Operation was failed when it saved changes");
            }
        }
    }
}
