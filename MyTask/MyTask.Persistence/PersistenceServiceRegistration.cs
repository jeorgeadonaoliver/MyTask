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

            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<IEmployeeProjectsRepository, EmployeeProjectRepository>();
            //services.AddScoped<IJobRepository, JobRepository>();
            //services.AddScoped<IProjectRepository, ProjectRepository>();
            //services.AddScoped<IRoleRepository, RoleRepository>();
            //services.AddScoped<ITeamRepository, TeamRepository>();

            return services;
        }
    }
}
