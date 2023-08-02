namespace Market.ServiceBusiness.DTO.Response_DTO
{
    public class PaymentResponseDTO
    {
        public int CategoryId { get; set; }

        public int PaymentId { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentType { get; set; }
    }
}