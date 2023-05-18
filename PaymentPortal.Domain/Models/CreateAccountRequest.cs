namespace PaymentPortal.Domain.Models
{
    public class CreateAccountRequest
    {
        public int CustomerId { get; set; }
        public string AccountType { get; set; }
    }
}
