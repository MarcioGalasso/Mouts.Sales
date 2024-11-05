using AutoMapper;

namespace Mouts.Sale.Domain.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Entities.Sale, Data.Entities.Sale>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
