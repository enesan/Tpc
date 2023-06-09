﻿using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Files;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Persistence.ApplicationDbContext;
using CleanArchitecture.Infrastructure.Persistence.Interceptors;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Infrastructure.Persistence.TpcDbContext;

namespace CleanArchitecture.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        // if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        // {
        //     services.AddDbContext<ApplicationDbContext>(options =>
        //         options.UseInMemoryDatabase("CleanArchitectureDb"));
        // }
        // else
        // {

        services.AddEntityFrameworkNpgsql()
            .AddDbContext<TpcDbContext>(options =>
                options.UseNpgsql(
                    "Server=localhost:5432;Database=TestDb;Username=postgres;Password=root;Include Error Detail=True",
                    builder => builder.MigrationsAssembly(typeof(TpcDbContext).Assembly.FullName)))
            .AddDbContext<ApplicationDbContext.ApplicationDbContext>(options =>
                options.UseNpgsql(
                    "Server=localhost:5432;Database=TestDb;Username=postgres;Password=root;Include Error Detail=True;",
                    builder => builder.MigrationsAssembly(typeof(Persistence.ApplicationDbContext.ApplicationDbContext).Assembly.FullName)));
        // }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<Persistence.ApplicationDbContext.ApplicationDbContext>());
        services.AddScoped<ITpcDbContext>(provider => provider.GetRequiredService<TpcDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        // services
        //     .AddDefaultIdentity<ApplicationUser>()
        //     .AddRoles<IdentityRole>()
        //     .AddEntityFrameworkStores<ApplicationDbContext>();
        //
        // services.AddIdentityServer()
        //     .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
        services.AddTransient<ICardService, CardService>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}