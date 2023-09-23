using API.DTOs;
using API.Entities;
using API.RequestHelpers;
using AutoMapper;

namespace API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dst => dst.InventoryItems, opt => opt.MapFrom(src => src.InventoryItems));

        CreateMap<InventoryItem, List<InventoryItemsDto>>();

        CreateMap<InventoryItem, InventoryItemsDto>();

        CreateMap<Basket, BasketDto>();

        CreateMap<Product, BasketItemDto>();

        CreateMap<InventoryItem, BasketItemDto>();

        CreateMap<BasketItem, BasketItemDto>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dst => dst.PictureUrl, opt => opt.MapFrom(src => src.Product.PictureUrl))
            .ForMember(dst => dst.Brand, opt => opt.MapFrom(src => src.Product.Brand))
            .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Product.Price));
            

        CreateMap<UpdateProductDto, Product>();
        CreateMap<UpdateInventoryItemDto, InventoryItem>();
    }

}
