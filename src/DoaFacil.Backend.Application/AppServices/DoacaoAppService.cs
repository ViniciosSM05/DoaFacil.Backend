using AutoMapper;
using DoaFacil.Backend.Application.AppServices.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Commands.Dispatcher;
using DoaFacil.Backend.Application.Commands.Doacoes.AddDoacao;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Infra.Authentication.AuthProviders.User;
using DoaFacil.Backend.Infra.Database.UoW;

namespace DoaFacil.Backend.Application.AppServices
{
    public class DoacaoAppService : AppService, IDoacaoAppService
    {
        private readonly IUserAuthProvider _userAuthProvider;

        public DoacaoAppService(ICommandDispatcher commandDispatcher
            , INotificationReader notifications
            , IUnitOfWork unitOfWork
            , IMapper mapper
            , IUserAuthProvider userAuthProvider) : base(commandDispatcher, notifications, unitOfWork, mapper)
        {
            _userAuthProvider = userAuthProvider;
        }

        public async Task<Guid> AddDoacaoAsync(AddDoacaoCommand command, CancellationToken cancellationToken)
        {
            using (_unitOfWork.Start())
            {
                command.UsuarioId = _userAuthProvider.UserId;
                command.Data = DateTime.Now;

                var doacaoId = await _commandDispatcher.DispatchAsync(command, cancellationToken);

                if (!_notifications.IsValid) return Guid.Empty;

                await _unitOfWork.CommitAsync(cancellationToken);

                return doacaoId;
            }
        }
    }
}
