using AutoMapper;
using DoaFacil.Backend.Application.AppServices.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Commands.Cidades.AddCidade;
using DoaFacil.Backend.Application.Commands.Dispatcher;
using DoaFacil.Backend.Application.Commands.EnderecosUsuario.AddEnderecoUsuario;
using DoaFacil.Backend.Application.Commands.Notifications.AddNotificationFieldMessage;
using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Domain.Constants;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Authentication.AuthModels.Token;
using DoaFacil.Backend.Infra.Authentication.AuthServices.Token;
using DoaFacil.Backend.Infra.Crosscutting.Extensions;
using DoaFacil.Backend.Infra.Database.UoW;
using DoaFacil.Backend.Shared.Dtos.Usuarios;

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
        public const string UNAUTHORIZE_ERROR_MESSAGE = "Combinação de email e senha inválida";
        public const string EMAIL_EMPTY_ERROR_MESSAGE = "Por favor, preencha o e-mail";
        public const string SENHA_EMPTY_ERROR_MESSAGE = "Por favor, preencha a senha";
        
        public async Task<Guid> AddUsuarioAsync(AddUsuarioDto dto, CancellationToken cancellationToken)
        {
            using (_unitOfWork.Start())
            {
                var addUsuarioCommand = _mapper.Map<AddUsuarioCommand>(dto);
                var usuarioId = await _commandDispatcher.DispatchAsync(addUsuarioCommand, cancellationToken);

                var addCidadeCommand = _mapper.Map<AddCidadeCommand>(dto.Endereco?.Cidade);
                var cidadeId = await _commandDispatcher.DispatchAsync(addCidadeCommand, cancellationToken);

                var addEnderecoUsuarioCommand = _mapper.Map<AddEnderecoUsuarioCommand>(dto.Endereco);
                addEnderecoUsuarioCommand.CidadeId = cidadeId;
                addEnderecoUsuarioCommand.UsuarioId = usuarioId;
                await _commandDispatcher.DispatchAsync(addEnderecoUsuarioCommand, cancellationToken);

                if (!_notifications.IsValid) return Guid.Empty;

                await _unitOfWork.CommitAsync(cancellationToken);
                return usuarioId;
            }
        }

        public async Task<AuthInfoResultDto> AuthenticateAsync(string email, string senha, CancellationToken cancellationToken)
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

            var result = _mapper.Map<AuthInfoResultDto>(tokenModel);
            result.User.Nome = user.Nome;
            result.User.Id = user.Id;   
            result.User.Email = user.Email;

            return result;
        }

        private async Task<Usuario> ValidateLoginAsync(string email, string senha, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(email)) 
                await _commandDispatcher.DispatchAsync(new AddNotificationFieldMessageCommand(nameof(email), EMAIL_EMPTY_ERROR_MESSAGE, ErrorCodes.GENERIC), cancellationToken);

            if (string.IsNullOrWhiteSpace(senha)) 
                await _commandDispatcher.DispatchAsync(new AddNotificationFieldMessageCommand(nameof(senha), SENHA_EMPTY_ERROR_MESSAGE, ErrorCodes.GENERIC), cancellationToken);

            if (!_notifications.IsValid) return null;

            var user = await usuarioRepository.GetByEmailSenhaAsync(email, EncryptExtensions.Encrypt(senha), cancellationToken);
            if (user is null)
            {
                await _commandDispatcher.DispatchAsync(new AddNotificationFieldMessageCommand(nameof(email), UNAUTHORIZE_ERROR_MESSAGE, ErrorCodes.NOT_FOUND), cancellationToken);
                return null;
            }

            return user;
        }
    }
}
