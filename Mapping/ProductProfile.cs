using AuthJWTAPI.Models.DTOs;
using AuthJWTAPI.Models;
using AutoMapper;

namespace AuthJWTAPI.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())  // Ignorowanie Id podczas tworzenia nowego produktu
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<Product, ProductDTO>();
        }
    }
}
