using DoaFacil.Backend.Application.Dtos.Categorias;

namespace DoaFacil.Backend.Application.AppServices.Interfaces
{
    public interface ICategoriaAppService
    {
        Task<List<CategoriaDto>> GetAllCategorias(CancellationToken cancellationToken);
    }
}
