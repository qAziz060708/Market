namespace Market.ServiceBusiness.DTO.Request_DTO
{
    public class ShoppingOrderRequestDTO
    {
        public int CustomerId { get; set; }

        public int PaymentId { get; set; }

        public DateTime ShoppingDate { get; set; }
    }
}