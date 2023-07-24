namespace Market.DataAccess.Models
{
    public class Seller
    {
        public int SellerId { get; set; }

        public int CategoryId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public Category Category { get; set; }
    }
}