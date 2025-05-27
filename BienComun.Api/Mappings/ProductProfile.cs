using AutoMapper;
using BienComun.Core.DTOs;
using BienComun.Core.Entities;

namespace BienComun.Api.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier.Name))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
    }
}
