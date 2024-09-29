using AutoMapper;
using DoaFacil.Backend.Application.Commands.Cidades.AddCidade;
using DoaFacil.Backend.Domain.Entities.CidadeEntity;

namespace DoaFacil.Backend.Application.Mapper.Converters.CidadeConverters
{
    public class AddCidadeCommandToCidadeConverter : ITypeConverter<AddCidadeCommand, Cidade>
    {
        public Cidade Convert(AddCidadeCommand source, Cidade destination, ResolutionContext context)
        {
            destination = new();
            destination.SetNome(source.Nome);
            destination.SetUfId(source.UfId);   
            return destination;
        }
    }
}
