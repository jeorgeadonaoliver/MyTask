using MediatR;
using MyTask.Api.Client.Interface;
using MyTask.Api.Client.Service;
using MyTask.Application.Common.Caching;

namespace MyTask.Api.Client.Extensions
{
    public static class ApiServiceExtension
    {
        public static IServiceCollection AddApiServiceExtension(this IServiceCollection services) {

            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = builder.Configuration["Redis:ConnectionString"];
            //    options.InstanceName = "MyApp:";
            //});
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RedisCachingBehavior<,>));

            services.AddScoped<ICookieService, CookieService> ();

            return services;
        }
    }
}
