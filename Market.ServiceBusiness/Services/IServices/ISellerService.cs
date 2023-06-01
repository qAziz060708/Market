using Market.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ServiceBusiness.Services.IServices
{
    public interface ISellerService
    {
        Task<int> AddSellerAsync(Seller seller);

        Task<int> UpdateSellerAsync(Seller seller, int id);

        Task<int> DeleteSellerAsync(int id);

        Task<Seller> GetSellerByIdAsync(int id);

        Task<List<Seller>> GetAllSellersAsync();
    }
}
