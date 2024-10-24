using AutoMapper;
using DoaFacil.Backend.Application.Commands.Anuncios.AddAnuncio;
using DoaFacil.Backend.Shared.Dtos.Anuncios;

namespace DoaFacil.Backend.Application.Mapper.Converters.AnuncioConverters
{
    public class AddAnuncioDtoToAddAnuncioCommandConverter : ITypeConverter<AddAnuncioDto, AddAnuncioCommand>
    {
        public AddAnuncioCommand Convert(AddAnuncioDto source, AddAnuncioCommand destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination = new()
            {
                CategoriaId = source.CategoriaId,
                ChavePix = source.ChavePix,
                Descricao = source.Descricao,
                Id = source.Id,
                Meta = source.Meta,
                Titulo = source.Titulo,
                UsuarioId = source.UsuarioId,
            };

            return destination;
        }
    }
}
