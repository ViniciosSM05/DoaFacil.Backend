using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Repositories;
using FluentValidation;

namespace DoaFacil.Backend.Application.Commands.Anuncios.AddAnuncio
{
    public class AddAnuncioCommandValidator : CommandValidator<AddAnuncioCommand>
    {
        public static string TITULO_INVALIDO_ERROR_MESSAGE => $"O titulo deve ser preenchido e em até {Anuncio.TITULO_MAX_LENGTH} caracteres";
        public static string CHAVE_PIX_INVALIDA_ERROR_MESSAGE => $"A chave pix deve ser preenchida e em até {Anuncio.CHAVE_PIX_MAX_LENGTH} caracteres";
        public static string META_INVALIDA_ERROR_MESSAGE => $"A meta deve ser maior que R${Anuncio.META_MIN_VALUE}";
        public const string DESCRICAO_INVALIDA_ERROR_MESSAGE = $"A descrição deve ser preenchida";
        public const string CATEGORIA_INVALIDA_ERROR_MESSAGE = "A categoria é invalida";
        public const string ANUNCIO_NAO_ENCONTRADO_ERROR_MESSAGE = "Anúncio não encontrado";
        public const string USUARIO_NAO_ENCONTRADO_ERROR_MESSAGE = "Usuário não encontrado";

        private readonly IAnuncioRepository _anuncioRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public AddAnuncioCommandValidator(IAnuncioRepository anuncioRepository, ICategoriaRepository categoriaRepository, IUsuarioRepository usuarioRepository)
        {
            _anuncioRepository = anuncioRepository;
            _categoriaRepository = categoriaRepository;
            _usuarioRepository = usuarioRepository;

            ApplyRulesToMeta();
            ApplyRulesToTitulo();
            ApplyRulesToDescricao();
            ApplyRulesToCategoriaId();
            ApplyRulesToChavePix();
            ApplyRulesToId();
            ApplyRulesToUsuarioId();
        }

        private void ApplyRulesToMeta()
        {
            RuleFor(x => x.Meta)
                .NotEmpty()
                    .WithMessage(META_INVALIDA_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(META_INVALIDA_ERROR_MESSAGE)
                .GreaterThan(Anuncio.META_MIN_VALUE)
                    .WithMessage(META_INVALIDA_ERROR_MESSAGE);
        }

        private void ApplyRulesToTitulo()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                    .WithMessage(TITULO_INVALIDO_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(TITULO_INVALIDO_ERROR_MESSAGE)
                .MaximumLength(Anuncio.TITULO_MAX_LENGTH)
                    .WithMessage(TITULO_INVALIDO_ERROR_MESSAGE);
        }

        private void ApplyRulesToDescricao()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                    .WithMessage(DESCRICAO_INVALIDA_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(DESCRICAO_INVALIDA_ERROR_MESSAGE);
        }

        private void ApplyRulesToCategoriaId()
        {
            RuleFor(x => x.CategoriaId)
                .NotNull()
                    .WithMessage(CATEGORIA_INVALIDA_ERROR_MESSAGE)
                .MustAsync(async (_, categoriaId, cancellation) => await _categoriaRepository.ExistsAsync(categoriaId.GetValueOrDefault(), cancellation))
                    .WithMessage(CATEGORIA_INVALIDA_ERROR_MESSAGE);
        }

        private void ApplyRulesToChavePix()
        {
            RuleFor(x => x.ChavePix)
                .NotEmpty()
                    .WithMessage(CHAVE_PIX_INVALIDA_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(CHAVE_PIX_INVALIDA_ERROR_MESSAGE)
                .MaximumLength(Anuncio.CHAVE_PIX_MAX_LENGTH)
                    .WithMessage(CHAVE_PIX_INVALIDA_ERROR_MESSAGE);
        }

        private void ApplyRulesToId()
        {
            RuleFor(x => x.Id)
                .MustAsync(async (_, id, cancellation) => !id.HasValue || await _anuncioRepository.ExistsAsync(id.GetValueOrDefault(), cancellation))
                    .WithMessage(ANUNCIO_NAO_ENCONTRADO_ERROR_MESSAGE);
        }

        private void ApplyRulesToUsuarioId()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                    .WithMessage(USUARIO_NAO_ENCONTRADO_ERROR_MESSAGE)
                .MustAsync(async (_, usuarioId, cancellation) => await _usuarioRepository.ExistsAsync(usuarioId, cancellation))
                    .WithMessage(USUARIO_NAO_ENCONTRADO_ERROR_MESSAGE);
        }
    }
}
