using Microsoft.Extensions.DependencyInjection;
using Services.ProductDetail.Application.Services;

namespace Services.ProductDetail.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductDetailService, ProductDetailService>();

            return services;
        }
    }
}
