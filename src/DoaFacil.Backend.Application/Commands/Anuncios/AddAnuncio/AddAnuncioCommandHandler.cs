using AutoMapper;
using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Repositories;

namespace DoaFacil.Backend.Application.Commands.Anuncios.AddAnuncio
{
    public class AddAnuncioCommandHandler(IMapper mapper, IAnuncioRepository anuncioRepository) : CommandHandler<AddAnuncioCommand, Guid>
    {
        public override async Task<Guid> Handle(AddAnuncioCommand request, CancellationToken cancellationToken)
        {
            var update = request.Id.GetValueOrDefault() != Guid.Empty;

            Anuncio anuncio = update
                ? await anuncioRepository.GetByIdAsync(request.Id.Value, cancellationToken) 
                : new();

            mapper.Map(request, anuncio);

            if (update)
                await anuncioRepository.UpdateAsync(anuncio, cancellationToken);
            else
            {
                anuncio.SetCodigo((await anuncioRepository.GetMaxCodigoAsync(cancellationToken)) + 1);
                await anuncioRepository.AddAsync(anuncio, cancellationToken);
            }

            return anuncio.Id;
        }
    }
}
