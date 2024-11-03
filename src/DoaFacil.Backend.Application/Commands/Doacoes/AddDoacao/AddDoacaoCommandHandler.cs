using AutoMapper;
using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.DoacaoEntity;
using DoaFacil.Backend.Domain.Repositories;

namespace DoaFacil.Backend.Application.Commands.Doacoes.AddDoacao
{
    public class AddDoacaoCommandHandler(IMapper mapper, IDoacaoRepository doacaoRepository) : CommandHandler<AddDoacaoCommand, Guid>
    {
        public override async Task<Guid> Handle(AddDoacaoCommand request, CancellationToken cancellationToken)
        {
            var doacao = mapper.Map<Doacao>(request);
            await doacaoRepository.AddAsync(doacao, cancellationToken);
            return doacao.Id;
        }
    }
}
