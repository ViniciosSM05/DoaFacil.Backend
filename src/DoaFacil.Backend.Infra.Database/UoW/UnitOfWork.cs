using DoaFacil.Backend.Infra.Database.Context;
using System.Transactions;

namespace DoaFacil.Backend.Infra.Database.UoW
{
    public sealed class UnitOfWork(IUoWContext context) : IUnitOfWork
    {
        public const string COMMIT_INITIALIZED_NOT_STARTED_ERROR_MESSAGE = "Não é possível confirmar a unit of work, pois ela não foi iniciada";
        public const string EXISTS_PENDING_ENTITIES_TO_SAVE_ERROR_MESSAGE = "Não é possível iniciar a unit of work, pois ja há entidades modificadas";
        public const string INITIALIZED_STARTED_ERROR_MESSAGE = "Não é possível iniciar a unit of work, pois ela ja foi iniciada";
        public const string ROLLBACK_INITIALIZED_NOT_STARTED_ERROR_MESSAGE = "Não é possível reverter a unit of work, pois ela não foi iniciada";

        public bool Initialized { get; private set; }

        public int Commit()
        {
            if (!Initialized) throw new TransactionException(COMMIT_INITIALIZED_NOT_STARTED_ERROR_MESSAGE);
            return context.SaveChanges();
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            if (!Initialized)
                throw new TransactionException(COMMIT_INITIALIZED_NOT_STARTED_ERROR_MESSAGE);
            return await context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(Initialized);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            if (!Initialized)
                throw new TransactionException(ROLLBACK_INITIALIZED_NOT_STARTED_ERROR_MESSAGE);

            context.ClearChangeTracker();
        }

        public IUnitOfWork Start()
        {
            if (Initialized)
                throw new TransactionException(INITIALIZED_STARTED_ERROR_MESSAGE);

            if (context.ExistsPendingEntitiesToSave)
                throw new TransactionException(EXISTS_PENDING_ENTITIES_TO_SAVE_ERROR_MESSAGE);

            Initialized = true;
            return this;
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context.ExistsPendingEntitiesToSave)
                    Rollback();

                Initialized = false;
            }
        }
    }
}
