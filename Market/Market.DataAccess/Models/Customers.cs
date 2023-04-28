using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Models
{
    public class Customers
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string ContactAdd { get; set; }

        public string Address { get; set; }


        public List<Categories> categories { get; set; }

        public List<Products> products { get; set; }

        public List<Payment> payments { get; set; }

        public List<Deliveries> deliveries { get; set; }

        public List<ShoppingOrder> shoppingOrders { get; set;}
    }
}
