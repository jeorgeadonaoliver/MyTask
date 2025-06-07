namespace MyTask.Api.Client.Extensions
{
    public static class AuthorizationServiceExtensions
    {
        public static IServiceCollection AddCustomAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBeAdmin", policy =>
                {
                    policy.RequireRole("Admin"); // Simple role-based policy
                });

                options.AddPolicy("MustBeMember", policy =>
                {
                    // Example with a custom requirement
                     //policy.Requirements.Add(new DataOwnerRequirement());
                });
            });

            // Register your custom authorization handlers
            // services.AddSingleton<IAuthorizationHandler, DataOwnerRequirementHandler>();

            return services;
        }
    }
}
