using AppCore.Utility.Mapper;
using Greengrocer.DataAccess.Concrete.Context;
using Greengrocer.DataAccess.UOW;
using Microsoft.Extensions.DependencyInjection;

namespace Greengrocer.Infrastructure.DI
{
    public static class DbInstaller
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<GreenGrocerDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IMapper, Mapper>(); //bunu görmüyor neden?

            return services;
        }
    }
}
