﻿using Microsoft.EntityFrameworkCore;
using Mouts.Sale.Data.DbContexts;
using Mouts.Sale.Data.Repository.Base;
using Mouts.Sale.Domain.Profiles;
using Scrutor;
using Mouts.Sale.Domain.Interface;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Mouts.Sale.Domain.MassageBroker.Consumer;
using MassTransit.BusConfigurators;
using MassTransit.Futures.Contracts;

namespace Mouts.Sale.Api.Extension
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {

            var assemblies = DependencyContext.Default.GetDefaultAssemblyNames().Where(assembly => assembly.FullName.StartsWith("Mouts")).Select(Assembly.Load);

            services.Scan(scan => scan
             .FromAssemblies(assemblies)
             .AddClasses(classes => classes.AssignableTo(typeof(IBaseService)))
             .UsingRegistrationStrategy(RegistrationStrategy.Skip)
             .AsImplementedInterfaces()
             .WithScopedLifetime());

            services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepostirory<>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<SaleDbContext>(options =>
                options.UseInMemoryDatabase("InMemory"), ServiceLifetime.Singleton);
            return services;
        }

        public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SaleProfile));
            return services;

        }
        public static IServiceCollection ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(config =>
            {

                config.AddConsumer<StockManagementConsumer>();
                config.UsingRabbitMq((context, cfg) =>
                {
                    
                    cfg.Host(configuration.GetSection("MessageBus:host").Value, "/", h => { 
                        h.Username(configuration.GetSection("MessageBus:username").Value);
                        h.Password(configuration.GetSection("MessageBus:password").Value); });
                    cfg.ConfigureEndpoints(context);
                });
            });
            
            return services;
        }
    }
}
