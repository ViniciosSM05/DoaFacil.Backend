using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Infra.Authentication.AuthModels.Token;

namespace DoaFacil.Backend.Application.AppServices.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<Guid> AddUsuarioAsync(AddUsuarioCommand command, CancellationToken cancellationToken);
        Task<TokenAuthModel> AuthenticateAsync(string email, string senha, CancellationToken cancellationToken);
    }
}
