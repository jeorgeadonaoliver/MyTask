using MediatR;
using MyTask.Api.Client.Extensions;
using MyTask.Api.Client.Interface;
using MyTask.Api.Client.Middleware;
using MyTask.Api.Client.Service;
using MyTask.Application;
using MyTask.Application.Common.Caching;
using MyTask.Persistence;
using MyTask.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddSecurityService();
builder.Services.AddCorsService();
builder.Services.AddMemoryCache();

builder.Services.AddSwaggerDocumentation();
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiServiceExtension();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.RoutePrefix = string.Empty;
    });

    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RateLimitingMiddleware>();

app.UseHttpsRedirection();
app.UseCors("AllowLocalHost3000");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
