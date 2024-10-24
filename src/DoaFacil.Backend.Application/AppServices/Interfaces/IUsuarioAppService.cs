using DoaFacil.Backend.Shared.Dtos.Ufs;

namespace DoaFacil.Backend.Application.AppServices.Interfaces
{
    public interface IUfAppService
    {
        Task<List<UfDto>> GetAllUfs(CancellationToken cancellationToken);
    }
}
