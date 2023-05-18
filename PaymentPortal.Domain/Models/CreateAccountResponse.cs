using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPortal.Domain.Models
{
    public class CreateAccountResponse : BaseResponse
    {
        public string CustomerName { get; set; }
        public long AccountNumber { get; set; }
        public string AccountType { get; set; }
    }
}
