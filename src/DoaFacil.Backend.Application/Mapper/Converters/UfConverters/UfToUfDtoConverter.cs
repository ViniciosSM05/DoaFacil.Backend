using AutoMapper;
using DoaFacil.Backend.Domain.Entities.UfEntity;
using DoaFacil.Backend.Shared.Dtos.Ufs;

namespace DoaFacil.Backend.Application.Mapper.Converters.UfConverters
{
    public class UfToUfDtoConverter : ITypeConverter<Uf, UfDto>
    {
        public UfDto Convert(Uf source, UfDto destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination = new()
            {
                Id = source.Id,
                Nome = source.Nome,
                Sigla = source.Sigla,
            };

            return destination;
        }
    }
}
