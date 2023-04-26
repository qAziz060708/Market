using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Models
{
    public class ShoppingOrder
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
    }
}
