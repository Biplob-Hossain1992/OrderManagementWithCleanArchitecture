using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Application.Interfaces.IServices;
using OrderManagement.Application.Services;
using OrderManagement.Infrastructure.Repositories;

namespace OrderManagement.Infrastructure.Service
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<ISeedDataRepository, SeedDataRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
