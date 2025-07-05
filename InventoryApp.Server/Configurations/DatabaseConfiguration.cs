using InventoryApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Server.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InventoryDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 42)) // match your version
            ));
    }
}
