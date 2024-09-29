using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DoaFacil.Backend.Infra.Database.Repositories
{
    public class UsuarioRepository(IRepositoryContext context) : Repository<Usuario>(context), IUsuarioRepository
    {
        public async Task<bool> ExistsByCpfCnpjAsync(string cpfCnpj, CancellationToken cancellation) 
            => await _dbSet.AnyAsync(x => x.CpfCnpj == cpfCnpj, cancellation);

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellation) 
            => await _dbSet.AnyAsync(x =>x.Email == email, cancellation);

        public async Task<Usuario> GetByEmailSenhaAsync(string email, string senha, CancellationToken cancellation)
            => await _dbSet.FirstOrDefaultAsync(x => x.Email == email && x.Senha == senha, cancellation);
    }
}
