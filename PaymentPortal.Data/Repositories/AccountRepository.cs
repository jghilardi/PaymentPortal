using PaymentPortal.Data.Interfaces;
using PaymentPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPortal.Data.Repositories
{
    public class AccountRepository(PaymentsDbContext dbContext) : BaseRepository<Account>(dbContext), IAccountRepository
    {
    }
}
