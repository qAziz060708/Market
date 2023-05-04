using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Models
{
    public class Seller
    {
        public int SellerId { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }


        public List<Product> Products { get; set; }
    }
}
