﻿using DoaFacil.Backend.Shared.Dtos.Anuncios;

namespace DoaFacil.Backend.Application.AppServices.Interfaces
{
    public interface IAnuncioAppService
    {
        Task<Guid> AddAnuncioAsync(AddAnuncioDto dto, CancellationToken cancellationToken);
        Task<List<AnuncioLista.Data>> GetAnunciosAsync(AnuncioLista.Filtro filtro, CancellationToken cancellationToken);
    }
}
