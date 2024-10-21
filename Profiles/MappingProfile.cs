using AutoMapper;
using ProductCategoryApi.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductCategory>()
            .ForMember(dest => dest.PriceDisplay, opt => opt.MapFrom(src => $"${src.Price:F2}"))
            .ForMember(dest => dest.ProductCategoryName, opt => opt.Ignore()); // Cần xử lý riêng category name
    }
}
