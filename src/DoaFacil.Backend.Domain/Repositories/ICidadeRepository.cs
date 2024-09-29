using DoaFacil.Backend.Domain.Entities.CidadeEntity;
using DoaFacil.Backend.Domain.Repositories.Base;

namespace DoaFacil.Backend.Domain.Repositories
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        Task<Cidade> GetByNomeEUfIdAsync(string nome, Guid ufId, CancellationToken cancellation = default);
    }
}
