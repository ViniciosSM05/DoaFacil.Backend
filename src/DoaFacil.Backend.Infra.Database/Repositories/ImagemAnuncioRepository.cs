using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;

namespace DoaFacil.Backend.Infra.Database.Repositories
{
    public class ImagemAnuncioRepository(IRepositoryContext context) : Repository<ImagemAnuncio>(context), IImagemAnuncioRepository
    {
    }
}
