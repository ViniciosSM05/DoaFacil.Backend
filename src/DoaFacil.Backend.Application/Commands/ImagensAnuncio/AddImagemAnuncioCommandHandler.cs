using AutoMapper;
using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Domain.Repositories;

namespace DoaFacil.Backend.Application.Commands.ImagensAnuncio
{
    public class AddImagemAnuncioCommandHandler(IMapper mapper, IImagemAnuncioRepository imagemAnuncioRepository) : CommandHandler<AddImagemAnuncioCommand, Guid>
    {
        public override async Task<Guid> Handle(AddImagemAnuncioCommand request, CancellationToken cancellationToken)
        {
            await DeleteImagensDoAnuncio(request.AnuncioId, cancellationToken);

            var imagemAnuncio = mapper.Map<ImagemAnuncio>(request);
            await imagemAnuncioRepository.AddAsync(imagemAnuncio, cancellationToken);

            return imagemAnuncio.Id;
        }

        private async Task DeleteImagensDoAnuncio(Guid anuncioId, CancellationToken cancellationToken)
        {
            var imagensAdicionadas = await imagemAnuncioRepository.GetByAnuncioIdAsync(anuncioId, cancellationToken);
            await imagemAnuncioRepository.DeleteRangeAsync(imagensAdicionadas, cancellationToken);
        }
    }
}
