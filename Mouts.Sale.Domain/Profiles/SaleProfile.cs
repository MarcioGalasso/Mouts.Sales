using AutoMapper;
using Mouts.Sale.Data.External;
using Mouts.Sale.Domain.MassageBroker.Events;

namespace Mouts.Sale.Domain.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Domain.Entities.Sale, Data.Entities.Sale>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.Discounts, opt => opt.MapFrom(src => src.Discont))
                .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.SalesId))
                .ForMember(dest => dest.EnterpriseId, opt => opt.MapFrom(src => src.EnterpriseId))
                .ForMember(dest => dest.CustomerExternalId, opt => opt.MapFrom(src => src.CustomerId))
                .ReverseMap();

            //CreateMap<Domain.Entities.Sale, CustomerExternal>()
            //    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            //    .ReverseMap();

            //CreateMap<Domain.Entities.Sale, EnterpriseExternal>()
            //    .ForMember(dest => dest.EnterpriseId, opt => opt.MapFrom(src => src.EnterpriseId))
            //    .ReverseMap();

            CreateMap< Data.Entities.SaleDiscounts, Domain.Entities.SaleDiscount>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

            CreateMap<Data.Entities.SaleItems, Domain.Entities.SaleItems>()
                .ForMember(dest => dest.ProductExternalId, opt => opt.MapFrom(src => src.ProductExternalId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount)).ReverseMap();

            CreateMap<Domain.Entities.Sale, Domain.MassageBroker.Events.SaleCreated>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.Discont, opt => opt.MapFrom(src => src.Discont))
                .ForMember(dest => dest.SalesId, opt => opt.MapFrom(src => src.SalesId))
                .ForMember(dest => dest.EnterpriseId, opt => opt.MapFrom(src => src.EnterpriseId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId)).ReverseMap();

                CreateMap<Domain.Entities.SaleDiscount, Domain.MassageBroker.Events.SaleDiscountCreated>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

            CreateMap<Domain.Entities.SaleItems, SaleItemsCreated>()
                .ForMember(dest => dest.ProductExternalId, opt => opt.MapFrom(src => src.ProductExternalId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount)).ReverseMap();
        }
    }
}
