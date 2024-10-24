using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DoaFacil.Backend.Infra.Database.Repositories
{
    public class ImagemAnuncioRepository(IRepositoryContext context) : Repository<ImagemAnuncio>(context), IImagemAnuncioRepository
    {
        public async Task<List<ImagemAnuncio>> GetByAnuncioIdAsync(Guid anuncioId, CancellationToken cancellationToken = default)
            => await _dbSet.Where(x => x.AnuncioId == anuncioId).ToListAsync(cancellationToken);
    }
}
