using DoaFacil.Backend.Application.IoC;
using DoaFacil.Backend.Domain.IoC;
using DoaFacil.Backend.Infra.Authentication.IoC;
using DoaFacil.Backend.Infra.Configuration.IoC;
using DoaFacil.Backend.Infra.Database.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DoaFacil.Backend.Infra.IoC
{
    public static class StartupIoC
    {
        public static void Register(IServiceCollection services)
        {
            ConfigurationIoC.Register(services);
            AuthenticationIoC.Register(services);
            DomainIoC.Register(services);
            DatabaseIoC.Register(services);
            ApplicationIoC.Register(services);
        }

        public static void Start(IApplicationBuilder app)
        {
            AuthenticationIoC.Start(app);
            DatabaseIoC.Start(app);
        }
    }
}
