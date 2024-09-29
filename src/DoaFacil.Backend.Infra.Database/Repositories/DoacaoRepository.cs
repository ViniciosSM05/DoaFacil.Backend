using DoaFacil.Backend.Domain.Entities.DoacaoEntity;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;

namespace DoaFacil.Backend.Infra.Database.Repositories
{
    public class DoacaoRepository(IRepositoryContext context) : Repository<Doacao>(context), IDoacaoRepository
    {
    }
}
