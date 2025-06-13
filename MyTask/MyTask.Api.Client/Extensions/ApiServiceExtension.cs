using MyTask.Api.Client.Interface;
using MyTask.Api.Client.Service;

namespace MyTask.Api.Client.Extensions
{
    public static class ApiServiceExtension
    {
        public static IServiceCollection AddApiServiceExtension(this IServiceCollection services) {

            services.AddScoped<ICookieService, CookieService> ();

            return services;
        }
    }
}
