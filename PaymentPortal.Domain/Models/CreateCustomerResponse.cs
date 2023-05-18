namespace PaymentPortal.Domain.Models
{
    public class CreateCustomerResponse : BaseResponse
    {
        public string FullName { get; set; }
        public int CustomerId { get; set; }
    }
}
