using DoaFacil.Backend.Infra.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DoaFacil.Backend.Infra.Configuration
{
    public class DoaFacilConfig(IConfiguration configuration) : IDatabaseConfig, IAuthConfig
    {
        public string ConnectionString => configuration.GetConnectionString("DoaFacilContext");
        public int TempoDeValidadeDoTokenEmHoras => int.Parse(configuration["Authentication:TempoDeValidadeDoTokenEmHoras"] ?? "0");
        public string TokenEncryptKey => configuration["Authentication:TokenEncryptKey"];
    }
}
