using DoaFacil.Backend.Application.Commands.Base;

namespace DoaFacil.Backend.Application.Commands.Dispatcher
{
    public interface ICommandDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(Command<TResult> command, CancellationToken cancellationToken = default);
    }
}