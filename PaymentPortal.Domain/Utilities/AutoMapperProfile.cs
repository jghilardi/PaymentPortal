using AutoMapper;
using PaymentPortal.Data.Models;
using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>();
        }
    }
}