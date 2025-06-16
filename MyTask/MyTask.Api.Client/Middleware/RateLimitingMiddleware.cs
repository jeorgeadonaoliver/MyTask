namespace MyTask.Api.Client.Middleware
{
    public class RateLimitingMiddleware
    {
        private static readonly Dictionary<string, int> _requestCounts = new();
        private readonly RequestDelegate _next;

        public RateLimitingMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            string clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            if (!_requestCounts.ContainsKey(clientIp))
                _requestCounts[clientIp] = 0;

            _requestCounts[clientIp]++;

            if (_requestCounts[clientIp] > 50) // Limit exceeded
            {
                context.Response.StatusCode = 100;
                await context.Response.WriteAsync("Rate limit exceeded.");
                return;
            }

            await _next(context);
        }
    }
}
