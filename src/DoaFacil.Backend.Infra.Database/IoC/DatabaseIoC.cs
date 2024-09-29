using DoaFacil.Backend.Domain.Repositories.Base;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;
using DoaFacil.Backend.Infra.Database.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DoaFacil.Backend.Infra.Database.IoC
{
    public static class DatabaseIoC
    {
        public static void Register(IServiceCollection services)
        {
            RegisterContext(services);
            RegisterUnitOfWork(services);
            RegisterRepositories(services);
        }

        public static void Start(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<IUoWContext>();
            context.MigrateDatabase();
        }

        private static void RegisterContext(IServiceCollection services)
        {
            services
                .AddDbContext<DoaFacilDbContext>()
                .AddScoped<IRepositoryContext>(sp => sp.GetRequiredService<DoaFacilDbContext>())
                .AddScoped<IUoWContext>(sp => sp.GetRequiredService<DoaFacilDbContext>());
        }

        private static void RegisterUnitOfWork(IServiceCollection services) 
            => services.AddScoped<IUnitOfWork, UnitOfWork>();

        private static void RegisterRepositories(IServiceCollection services)
        {
            var interfacesProviderTypes = Assembly.GetAssembly(typeof(IRepository<>))
                    .GetTypes().Where(t => t.Namespace != null && t.Namespace.Contains("Domain.Repositories"));

            var implementationProviderTypes = Assembly.GetAssembly(typeof(Repository<>))
                    .GetTypes().Where(t => t.Namespace != null && t.Namespace.Contains("Database.Repositories"));

            foreach (var intfc in interfacesProviderTypes.Where(t => t.IsInterface))
            {
                var impl = implementationProviderTypes.FirstOrDefault(c => c.IsClass && !c.IsAbstract && intfc.Name == $"I{c.Name}");
                if (impl != null) services.AddScoped(intfc, impl);
            }
        }
    }
}
