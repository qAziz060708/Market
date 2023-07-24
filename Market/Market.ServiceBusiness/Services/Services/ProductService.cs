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
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<ProductResponseDTO>> GetAllProductsAsync()
        {
            try
            {
                return _mapper.Map<List<ProductResponseDTO>>(await _productRepository.GetAllProductsAsync());
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<ProductResponseDTO>(await _productRepository.GetProductByIdAsync(id));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateProductAsync(ProductRequestDTO productRequestDTO, int id)
        {
            try
            {
                var productResult = await _productRepository.GetProductByIdAsync(id);
                if (productResult is not null)
                {
                    productResult = _mapper.Map<Product>(productRequestDTO);
                    productResult.ProductId = id;
                    return await _productRepository.UpdateProductAsync(productResult);
                }
                else
                {
                    throw new Exception("Object cannot be updated");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was updating changes");
            }
        }
    }
}