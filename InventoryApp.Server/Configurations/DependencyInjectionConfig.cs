using InventoryApp.Repository.Interfaces;
using InventoryApp.Repository.Repositories;
using InventoryApp.Service.Interfaces;
using InventoryApp.Service.Services;

namespace InventoryApp.Server.Configurations
{
    
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register Repositories
            services.AddScoped<IProductRepository, ProductRepository>();

            // Register Services
            services.AddScoped<IProductService, ProductService>();

            return services; // Return the updated IServiceCollection
        }
    }
}
