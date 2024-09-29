using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;

namespace DoaFacil.Backend.Infra.Database.Repositories
{
    public class EnderecoUsuarioRepository(IRepositoryContext context) : Repository<EnderecoUsuario>(context), IEnderecoUsuarioRepository
    {
    }
}
