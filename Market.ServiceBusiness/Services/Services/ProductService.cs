using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            try
            {
                return await _productRepository.AddProductAsync(product);
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

        public async Task<int> DeleteProductAsync(int id)
        {
            try
            {
                var productResult = await _productRepository.GetProductByIdAsync(id);
                if (productResult is not null)
                {
                    return await _productRepository.DeleteProductAsync(productResult);
                }
                else
                {
                    throw new Exception("Object cannot be deleted");
                }
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

        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _productRepository.GetAllProductsAsync();
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

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productRepository.GetProductByIdAsync(id);
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

        public async Task<int> UpdateProductAsync(Product product, int id)
        {
            try
            {
                var productResult = await _productRepository.GetProductByIdAsync(id);
                if (productResult is not null)
                {
                    return await _productRepository.UpdateProductAsync(product);
                }
                else
                {
                    throw new Exception("Object cannot be updated");
                }
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
