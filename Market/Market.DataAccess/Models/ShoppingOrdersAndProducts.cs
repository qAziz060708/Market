namespace Market.DataAccess.Models
{
    public class ShoppingOrdersAndProducts
    {
        public int ShoppingOrdersAndProductsId { get; set; }

        public int ShoppingOrderId { get; set; }

        public int ProductId { get; set; }


        public Product Product { get; set; }

        public ShoppingOrder ShoppingOrder { get; set; }
    }
}
