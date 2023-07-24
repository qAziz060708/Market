namespace Market.ServiceBusiness.DTO.Request_DTO
{
    public class PaymentRequestDTO
    {
        public int ShoppingOrderId { get; set; }

        public string PaymentType { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}