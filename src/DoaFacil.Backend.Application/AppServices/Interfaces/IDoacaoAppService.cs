using DoaFacil.Backend.Application.Commands.Doacoes.AddDoacao;

namespace DoaFacil.Backend.Application.AppServices.Interfaces
{
    public interface IDoacaoAppService
    {
        Task<Guid> AddDoacaoAsync(AddDoacaoCommand command, CancellationToken cancellationToken);
    }
}
