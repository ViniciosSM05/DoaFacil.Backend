using DoaFacil.Backend.Api.Controllers.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Shared.Dtos.Anuncios;
using DoaFacil.Backend.Shared.Dtos.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoaFacil.Backend.Api.Controllers
{
    [Authorize]
    [Route("v{version:apiVersion}/anuncios")]
    public class AnuncioController(INotificationReader notifications, IAnuncioAppService anuncioAppService) : ApiBaseController(notifications)
    {
        [HttpPost]
        public Task<ActionResult<DoaFacilDataResponseDto<Guid>>> AddAnuncioAsync([FromBody] AddAnuncioDto dto, CancellationToken cancellationToken)
            => ExecuteAsync(() => anuncioAppService.AddAnuncioAsync(dto, cancellationToken));

        [HttpGet]
        public Task<ActionResult<DoaFacilDataResponseDto<List<AnuncioLista.Data>>>> GetAnunciosAsync([FromQuery] AnuncioLista.Filtro filtro, CancellationToken cancellationToken)
            => ExecuteAsync(() => anuncioAppService.GetAnunciosAsync(filtro, cancellationToken));

        [HttpGet]
        [Route("{id:guid}")]
        public Task<ActionResult<DoaFacilDataResponseDto<AnuncioEditDto>>> GetAnuncioEditAsync(Guid id, CancellationToken cancellationToken)
            => ExecuteAsync(() => anuncioAppService.GetAnuncioEditAsync(id, cancellationToken));
    }
}
