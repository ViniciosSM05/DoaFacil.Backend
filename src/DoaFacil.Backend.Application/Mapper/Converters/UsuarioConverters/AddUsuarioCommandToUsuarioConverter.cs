using AutoMapper;
using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using DoaFacil.Backend.Infra.Crosscutting.Extensions;

namespace DoaFacil.Backend.Application.Mapper.Converters.UsuarioConverters
{
    public class AddUsuarioCommandToUsuarioConverter : ITypeConverter<AddUsuarioCommand, Usuario>
    {
        public Usuario Convert(AddUsuarioCommand source, Usuario destination, ResolutionContext context)
        {
            EnderecoUsuario endereco = new();
            endereco.SetCidadeId(source.CidadeId);
            endereco.SetCep(source.Cep);
            endereco.SetBairro(source.Bairro);
            endereco.SetNumero(source.Numero);
            endereco.SetRua(source.Rua);

            destination = new();
            destination.SetNome(source.Nome);
            destination.SetCpfCnpj(source.CpfCnpj);
            destination.SetEmail(source.Email);
            destination.SetCelular(source.Celular);
            destination.SetSenha(EncryptExtensions.Encrypt(source.Senha));
            destination.SetDataNascimento(source.DataNascimento);
            destination.Enderecos.Add(endereco);

            return destination;
        }
    }
}
