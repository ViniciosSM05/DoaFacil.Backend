using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Entities.CategoriaEntity;
using DoaFacil.Backend.Domain.Entities.CidadeEntity;
using DoaFacil.Backend.Domain.Entities.DoacaoEntity;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;
using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Domain.Entities.UfEntity;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using DoaFacil.Backend.Infra.Configuration.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DoaFacil.Backend.Infra.Database.Context
{
    public class DoaFacilDbContext(IDatabaseConfig configuration) : DbContext, IRepositoryContext, IUoWContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Uf> Ufs { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<EnderecoUsuario> EnderecosUsuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<ImagemAnuncio> ImagensAnuncios { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }

        public bool ExistsPendingEntitiesToSave
            => ChangeTracker.Entries().Any(entity => entity.State is EntityState.Added or EntityState.Modified or EntityState.Deleted);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(configuration.ConnectionString, new MySqlServerVersion(new Version(8, 0, 23)));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public void MigrateDatabase()
        {
            var pendingMigrations = Database.GetPendingMigrations();
            if (pendingMigrations != null && pendingMigrations.Any())
                Database.Migrate();
        }

        public bool AllMigrationsApplied()
           => !Database.GetPendingMigrations().Any();

        public void ClearChangeTracker()
            => ChangeTracker.Clear();

        public List<T> GetTrackedItemsOfType<T>(params EntityState[] states)
            => (ChangeTracker.Entries()?.Where(x => x.Entity is T && states.Contains(x.State)) ?? [])
                .Select(x => x.Entity)
                .Cast<T>()
                .ToList();
    }
}
