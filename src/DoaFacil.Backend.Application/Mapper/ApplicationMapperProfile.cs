using AutoMapper;
using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Application.Mapper.Converters.UsuarioConverters;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;

namespace DoaFacil.Backend.Application.Mapper
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            MapUsuario();
        }

        private void MapUsuario()
        {
            CreateMap<AddUsuarioCommand, Usuario>().ConvertUsing<AddUsuarioCommandToUsuarioConverter>();
        }
    }
}
