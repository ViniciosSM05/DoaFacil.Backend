using DoaFacil.Backend.Domain.Entities.Base;
using DoaFacil.Backend.Domain.Repositories.Base;
using DoaFacil.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace DoaFacil.Backend.Infra.Database.Repositories.Base
{
    public abstract class Repository<TEntity>(IRepositoryContext context) : IRepository<TEntity>
           where TEntity : BaseEntity
    {
        protected readonly IRepositoryContext _context = context;
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
            => await _dbSet.AddAsync(entity, cancellationToken);
        
        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            => await _dbSet.AddRangeAsync(entities, cancellationToken);

        public virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
            => _dbSet.AnyAsync(entity => entity.Id == id, cancellationToken);

        public virtual Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => _dbSet.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _dbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }
    }
}
