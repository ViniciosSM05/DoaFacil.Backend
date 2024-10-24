using AutoMapper;
using DoaFacil.Backend.Application.Commands.ImagensAnuncio;
using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Infra.Crosscutting.Extensions;

namespace DoaFacil.Backend.Application.Mapper.Converters.ImagemAnuncioConverters
{
    public class AddImagemAnuncioCommandToImagemAnuncioConverter : ITypeConverter<AddImagemAnuncioCommand, ImagemAnuncio>
    {
        public ImagemAnuncio Convert(AddImagemAnuncioCommand source, ImagemAnuncio destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination = new();
            destination.SetNome(source.Nome);
            destination.SetConteudo(source.Base64.Base64ImageToBytes());
            destination.SetTipo(source.Tipo);
            destination.SetPrincipal(true);
            destination.SetAnuncioId(source.AnuncioId);

            return destination;
        }
    }
}
