using DoaFacil.Backend.Api.Controllers.Base;
using DoaFacil.Backend.Api.Dtos.Response;
using DoaFacil.Backend.Api.Dtos.Usuario;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Infra.Authentication.AuthModels.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoaFacil.Backend.Api.Controllers
{
    [Route("v{version:apiVersion}/usuarios")]
    public class UsuarioController(INotificationReader notifications, IUsuarioAppService usuarioAppService) : ApiBaseController(notifications)
    {
        [HttpPost]
        [Authorize]
        public Task<ActionResult<DoaFacilDataResponseDto<Guid>>> AddUsuarioAsync([FromBody] AddUsuarioCommand contract, CancellationToken cancellationToken)
            => ExecuteAsync(() => usuarioAppService.AddUsuarioAsync(contract, cancellationToken));

        [HttpPost("auth")]
        [AllowAnonymous]
        public Task<ActionResult<DoaFacilDataResponseDto<TokenAuthModel>>> AuthenticateAsync(UsuarioLoginDto login, CancellationToken cancellationToken)
            => ExecuteAsync(() => usuarioAppService.AuthenticateAsync(login.Email, login.Senha, cancellationToken));
    }
}
