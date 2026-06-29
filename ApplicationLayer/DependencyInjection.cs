using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg =>
            {// Scan the Application assembly. If you find handlers, register them automatically
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
            return services;
        }
    }
}
