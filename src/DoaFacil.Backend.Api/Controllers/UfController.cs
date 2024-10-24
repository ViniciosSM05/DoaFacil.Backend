using DoaFacil.Backend.Api.Controllers.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Shared.Dtos.Response;
using DoaFacil.Backend.Shared.Dtos.Ufs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoaFacil.Backend.Api.Controllers
{
    [Route("v{version:apiVersion}/ufs")]
    [AllowAnonymous]
    public class UfController(INotificationReader notifications, IUfAppService ufAppService) : ApiBaseController(notifications)
    {
        [HttpGet]
        public Task<ActionResult<DoaFacilDataResponseDto<List<UfDto>>>> GetAllUfsAsync(CancellationToken cancellationToken)
            => ExecuteAsync(() => ufAppService.GetAllUfs(cancellationToken));
    }
}
