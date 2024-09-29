namespace DoaFacil.Backend.Infra.Database.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Initialized { get; }

        int Commit();

        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        void Rollback();

        IUnitOfWork Start();
    }
}
