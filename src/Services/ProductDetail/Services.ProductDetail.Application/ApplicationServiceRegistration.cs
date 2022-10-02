using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Services.ProductDetail.Application.Features.ProductDetail.Constants;
using Services.ProductDetail.Application.Features.ProductDetail.Rules;
using Services.ProductDetail.Application.Services;

namespace Services.ProductDetail.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductDetailService, ProductDetailService>();

            services.AddScoped<ProductDetailBusinessRules>();
            services.AddScoped<ProductDetailBusinessRulesMessages>();

            services.AddMediatR(typeof(ApplicationServiceRegistration));
            services.AddAutoMapper(typeof(ApplicationServiceRegistration));

            return services;
        }
    }
}
