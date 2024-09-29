using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using DoaFacil.Backend.Domain.Repositories.Base;

namespace DoaFacil.Backend.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<bool> ExistsByCpfCnpjAsync(string cpfCnpj, CancellationToken cancellation);
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellation);
        Task<Usuario> GetByEmailSenhaAsync(string email, string senha, CancellationToken cancellation);
    }
}
