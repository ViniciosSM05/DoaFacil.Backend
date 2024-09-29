using AutoMapper;
using DoaFacil.Backend.Application.AppServices.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Commands.Dispatcher;
using DoaFacil.Backend.Application.Commands.Notifications.AddNotificationMessage;
using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Domain.Constants;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Authentication.AuthModels.Token;
using DoaFacil.Backend.Infra.Authentication.AuthServices.Token;
using DoaFacil.Backend.Infra.Crosscutting.Extensions;
using DoaFacil.Backend.Infra.Database.UoW;

namespace DoaFacil.Backend.Application.AppServices
{
    public class UsuarioAppService(ICommandDispatcher commandDispatcher
        , INotificationReader notifications
        , IUnitOfWork unitOfWork
        , IMapper mapper
        , IUsuarioRepository usuarioRepository
        , ITokenAuthService tokenAuthService) : AppService(commandDispatcher, notifications, unitOfWork, mapper), IUsuarioAppService
    {
        public const string DEFAULT_ROLE = "user";
        public const string UNAUTHORIZE_ERROR_MESSAGE = "Usuário não encontrado";
        
        public async Task<Guid> AddUsuarioAsync(AddUsuarioCommand command, CancellationToken cancellationToken)
        {
            using (_unitOfWork.Start())
            {
                var result = await _commandDispatcher.DispatchAsync(command, cancellationToken);
                if (!_notifications.IsValid) return Guid.Empty;

                await _unitOfWork.CommitAsync(cancellationToken);
                return result;
            }
        }

        public async Task<TokenAuthModel> AuthenticateAsync(string email, string senha, CancellationToken cancellationToken)
        {
            var user = await ValidateLoginAsync(email, senha, cancellationToken);
            if (user is null) return null;

            var tokenModel = tokenAuthService.GenerateToken(new GenerateTokenAuthModel
            {
                UserEmail = user.Email,
                UserId = user.Id,
                UserName = user.Nome,
                UserRole = DEFAULT_ROLE
            });

            return tokenModel;
        }

        private async Task<Usuario> ValidateLoginAsync(string email, string senha, CancellationToken cancellationToken)
        {
            var user = await usuarioRepository.GetByEmailSenhaAsync(email, EncryptExtensions.Encrypt(senha), cancellationToken);
            if (user is null)
            {
                await _commandDispatcher.DispatchAsync(new AddNotificationMessageCommand(UNAUTHORIZE_ERROR_MESSAGE, ErrorCodes.NOT_FOUND), cancellationToken);
                return null;
            }

            return user;
        }
    }
}
