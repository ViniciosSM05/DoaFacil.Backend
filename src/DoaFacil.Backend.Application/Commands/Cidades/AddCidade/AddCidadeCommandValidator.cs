using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.CidadeEntity;
using DoaFacil.Backend.Domain.Repositories;
using FluentValidation;

namespace DoaFacil.Backend.Application.Commands.Cidades.AddCidade
{
    public class AddCidadeCommandValidator : CommandValidator<AddCidadeCommand>
    {
        public const string CIDADE_INVALIDA_ERROR_MESSAGE = "Cidade inválida";
        public const string UF_INVALIDA_ERROR_MESSAGE = "Uf inválida";
        private readonly IUfRepository ufRepository;

        public AddCidadeCommandValidator(IUfRepository ufRepository)
        {
            this.ufRepository = ufRepository;
            ApplyRulesToNome();
            ApplyRulesToUfId();
        }

        private void ApplyRulesToNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MaximumLength(Cidade.NOME_MAX_LENGTH)
                .WithMessage(CIDADE_INVALIDA_ERROR_MESSAGE);
        }

        private void ApplyRulesToUfId()
        {
            RuleFor(x => x.UfId)
                .NotEmpty()
                .NotNull()
                .MustAsync(async (_, ufId, cancellation) => await ufRepository.ExistsAsync(ufId, cancellation))
                .WithMessage(UF_INVALIDA_ERROR_MESSAGE);
        }
    }
}
