using AutoMapper;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> AddCategoryAsync(CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                return await _categoryRepository.AddCategoryAsync(_mapper.Map<Category>(categoryRequestDTO));
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

        public async Task<int> DeleteCategoryAsync(int id)
        {
            try
            {
                var categoryResult = await _categoryRepository.GetCategoryByIdAsync(id);
                if (categoryResult is not null)
                {
                    return await _categoryRepository.DeleteCategoryAsync(categoryResult);
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

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            try
            {
                return _mapper.Map<List<CategoryResponseDTO>>(await _categoryRepository.GetAllCategoriesAsync());
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

        public async Task<CategoryResponseDTO> GetCategoryByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<CategoryResponseDTO>(await _categoryRepository.GetCategoryByIdAsync(id));
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

        public async Task<int> UpdateCategoryAsync(CategoryRequestDTO categoryRequestDTO, int id)
        {
            try
            {
                var categoryResult = await _categoryRepository.GetCategoryByIdAsync(id);
                if (categoryResult is not null)
                {
                    categoryResult = _mapper.Map<Category>(categoryRequestDTO);
                    categoryResult.CategoryId = id;
                    return await _categoryRepository.UpdateCategoryAsync(categoryResult);
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