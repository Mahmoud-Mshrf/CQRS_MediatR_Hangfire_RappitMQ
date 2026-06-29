using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace InfrastructureLayer.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
