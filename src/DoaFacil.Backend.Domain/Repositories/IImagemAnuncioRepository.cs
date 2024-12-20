﻿using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Domain.Repositories.Base;

namespace DoaFacil.Backend.Domain.Repositories
{
    public interface IImagemAnuncioRepository : IRepository<ImagemAnuncio>
    {
        Task<List<ImagemAnuncio>> GetByAnuncioIdAsync(Guid anuncioId, CancellationToken cancellationToken);
    }
}
