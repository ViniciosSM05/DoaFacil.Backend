using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.DoacaoEntity;
using DoaFacil.Backend.Domain.Repositories;
using FluentValidation;

namespace DoaFacil.Backend.Application.Commands.Doacoes.AddDoacao
{
    public class AddDoacaoCommandValidator : CommandValidator<AddDoacaoCommand>
    {
        public const string USUARIO_NAO_ENCONTRADO_ERROR_MESSAGE = "Usuário não encontrado";
        public const string ANUNCIO_NAO_ENCONTRADO_ERROR_MESSAGE = "Anúncio não encontrado";
        public static string VALOR_INVALIDO_ERROR_MESSAGE => $"Valor deve ser maior que R${Doacao.VALOR_MIN_VALUE}";

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAnuncioRepository _anuncioRepository;


        public AddDoacaoCommandValidator(IUsuarioRepository usuarioRepository, IAnuncioRepository anuncioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _anuncioRepository = anuncioRepository;

            ApplyRulesToUsuarioId();
            ApplyRulesToAnuncioId();
            ApplyRulesToValor();
        }

        private void ApplyRulesToUsuarioId()
        {
            RuleFor(x => x.UsuarioId).Cascade(CascadeMode.Stop)
               .NotEmpty()
               .NotNull()
               .MustAsync(async (_, usuarioId, cancellation) => await _usuarioRepository.ExistsAsync(usuarioId, cancellation))
               .WithMessage(USUARIO_NAO_ENCONTRADO_ERROR_MESSAGE);
        }

        private void ApplyRulesToAnuncioId()
        {
            RuleFor(x => x.AnuncioId).Cascade(CascadeMode.Stop)
               .NotEmpty()
               .NotNull()
               .MustAsync(async (_, anuncioId, cancellation) => await _anuncioRepository.ExistsAsync(anuncioId, cancellation))
               .WithMessage(ANUNCIO_NAO_ENCONTRADO_ERROR_MESSAGE);
        }

        private void ApplyRulesToValor()
        {
            RuleFor(x => x.Valor).Cascade(CascadeMode.Stop)
               .GreaterThan(Doacao.VALOR_MIN_VALUE)
               .WithMessage(VALOR_INVALIDO_ERROR_MESSAGE);
        }
    }
}
