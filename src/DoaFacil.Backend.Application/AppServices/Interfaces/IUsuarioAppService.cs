using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Application.Dtos.Ufs;

namespace DoaFacil.Backend.Application.AppServices.Interfaces
{
    public interface IUfAppService
    {
        Task<List<UfDto>> GetAllUfs(CancellationToken cancellationToken);
    }
}
