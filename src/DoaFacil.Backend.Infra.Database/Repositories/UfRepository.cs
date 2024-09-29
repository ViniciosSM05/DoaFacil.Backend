using DoaFacil.Backend.Domain.Entities.UfEntity;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;

namespace DoaFacil.Backend.Infra.Database.Repositories
{
    public class UfRepository(IRepositoryContext context) : Repository<Uf>(context), IUfRepository
    {
    }
}
