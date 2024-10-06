using AutoMapper;
using DoaFacil.Backend.Application.Commands.EnderecosUsuario.AddEnderecoUsuario;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;

namespace DoaFacil.Backend.Application.Mapper.Converters.EnderecoConverters
{
    public class AddEnderecoUsuarioCommandToEnderecoUsuarioConverter : ITypeConverter<AddEnderecoUsuarioCommand, EnderecoUsuario>
    {
        public EnderecoUsuario Convert(AddEnderecoUsuarioCommand source, EnderecoUsuario destination, ResolutionContext context)
        {
            destination = new();
            destination.SetCidadeId(source.CidadeId);
            destination.SetUsuarioId(source.UsuarioId);
            destination.SetCep(source.Cep);
            destination.SetBairro(source.Bairro);
            destination.SetNumero(source.Numero.GetValueOrDefault());
            destination.SetRua(source.Rua);

            return destination;
        }
    }
}
