using AutoMapper;
using DoaFacil.Backend.Application.Commands.EnderecosUsuario.AddEnderecoUsuario;
using DoaFacil.Backend.Application.Dtos.EnderecosUsuario;

namespace DoaFacil.Backend.Application.Mapper.Converters.EnderecoConverters
{
    public class EnderecoUsuarioDtoToAddEnderecoUsuarioCommandConverter : ITypeConverter<EnderecoUsuarioDto, AddEnderecoUsuarioCommand>
    {
        public AddEnderecoUsuarioCommand Convert(EnderecoUsuarioDto source, AddEnderecoUsuarioCommand destination, ResolutionContext context)
            => new()
            {
                Bairro = source.Bairro, 
                Cep = source.Cep,
                Numero = source.Numero,
                Rua = source.Rua,
            };
    }
}
