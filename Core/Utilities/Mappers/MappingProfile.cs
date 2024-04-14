using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Concretes;
using Entities.Dtos;

namespace Core.Utilities.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>().ForMember(u => u.Roles, opt => opt.MapFrom(u => u.Roles.Select(ur => ur.Role)));
            //CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<ShopDto, Shop>();
            CreateMap<Shop, ShopDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Shipment, ShipmentDto>();
            CreateMap<ShipmentDto, Shipment>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductReviewDto, ProductReview>();
            CreateMap<ProductReview, ProductReviewDto>();
            CreateMap<ProductRateDto, ProductRate>();
            CreateMap<ProductRate, ProductRateDto>();
            CreateMap<ShopReviewDto, ShopReview>();
            CreateMap<ShopReview, ShopReviewDto>();
            CreateMap<ShopRateDto, ShopRate>();
            CreateMap<ShopRate, ShopRateDto>();
            CreateMap<CartDto, Cart>();
            CreateMap<Cart, CartDto>();
            
        }

    }
}
