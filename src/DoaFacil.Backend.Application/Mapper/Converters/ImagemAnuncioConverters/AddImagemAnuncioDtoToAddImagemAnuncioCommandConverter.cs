using AutoMapper;
using DoaFacil.Backend.Application.Commands.ImagensAnuncio;
using DoaFacil.Backend.Shared.Dtos.ImagensAnuncio;

namespace DoaFacil.Backend.Application.Mapper.Converters.ImagemAnuncioConverters
{
    public class AddImagemAnuncioDtoToAddImagemAnuncioCommandConverter : ITypeConverter<AddImagemAnuncioDto, AddImagemAnuncioCommand>
    {
        public AddImagemAnuncioCommand Convert(AddImagemAnuncioDto source, AddImagemAnuncioCommand destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination = new()
            {
                Nome = source.Nome,
                Tipo = source.Tipo,
                Base64 = source.Base64,
                Principal = source.Principal,
            };

            return destination;
        }
    }
}
