using DoaFacil.Backend.Api.Controllers.Base;
using DoaFacil.Backend.Api.Dtos.Response;
using DoaFacil.Backend.Api.Dtos.Usuario;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Dtos.Usuarios;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Infra.Authentication.AuthModels.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoaFacil.Backend.Api.Controllers
{
    [AllowAnonymous]
    [Route("v{version:apiVersion}/usuarios")]
    public class UsuarioController(INotificationReader notifications, IUsuarioAppService usuarioAppService) : ApiBaseController(notifications)
    {
        [HttpPost]
        public Task<ActionResult<DoaFacilDataResponseDto<Guid>>> AddUsuarioAsync([FromBody] AddUsuarioDto dto, CancellationToken cancellationToken)
            => ExecuteAsync(() => usuarioAppService.AddUsuarioAsync(dto, cancellationToken));

        [HttpPost("auth")]
        public Task<ActionResult<DoaFacilDataResponseDto<TokenAuthModel>>> AuthenticateAsync(UsuarioLoginDto login, CancellationToken cancellationToken)
            => ExecuteAsync(() => usuarioAppService.AuthenticateAsync(login.Email, login.Senha, cancellationToken));
    }
}
