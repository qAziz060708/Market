using AutoMapper;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> AddProductAsync(ProductRequestDTO productRequestDTO)
        {
            try
            {
                return await _productRepository.AddProductAsync(_mapper.Map<Product>(productRequestDTO));
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

        public async Task<List<ProductResponseDTO>> GetAllProductsAsync()
        {
            try
            {
                return _mapper.Map<List<ProductResponseDTO>>(await _productRepository.GetAllProductsAsync());
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

        public async Task<ProductResponseDTO> GetProductByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<ProductResponseDTO>(await _productRepository.GetProductByIdAsync(id));
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

        public async Task<int> UpdateProductAsync(ProductRequestDTO productRequestDTO, int id)
        {
            try
            {
                var productResult = await _productRepository.GetProductByIdAsync(id);
                if (productResult is not null)
                {
                    productResult.ProductName = productResult.ProductName;
                    return await _productRepository.UpdateProductAsync(productResult);
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
