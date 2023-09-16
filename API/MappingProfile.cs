using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductsSizes, ProductDto>()
            .IncludeMembers(p => p.Product)
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Product.Id));

        CreateMap<Product, ProductDto>()
            .ForMember(dst => dst.Price, opt => opt.Ignore())
            .ForMember(dst => dst.QuantityInStock, opt => opt.Ignore());

        CreateMap<Size, SizeDto>();
    }

}
