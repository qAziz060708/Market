using AutoMapper;
using Market.DataAccess.Models;
using Market.DataAccess.Repositories.IRepositories;
using Market.ServiceBusiness.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Market.ServiceBusiness.DTO.Request_DTO;
using Market.ServiceBusiness.DTO.Response_DTO;

namespace Market.ServiceBusiness.Services.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;

        public SellerService(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task<int> AddSellerAsync(SellerRequestDTO sellerRequestDTO)
        {
            try
            {
                return await _sellerRepository.AddSellerAsync(_mapper.Map<Seller>(sellerRequestDTO));
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

        public async Task<int> DeleteSellerAsync(int id)
        {
            try
            {
                var sellerResult = await _sellerRepository.GetSellerByIdAsync(id);
                if (sellerResult is not null)
                {
                    return await _sellerRepository.DeleteSellerAsync(sellerResult);
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

        public async Task<List<SellerResponseDTO>> GetAllSellersAsync()
        {
            try
            {
                return _mapper.Map<List<SellerResponseDTO>>(await _sellerRepository.GetAllSellersAsync());
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

        public async Task<SellerResponseDTO> GetSellerByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<SellerResponseDTO>(await _sellerRepository.GetSellerByIdAsync(id));
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

        public async Task<int> UpdateSellerAsync(SellerRequestDTO sellerRequestDTO, int id)
        {
            try
            {
                var sellerResult = await _sellerRepository.GetSellerByIdAsync(id);
                if (sellerResult is not null)
                {
                    sellerResult = _mapper.Map<Seller>(sellerRequestDTO);
                    sellerResult.SellerId = id;
                    return await _sellerRepository.UpdateSellerAsync(sellerResult);
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