using AutoMapper;
using DoaFacil.Backend.Application.Commands.Anuncios.AddAnuncio;
using DoaFacil.Backend.Domain.Entities.AnuncioEntity;

namespace DoaFacil.Backend.Application.Mapper.Converters.AnuncioConverters
{
    public class AddAnuncioCommandToAnuncioConverter : ITypeConverter<AddAnuncioCommand, Anuncio>
    {
        public Anuncio Convert(AddAnuncioCommand source, Anuncio destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination.SetMeta(source.Meta);
            destination.SetTitulo(source.Titulo);
            destination.SetDescricao(source.Descricao);
            destination.SetCategoriaId(source.CategoriaId.GetValueOrDefault());
            destination.SetChavePix(source.ChavePix);
            destination.SetUsuarioId(source.UsuarioId);
            if (source.Id.GetValueOrDefault() == Guid.Empty) destination.SetData(DateTime.Now);

            return destination;
        }
    }
}
