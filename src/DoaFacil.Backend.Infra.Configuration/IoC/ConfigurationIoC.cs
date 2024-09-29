using DoaFacil.Backend.Infra.Configuration.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DoaFacil.Backend.Infra.Configuration.IoC
{
    public static class ConfigurationIoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IDatabaseConfig, DoaFacilConfig>();
            services.AddSingleton<IAuthConfig, DoaFacilConfig>();
        }
    }
}
