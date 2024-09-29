using DoaFacil.Backend.Domain.Entities.CidadeEntity;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DoaFacil.Backend.Infra.Database.Repositories
{
    public class CidadeRepository(IRepositoryContext context) : Repository<Cidade>(context), ICidadeRepository
    {
        public async Task<Cidade> GetByNomeEUfIdAsync(string nome, Guid ufId, CancellationToken cancellation = default)
            => await _dbSet.FirstOrDefaultAsync(x => x.Nome == nome && x.UfId == ufId, cancellation); 
    }
}
