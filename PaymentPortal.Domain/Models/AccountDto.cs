using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPortal.Domain.Models
{
    public class AccountDto
    {
        public long AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
