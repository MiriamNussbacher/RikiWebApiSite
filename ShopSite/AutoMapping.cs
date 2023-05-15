using AutoMapper;
using DTO;
using Entities;

namespace ShopSite
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName,
                opts => opts.MapFrom(src => src.Category.Name));
            CreateMap<ProductDTO, Product>();
            CreateMap<Category, CategoryDTO>().ReverseMap();
           
            CreateMap<Order, OrderDTO>().ReverseMap();


            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            //.ForMember(dest => dest.ProductId,
            // opts => opts.MapFrom(src => src.Product.ProductId)).ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
