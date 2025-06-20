﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyTask.Application.Common.Behaviors;
using MyTask.Application.Contracts;
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

        return services;
    }
}
