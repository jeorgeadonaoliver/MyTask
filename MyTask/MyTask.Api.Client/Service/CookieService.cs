using Microsoft.Extensions.Options;
using MyTask.Api.Client.Interface;

namespace MyTask.Api.Client.Service
{
    public class CookieService : ICookieService
    {
        public Task SetToken(HttpResponse response, string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // true in production
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddDays(1),
                Path = "/"
            };

            response.Cookies.Append("authToken", token, cookieOptions);

            return Task.CompletedTask;
        }
    }
}
