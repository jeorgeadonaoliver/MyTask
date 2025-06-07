using Microsoft.Extensions.DependencyInjection;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Security
{
    public static class SecurityServiceRegistration
    {
        public static IServiceCollection AddSecurityService(this IServiceCollection services) 
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
