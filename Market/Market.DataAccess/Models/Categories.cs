using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Models
{
    public class Categories
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryType { get; set; }


        public List<Products> products { get; set;}
            
        public Customers customers { get; set; }
    }
}
