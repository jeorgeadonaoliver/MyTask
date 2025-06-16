using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Common.Behaviors
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IMemoryCache _cache;

        public CachingBehavior(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is not ICachableQuery cacheable)
                return await next();

            if (_cache.TryGetValue<TResponse>(cacheable.CacheKey, out var cachedResponse))
            {
                return cachedResponse!;
            }

            var response = await next();

            var options = new MemoryCacheEntryOptions();
            if (cacheable.AbsoluteExpiration.HasValue)
            {
                options.SetAbsoluteExpiration(cacheable.AbsoluteExpiration.Value);
            }

            _cache.Set(cacheable.CacheKey, response, options);

            return response;
        }
    }
}
