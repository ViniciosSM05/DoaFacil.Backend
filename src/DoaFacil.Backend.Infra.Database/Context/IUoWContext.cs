using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DoaFacil.Backend.Infra.Database.Context
{
    public interface IUoWContext : IDisposable
    {
        DatabaseFacade Database { get; }

        bool ExistsPendingEntitiesToSave { get; }

        bool AllMigrationsApplied();

        void ClearChangeTracker();

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        List<T> GetTrackedItemsOfType<T>(params EntityState[] states);

        void MigrateDatabase();

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
