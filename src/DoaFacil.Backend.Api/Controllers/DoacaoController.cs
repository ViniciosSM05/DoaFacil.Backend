using DoaFacil.Backend.Api.Controllers.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Commands.Doacoes.AddDoacao;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Shared.Dtos.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoaFacil.Backend.Api.Controllers
{
    [Authorize]
    [Route("v{version:apiVersion}/doacoes")]
    public class DoacaoController(INotificationReader notifications, IDoacaoAppService doacaoAppService) : ApiBaseController(notifications)
    {
        [HttpPost]
        public Task<ActionResult<DoaFacilDataResponseDto<Guid>>> AddDoacaoAsync([FromBody] AddDoacaoCommand command, CancellationToken cancellationToken)
            => ExecuteAsync(() => doacaoAppService.AddDoacaoAsync(command, cancellationToken));
    }
}
