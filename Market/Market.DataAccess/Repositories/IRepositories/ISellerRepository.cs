using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.DataAccess.Models;

namespace Market.DataAccess.Repositories.IRepositories
{
    public interface ISellerRepository
    {
        Task<int> AddSellerAsync(Seller seller);

        Task<int> UpdateSellerAsync(Seller seller);

        Task<int> DeleteSellerAsync(Seller seller);

        Task<Seller> GetSellerByIdAsync(int id);

        Task<List<Seller>> GetAllSellersAsync();
    }
}
