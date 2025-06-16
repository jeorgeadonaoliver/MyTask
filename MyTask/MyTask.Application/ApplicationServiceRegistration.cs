using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyTask.Application.Common.Behaviors;
using MyTask.Application.Contracts;
using MyTask.Application.Features.AuthenticationManagement.AuthenticateUser;
using MyTask.Application.Features.ProjectManagement.Command;
using MyTask.Application.Features.ProjectStatusManagement.Command.CreateProjectStatus;
using MyTask.Application.Features.ProjectStatusManagement.Command.UpdateProjectStatus;
using MyTask.Application.Features.RoleManagement.Command.CreateUserRole;
using MyTask.Application.Features.RoleManagement.Command.UpdateUserRole;
using MyTask.Application.Features.UserManagement.Command.ChangeUserPassword;
using MyTask.Application.Features.UserManagement.Command.RegisterUser;
using System.Reflection;

namespace MyTask.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));
        services.AddValidatorsFromAssemblyContaining<IValidationMarker>();

        //services.AddValidatorsFromAssemblyContaining<AuthenticateUserCommandValidator>();
        //services.AddValidatorsFromAssemblyContaining<CreateProjectCommandValidation>();
        //services.AddValidatorsFromAssemblyContaining<CreateProjectStatusCommandValidation>();
        //services.AddValidatorsFromAssemblyContaining<UpdateProjectStatusCommandValidation>();
        //services.AddValidatorsFromAssemblyContaining<CreateUserRoleCommandValidation>();
        //services.AddValidatorsFromAssemblyContaining<UpdateUserRoleCommandValidation>();
        //services.AddValidatorsFromAssemblyContaining<ChangeUserPasswordCommandValidation>();
        //services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();
        //services.AddValidatorsFromAssemblyContaining<UpdateUserRoleCommandValidation>();

        return services;
    }
}
