using DoaFacil.Backend.Shared.Dtos.Categorias;

namespace DoaFacil.Backend.Application.AppServices.Interfaces
{
    public interface ICategoriaAppService
    {
        Task<List<CategoriaDto>> GetAllCategorias(CancellationToken cancellationToken);
    }
}
