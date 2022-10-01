using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.ProductDetail.Persistence.Settings;

namespace Services.ProductDetail.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDatabaseSettings>(sp =>
            {
                return configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            });

            return services;
        } 
    }
}

