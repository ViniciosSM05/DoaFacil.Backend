using AutoMapper;
using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Application.Dtos.Usuarios;

namespace DoaFacil.Backend.Application.Mapper.Converters.UsuarioConverters
{
    public class AddUsuarioDtoToAddUsuarioCommandConverter : ITypeConverter<AddUsuarioDto, AddUsuarioCommand>
    {
        public AddUsuarioCommand Convert(AddUsuarioDto source, AddUsuarioCommand destination, ResolutionContext context)
            => new()
            {
                Celular = source.Celular,
                CpfCnpj = source.CpfCnpj,
                DataNascimento = source.DataNascimento,
                Email = source.Email,
                Nome = source.Nome,
                Senha = source.Senha,
            };
    }
}
