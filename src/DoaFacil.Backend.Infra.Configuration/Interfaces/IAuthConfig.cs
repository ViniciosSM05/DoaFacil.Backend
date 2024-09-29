namespace DoaFacil.Backend.Infra.Configuration.Interfaces
{
    public interface IAuthConfig
    {
        int TempoDeValidadeDoTokenEmHoras { get; }
        string TokenEncryptKey { get; }
    }
}
