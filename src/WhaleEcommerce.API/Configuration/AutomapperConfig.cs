using AutoMapper;
using WhaleEcommerce.API.Dtos;
using WhaleEcommerce.Domain.Models;

namespace WhaleEcommerce.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
