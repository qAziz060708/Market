namespace Market.DataAccess.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactAdd { get; set; }

        public string Address { get; set; }


        public List<Delivery> Deliveries { get; set; }

        public List<ShoppingOrder> ShoppingOrders { get; set;}
    }
}