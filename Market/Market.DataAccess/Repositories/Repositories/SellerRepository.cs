using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.DataAccess.DbConnection;
using Market.DataAccess.Repositories.IRepositories;

namespace Market.DataAccess.Repositories.Repositories
{
    public class SellerRepository
    {
        private readonly MarketDbContext _marketDbContext;

        public SellerRepository(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }
    }
}
