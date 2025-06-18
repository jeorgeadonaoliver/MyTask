using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTask.Application.Contracts;
using StackExchange.Redis;

namespace MyTask.RedisCache
{
    public static class CacheServiceRegistration
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddStackExchangeRedisCache(options => {
                options.Configuration = configuration.GetConnectionString("RedisConnectionString");
                options.InstanceName = "MyTaskCache";
            });

            services.AddSingleton<ICacheService, RedisCacheService>();

            return services;
        }
    }
}
