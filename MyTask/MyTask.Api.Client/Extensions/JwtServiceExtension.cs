using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyTask.Api.Client.Extensions
{
    public static class JwtServiceExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration) 
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secret = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            if (string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
            {
                throw new InvalidOperationException("JWT settings (Secret, Issuer, Audience) are not configured properly.");
            }

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                    ClockSkew = TimeSpan.Zero
                };

                //Preparation for SignalR hub
                //options.Events = new JwtBearerEvents
                //{
                //    OnMessageReceived = context =>
                //    {
                //        // Example: Read token from a custom header or query string
                //        // var accessToken = context.Request.Query["access_token"];
                //        // if (!string.IsNullOrEmpty(accessToken) &&
                //        //     context.Request.Path.StartsWithSegments("/hubs"))
                //        // {
                //        //     context.Token = accessToken;
                //        // }
                //        return Task.CompletedTask;
                //    },
                //    OnAuthenticationFailed = context =>
                //    {
                //        // Log authentication failures
                //        Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                //        return Task.CompletedTask;
                //    },
                //    OnTokenValidated = context =>
                //    {
                //        // Custom logic after token is validated, e.g., fetching user roles from DB
                //        // var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                //        // if (claimsIdentity != null) { /* ... */ }
                //        return Task.CompletedTask;
                //    }
                //};
            });

            return services;
        }
    }
}
