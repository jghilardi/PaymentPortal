using AutoMapper;
using PaymentPortal.Data.Models;
using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountResponse>();
        }
    }
}