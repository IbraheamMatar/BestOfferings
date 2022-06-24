using BestOfferings.infrastructure.Services;
using BestOfferings.infrastructure.Services.AuthService;
using BestOfferings.infrastructure.Services.Categories;
using BestOfferings.infrastructure.Services.Files;
using BestOfferings.infrastructure.Services.Markets;
using BestOfferings.infrastructure.Services.Products;
using BestOfferings.infrastructure.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Extentions
{
    public static class ServiceContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMarketService, MarketService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddSingleton<IFileService, FileService>();

            return services;
        }
    }
}