using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Domain.Repositories;
using FluentValidation;

namespace DoaFacil.Backend.Application.Commands.ImagensAnuncio
{
    public class AddImagemAnuncioCommandValidator : CommandValidator<AddImagemAnuncioCommand>
    {
        public static string TIPO_MAX_LENGTH_ERROR_MESSAGE => $"O tipo da imagem deve ter um tamanho máximo de {ImagemAnuncio.TIPO_MAX_LENGTH} caracteres";
        public static string NOME_MAX_LENGTH_ERROR_MESSAGE => $"O nome da imagem deve ter um tamanho máximo de {ImagemAnuncio.NOME_MAX_LENGTH} caracteres";
        public const string TIPO_INVALIDO_ERROR_MESSAGE = "Tipo da imagem é inválido";
        public const string NOME_INVALIDO_ERROR_MESSAGE = "Nome da imagem é inválido";
        public const string IMAGEM_INVALIDA_ERROR_MESSAGE = "Por favor, insira uma imagem";
        public const string ANUNCIO_NAO_ENCONTRADO_ERROR_MESSAGE = "Anúncio não encontrado";

        private readonly IAnuncioRepository _anuncioRepository;

        public AddImagemAnuncioCommandValidator(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;

            ApplyRulesToNome();
            ApplyRulesToBase64();
            ApplyRulesToTipo();
            ApplyRulesToAnuncioId();
        }

        private void ApplyRulesToNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                    .WithMessage(NOME_MAX_LENGTH_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(NOME_MAX_LENGTH_ERROR_MESSAGE)
                .MaximumLength(ImagemAnuncio.NOME_MAX_LENGTH)
                    .WithMessage(NOME_INVALIDO_ERROR_MESSAGE);
        }

        private void ApplyRulesToTipo()
        {
            RuleFor(x => x.Tipo)
                .NotEmpty()
                    .WithMessage(TIPO_INVALIDO_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(TIPO_INVALIDO_ERROR_MESSAGE)
                .MaximumLength(ImagemAnuncio.TIPO_MAX_LENGTH)
                    .WithMessage(TIPO_INVALIDO_ERROR_MESSAGE);
        }

        private void ApplyRulesToBase64()
        {
            RuleFor(x => x.Base64)
                .NotEmpty()
                    .WithMessage(IMAGEM_INVALIDA_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(IMAGEM_INVALIDA_ERROR_MESSAGE);
        }

        private void ApplyRulesToAnuncioId()
        {
            RuleFor(x => x.AnuncioId)
                .MustAsync(async (_, anuncioId, cancellation) => await _anuncioRepository.ExistsAsync(anuncioId, cancellation))
                    .WithMessage(ANUNCIO_NAO_ENCONTRADO_ERROR_MESSAGE);
        }
    }
}
