using AutoMapper;
using BestOfferings.Core.Dtos;
using BestOfferings.Core.ViewModels;
using BestOfferings.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.AutoMapper
{
   public class AutomapperProfile : Profile
    {
    
    public AutomapperProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Category, CategoryPureViewModel>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();



            CreateMap<User, UserViewModel>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.Id, x => x.Ignore());
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UpdateUserDto>();



            // Product Not Intial now 
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductPureViewModel>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>().ForMember(x => x.Image, x => x.Ignore());
            CreateMap<Product, UpdateProductDto>().ForMember(x => x.Image, x => x.Ignore());


            CreateMap<CreateMarketDto, Market>();
            CreateMap<Market, MarketViewModel>();
            CreateMap<Market, ProdMrktVM>();  // New Added
            CreateMap<Market, MarketPureViewModel>();
            CreateMap<UpdateMarketDto, Market>().ForMember(x => x.LogoUrl, x => x.Ignore());
            CreateMap<Market, UpdateMarketDto>().ForMember(x => x.LogoUrl, x => x.Ignore());








        }
    }
   
}
