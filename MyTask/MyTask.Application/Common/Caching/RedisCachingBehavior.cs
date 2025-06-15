using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyTask.Application.Common.Caching
{
    public class RedisCachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IDistributedCache _redisCache;

        public RedisCachingBehavior(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is not ICachableQuery cacheable)
                return await next();

            var cachedData = await _redisCache.GetStringAsync(cacheable.CacheKey);
            if (cachedData != null)
            {
                Console.WriteLine("Redis hit: " + cacheable.CacheKey);
                return JsonSerializer.Deserialize<TResponse>(cachedData)!;
            }

            var response = await next();

            var serialized = JsonSerializer.Serialize(response);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = cacheable.AbsoluteExpiration ?? TimeSpan.FromMinutes(5)
            };

            await _redisCache.SetStringAsync(cacheable.CacheKey, serialized, options);
            Console.WriteLine("Redis set: " + cacheable.CacheKey);

            return response;
        }
    }

}
