﻿using DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario;
using DoaFacil.Backend.Application.Dtos.Usuarios;
using DoaFacil.Backend.Infra.Authentication.AuthModels.Token;

namespace DoaFacil.Backend.Application.AppServices.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<Guid> AddUsuarioAsync(AddUsuarioDto command, CancellationToken cancellationToken);
        Task<AuthInfoResultDto> AuthenticateAsync(string email, string senha, CancellationToken cancellationToken);
    }
}
