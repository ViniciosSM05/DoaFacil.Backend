﻿using AutoMapper;
using DoaFacil.Backend.Application.Commands.Cidades.AddCidade;
using DoaFacil.Backend.Application.Commands.EnderecosUsuario.AddEnderecoUsuario;
using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Application.Dtos.Categorias;
using DoaFacil.Backend.Application.Dtos.Cidades;
using DoaFacil.Backend.Application.Dtos.EnderecosUsuario;
using DoaFacil.Backend.Application.Dtos.Ufs;
using DoaFacil.Backend.Application.Dtos.Usuarios;
using DoaFacil.Backend.Application.Mapper.Converters.AuthConverters;
using DoaFacil.Backend.Application.Mapper.Converters.CategoriaConverters;
using DoaFacil.Backend.Application.Mapper.Converters.CidadeConverters;
using DoaFacil.Backend.Application.Mapper.Converters.EnderecoConverters;
using DoaFacil.Backend.Application.Mapper.Converters.UfConverters;
using DoaFacil.Backend.Application.Mapper.Converters.UsuarioConverters;
using DoaFacil.Backend.Domain.Entities.CategoriaEntity;
using DoaFacil.Backend.Domain.Entities.CidadeEntity;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;
using DoaFacil.Backend.Domain.Entities.UfEntity;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using DoaFacil.Backend.Infra.Authentication.AuthModels.Token;

namespace DoaFacil.Backend.Application.Mapper
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            MapCidade();
            MapEnderecoUsuario();
            MapUsuario();
            MapUf();
            MapCategoria();
            MapAuth();
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
        
        private void MapUf() => CreateMap<Uf, UfDto>().ConvertUsing<UfToUfDtoConverter>();

        private void MapCategoria() => CreateMap<Categoria, CategoriaDto>().ConvertUsing<CategoriaToCategoriaDtoConverter>();

        private void MapAuth() => CreateMap<TokenAuthModel, AuthInfoResultDto>().ConvertUsing<TokenAuthModelToAuthInfoResultDtoConverter>();
    }
}
