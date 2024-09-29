using DoaFacil.Backend.Domain.Entities.CategoriaEntity;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;

namespace DoaFacil.Backend.Infra.Database.Repositories
{
    public class CategoriaRepository(IRepositoryContext context) : Repository<Categoria>(context), ICategoriaRepository
    {
    }
}
