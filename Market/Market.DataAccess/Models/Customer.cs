namespace Market.DataAccess.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LasName { get; set; }

        public string FullName { get; set; }

        public string ContactAdd { get; set; }

        public string Address { get; set; }


        public List<Category> Categories { get; set; }

        public List<Product> Products { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Delivery> Deliveries { get; set; }

        public List<ShoppingOrder> ShoppingOrders { get; set;}
    }
}
