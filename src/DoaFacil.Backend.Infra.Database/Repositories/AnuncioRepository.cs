using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;

namespace DoaFacil.Backend.Infra.Database.Repositories
{
    public class AnuncioRepository(IRepositoryContext context) : Repository<Anuncio>(context), IAnuncioRepository
    {
    }
}
