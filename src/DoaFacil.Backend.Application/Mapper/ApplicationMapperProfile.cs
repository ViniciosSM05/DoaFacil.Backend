using AutoMapper;
using DoaFacil.Backend.Application.Commands.Cidades.AddCidade;
using DoaFacil.Backend.Application.Commands.EnderecosUsuario.AddEnderecoUsuario;
using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Application.Dtos.Cidades;
using DoaFacil.Backend.Application.Dtos.EnderecosUsuario;
using DoaFacil.Backend.Application.Dtos.Usuarios;
using DoaFacil.Backend.Application.Mapper.Converters.CidadeConverters;
using DoaFacil.Backend.Application.Mapper.Converters.EnderecoConverters;
using DoaFacil.Backend.Application.Mapper.Converters.UsuarioConverters;
using DoaFacil.Backend.Domain.Entities.CidadeEntity;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;

namespace DoaFacil.Backend.Application.Mapper
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            MapCidade();
            MapEnderecoUsuario();
            MapUsuario();
        }

        private void MapCidade()
        {
            CreateMap<AddCidadeCommand, Cidade>().ConvertUsing<AddCidadeCommandToCidadeConverter>();
            CreateMap<CidadeDto, AddCidadeCommand>().ConvertUsing<CidadeDtoToAddCidadeCommandConverter>();
        }

        private void MapEnderecoUsuario()
        {
            CreateMap<EnderecoUsuarioDto, AddEnderecoUsuarioCommand>().ConvertUsing<EnderecoUsuarioDtoToAddEnderecoUsuarioCommandConverter>();
            CreateMap<AddEnderecoUsuarioCommand, EnderecoUsuario>().ConvertUsing<AddEnderecoUsuarioCommandToEnderecoUsuarioConverter>();
        }

        private void MapUsuario()
        {
            CreateMap<AddUsuarioCommand, Usuario>().ConvertUsing<AddUsuarioCommandToUsuarioConverter>();
            CreateMap<AddUsuarioDto, AddUsuarioCommand>().ConvertUsing<AddUsuarioDtoToAddUsuarioCommandConverter>();
        }
    }
}
