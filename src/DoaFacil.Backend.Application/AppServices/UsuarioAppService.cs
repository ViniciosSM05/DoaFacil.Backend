using AutoMapper;
using DoaFacil.Backend.Application.AppServices.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Commands.Cidades.AddCidade;
using DoaFacil.Backend.Application.Commands.Dispatcher;
using DoaFacil.Backend.Application.Commands.EnderecosUsuario.AddEnderecoUsuario;
using DoaFacil.Backend.Application.Commands.Notifications.AddNotificationMessage;
using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Application.Dtos.Usuarios;
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
        
        public async Task<Guid> AddUsuarioAsync(AddUsuarioDto dto, CancellationToken cancellationToken)
        {
            using (_unitOfWork.Start())
            {
                var addUsuarioCommand = mapper.Map<AddUsuarioCommand>(dto);
                var usuarioId = await _commandDispatcher.DispatchAsync(addUsuarioCommand, cancellationToken);

                var addCidadeCommand = mapper.Map<AddCidadeCommand>(dto.Endereco?.Cidade);
                var cidadeId = await _commandDispatcher.DispatchAsync(addCidadeCommand, cancellationToken);

                var addEnderecoUsuarioCommand = mapper.Map<AddEnderecoUsuarioCommand>(dto.Endereco);
                addEnderecoUsuarioCommand.CidadeId = cidadeId;
                addEnderecoUsuarioCommand.UsuarioId = usuarioId;
                await _commandDispatcher.DispatchAsync(addEnderecoUsuarioCommand, cancellationToken);

                if (!_notifications.IsValid) return Guid.Empty;

                await _unitOfWork.CommitAsync(cancellationToken);
                return usuarioId;
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
