using Microsoft.Extensions.DependencyInjection;
using MyTask.Application.Contracts;

namespace MyTask.Security
{
    public static class SecurityServiceRegistration
    {
        public static IServiceCollection AddSecurityService(this IServiceCollection services) 
        {
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
