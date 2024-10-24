using AutoMapper;
using DoaFacil.Backend.Domain.Entities.CategoriaEntity;
using DoaFacil.Backend.Shared.Dtos.Categorias;

namespace DoaFacil.Backend.Application.Mapper.Converters.CategoriaConverters
{
    public class CategoriaToCategoriaDtoConverter : ITypeConverter<Categoria, CategoriaDto>
    {
        public CategoriaDto Convert(Categoria source, CategoriaDto destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination = new()
            {
                Id = source.Id,
                Nome = source.Nome,
            };

            return destination;
        }
    }
}
