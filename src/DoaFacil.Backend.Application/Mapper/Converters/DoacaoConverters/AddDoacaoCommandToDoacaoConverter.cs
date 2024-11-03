using AutoMapper;
using DoaFacil.Backend.Application.Commands.Doacoes.AddDoacao;
using DoaFacil.Backend.Domain.Entities.DoacaoEntity;

namespace DoaFacil.Backend.Application.Mapper.Converters.DoacaoConverters
{
    public class AddDoacaoCommandToDoacaoConverter : ITypeConverter<AddDoacaoCommand, Doacao>
    {
        public Doacao Convert(AddDoacaoCommand source, Doacao destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination = new();
            destination.SetValor(source.Valor);
            destination.SetAnuncioId(source.AnuncioId); 
            destination.SetData(source.Data);
            destination.SetUsuarioId(source.UsuarioId); 

            return destination;
        }
    }
}
