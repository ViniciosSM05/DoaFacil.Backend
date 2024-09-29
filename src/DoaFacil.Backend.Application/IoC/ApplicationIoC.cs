using DoaFacil.Backend.Application.AppServices.Base;
using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Application.Commands.Dispatcher;
using DoaFacil.Backend.Application.Mapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DoaFacil.Backend.Application.IoC
{
    public static class ApplicationIoC
    {
        public static void Register(IServiceCollection services)
        {
            RegisterCommands(services);
            RegisterMappers(services);
            RegisterAppServices(services);
        }

        private static void RegisterCommands(IServiceCollection services)
        {
            services
                .AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Command<>).Assembly))
                .AddValidatorsFromAssembly(typeof(CommandValidator<>).Assembly)
                .AddScoped<ICommandDispatcher, CommandDispatcher>();
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationMapperProfile).Assembly);
        }

        private static void RegisterAppServices(IServiceCollection services)
        {
            var providerTypes = Assembly.GetAssembly(typeof(AppService))
                    .GetTypes().Where(t => t.Namespace != null && t.Namespace.Contains("Application.AppServices"));

            foreach (var intfc in providerTypes.Where(t => t.IsInterface))
            {
                var impl = providerTypes.FirstOrDefault(c => c.IsClass && !c.IsAbstract && intfc.Name == $"I{c.Name}");
                if (impl != null) services.AddScoped(intfc, impl);
            }
        }
    }
}
