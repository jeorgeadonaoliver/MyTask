using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using MyTask.Persistence.Repository;

namespace MyTask.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddDbContext<MyTaskDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyTaskDbConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectStatusRepository, ProjectStatusRepository>();
            services.AddScoped<IUnitOfWork, MyTaskDbUnitOfWork>();
            services.AddScoped<ISprintRepository, SprintRepository>();
            services.AddScoped<ISprintStatusRepository, SprintStatusRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
