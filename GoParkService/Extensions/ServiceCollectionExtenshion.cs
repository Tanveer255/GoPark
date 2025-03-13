using GoParkService.BLL.Services;
using GoParkService.Repository;
//using JwtAuthentication.Service;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GoParkService.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        services.AddTransient<IApplicationUserService, ApplicationUserService>();
        services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
        //services.AddSingleton<IJwtAuthenticationService, JwtAuthenticationService>();
        // Register Email Service
        services.AddScoped<IEmailService, EmailService>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));

        return services;
    }
}
