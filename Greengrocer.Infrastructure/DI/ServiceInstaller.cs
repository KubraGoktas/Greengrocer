using Greengrocer.Business.Abstract;
using Greengrocer.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Greengrocer.Infrastructure.DI
{
    public static class ServiceInstaller
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
