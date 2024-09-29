using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Entities.CategoriaEntity;
using DoaFacil.Backend.Domain.Entities.CidadeEntity;
using DoaFacil.Backend.Domain.Entities.DoacaoEntity;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;
using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Domain.Entities.UfEntity;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DoaFacil.Backend.Infra.Database.Context
{
    public interface IRepositoryContext : IDisposable
    {
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Uf> Ufs { get; set; }
        DbSet<Cidade> Cidades { get; set; }
        DbSet<EnderecoUsuario> EnderecosUsuarios { get; set; }
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Anuncio> Anuncios { get; set; }
        DbSet<ImagemAnuncio> ImagensAnuncios { get; set; }
        DbSet<Doacao> Doacoes { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        ChangeTracker ChangeTracker { get; }
    }
}
