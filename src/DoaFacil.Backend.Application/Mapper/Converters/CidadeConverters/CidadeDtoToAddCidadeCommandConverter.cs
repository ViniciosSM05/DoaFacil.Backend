using AutoMapper;
using DoaFacil.Backend.Application.Commands.Cidades.AddCidade;
using DoaFacil.Backend.Shared.Dtos.Cidades;

namespace DoaFacil.Backend.Application.Mapper.Converters.CidadeConverters
{
    public class CidadeDtoToAddCidadeCommandConverter : ITypeConverter<CidadeDto, AddCidadeCommand>
    {
        public AddCidadeCommand Convert(CidadeDto source, AddCidadeCommand destination, ResolutionContext context)
            => new()
            {
                Nome = source.Nome,
                UfId = source.UfId,
            };
    }
}
