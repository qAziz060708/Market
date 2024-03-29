﻿using Market.DataAccess.Models;

namespace Market.DataAccess.Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomerAsync(Customer customer);

        Task<int> UpdateCustomerAsync(Customer customer);

        Task<int> DeleteCustomerAsync(Customer customer);

        Task<Customer> GetCustomerByIdAsync(int id);

        Task<List<Customer>> GetAllCustomersAsync();
    }
}