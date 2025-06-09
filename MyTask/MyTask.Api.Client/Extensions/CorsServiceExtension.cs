namespace MyTask.Api.Client.Extensions
{
    public static class CorsServiceExtension
    {
        public static IServiceCollection AddCorsService(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalHost3000",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:3000")
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
                    });
            });
            return services;
        }
    }
}
