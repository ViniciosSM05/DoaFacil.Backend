using DoaFacil.Backend.Shared.Dtos.Usuarios;

namespace DoaFacil.Backend.Application.AppServices.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<Guid> AddUsuarioAsync(AddUsuarioDto command, CancellationToken cancellationToken);
        Task<AuthInfoResultDto> AuthenticateAsync(string email, string senha, CancellationToken cancellationToken);
    }
}
