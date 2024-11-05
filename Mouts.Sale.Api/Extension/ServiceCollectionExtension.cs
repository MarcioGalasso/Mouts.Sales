using Microsoft.EntityFrameworkCore;
using Mouts.Sale.Data.DbContexts;
using Mouts.Sale.Data.Repository.Base;
using Mouts.Sale.Domain.Profiles;
using Scrutor;
using Mouts.Sale.Domain.Interface;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

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
                options.UseInMemoryDatabase("InMemory"));
            return services;
        }

        public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SaleProfile));
            return services;
        }
    }
}
