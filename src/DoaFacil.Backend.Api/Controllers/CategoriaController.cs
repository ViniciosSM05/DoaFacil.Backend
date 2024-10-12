using DoaFacil.Backend.Api.Controllers.Base;
using DoaFacil.Backend.Api.Dtos.Response;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Dtos.Categorias;
using DoaFacil.Backend.Domain.Notification;
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
