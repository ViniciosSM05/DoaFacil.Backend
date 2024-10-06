using AutoMapper;
using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.CidadeEntity;
using DoaFacil.Backend.Domain.Repositories;

namespace DoaFacil.Backend.Application.Commands.Cidades.AddCidade
{
    public class AddCidadeCommandHandler(IMapper mapper, ICidadeRepository cidadeRepository) : CommandHandler<AddCidadeCommand, Guid>
    {
        public override async Task<Guid> Handle(AddCidadeCommand request, CancellationToken cancellationToken)
        {
            var cidade = await cidadeRepository.GetByNomeEUfIdAsync(request.Nome, request.UfId.GetValueOrDefault(), cancellationToken);
            if (cidade != null) return cidade.Id;

            var cidadeToAdd = mapper.Map<Cidade>(request);
            await cidadeRepository.AddAsync(cidadeToAdd, cancellationToken);

            return cidadeToAdd.Id;
        }
    }
}
