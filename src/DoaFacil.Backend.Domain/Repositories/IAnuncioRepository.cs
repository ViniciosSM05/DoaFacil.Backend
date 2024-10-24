using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Repositories.Base;
using DoaFacil.Backend.Shared.Dtos.Anuncios;

namespace DoaFacil.Backend.Domain.Repositories
{
    public interface IAnuncioRepository : IRepository<Anuncio>
    {
        Task<int> GetMaxCodigoAsync(CancellationToken cancellationToken);
        Task<List<AnuncioLista.Data>> GetAnunciosAsync(AnuncioLista.Filtro filtro, Guid usuarioId, CancellationToken cancellationToken);
    }
}
