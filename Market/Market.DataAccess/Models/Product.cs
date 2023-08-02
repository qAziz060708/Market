namespace Market.DataAccess.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public int ShoppingOrdersAndProductsId { get; set; }


        public Category Category { get; set; }

        public List<ShoppingOrdersAndProducts> ShoppingOrdersAndProducts { get; set; }
    }
}