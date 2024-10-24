using DoaFacil.Backend.Api.Controllers.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Shared.Dtos.Categorias;
using DoaFacil.Backend.Shared.Dtos.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoaFacil.Backend.Api.Controllers
{
    [Route("v{version:apiVersion}/categorias")]
    [Authorize]
    public class CategoriaController(INotificationReader notifications, ICategoriaAppService categoriaAppService) : ApiBaseController(notifications)
    {
        [HttpGet]
        public Task<ActionResult<DoaFacilDataResponseDto<List<CategoriaDto>>>> GetAllCategoriasAsync(CancellationToken cancellationToken)
            => ExecuteAsync(() => categoriaAppService.GetAllCategorias(cancellationToken));
    }
}
