using Microsoft.Extensions.DependencyInjection;
using WhaleEcommerce.Domain.Interfaces;
using WhaleEcommerce.Domain.Notifications;
using WhaleEcommerce.Domain.Services;
using WhaleEcommerce.Infrastructure.Context;
using WhaleEcommerce.Infrastructure.Repositories;

namespace WhaleEcommerce.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<WhaleECommerceAppContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<INotifyer, Notifyer>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
