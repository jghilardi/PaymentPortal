using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPortal.Domain.Models
{
    public class Payment
    {
        public decimal Amount { get; set; }

        public int CustomerId { get; set; }
    }
}
