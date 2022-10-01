using Microsoft.Extensions.DependencyInjection;

namespace Services.ProductDetail.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
