using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;
using DoaFacil.Backend.Domain.Repositories;
using FluentValidation;

namespace DoaFacil.Backend.Application.Commands.EnderecosUsuario.AddEnderecoUsuario
{
    public class AddEnderecoUsuarioCommandValidator : CommandValidator<AddEnderecoUsuarioCommand>
    {
        public const string CIDADE_NAO_ECONTRADA_ERROR_MESSAGE = "A cidade não foi encontrada";
        public const string CEP_INVALIDO_ERROR_MESSAGE = "CEP inválido";
        public const string NUMERO_INVALIDO_ERROR_MESSAGE = "Número inválido";
        public const string BAIRRO_INVALIDO_ERROR_MESSAGE = "Bairro inválido";
        public const string CIDADE_INVALIDA_ERROR_MESSAGE = "Cidade inválida";
        public const string USUARIO_NAO_ENCONTRADO_ERROR_MESSAGE = "Usuário não encontrado";
        public const string RUA_INVALIDA_ERROR_MESSAGE = "Rua é inválida";
        private readonly ICidadeRepository cidadeRepository;
        private readonly IUsuarioRepository usuarioRepository;

        public AddEnderecoUsuarioCommandValidator(ICidadeRepository cidadeRepository, IUsuarioRepository usuarioRepository)
        {
            this.cidadeRepository = cidadeRepository;
            this.usuarioRepository = usuarioRepository;
            ApplyRulesToCep();
            ApplyRulesToNumero();
            ApplyRulesToBairro();
            ApplyRulesToCidadeId();
            ApplyRulesToUsuarioId();
            ApplyRulesToRua();
        }

        private void ApplyRulesToCep()
        {
            RuleFor(endereco => endereco.Cep).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MaximumLength(EnderecoUsuario.CEP_MAX_LENGTH)
                .WithMessage(CEP_INVALIDO_ERROR_MESSAGE);
        }

        private void ApplyRulesToNumero()
        {
            RuleFor(endereco => endereco.Numero).Cascade(CascadeMode.Stop)
              .NotEmpty()
              .NotNull()
              .WithMessage(NUMERO_INVALIDO_ERROR_MESSAGE);
        }

        private void ApplyRulesToBairro()
        {
            RuleFor(endereco => endereco.Bairro).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MaximumLength(EnderecoUsuario.BAIRRO_MAX_LENGTH)
                .WithMessage(BAIRRO_INVALIDO_ERROR_MESSAGE);
        }

        private void ApplyRulesToCidadeId()
        {
            RuleFor(endereco => endereco.CidadeId).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MustAsync(async (_, cidadeId, cancellation) => await cidadeRepository.ExistsAsync(cidadeId, cancellation))
                .WithMessage(CIDADE_INVALIDA_ERROR_MESSAGE);
        }

        private void ApplyRulesToUsuarioId()
        {
            RuleFor(endereco => endereco.UsuarioId).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MustAsync(async (_, usuarioId, cancellation) => await usuarioRepository.ExistsAsync(usuarioId, cancellation))
                .WithMessage(USUARIO_NAO_ENCONTRADO_ERROR_MESSAGE);
        }

        private void ApplyRulesToRua()
        {
            RuleFor(endereco => endereco.Rua).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MaximumLength(EnderecoUsuario.RUA_MAX_LENGTH)
                .WithMessage(RUA_INVALIDA_ERROR_MESSAGE);
        }
    }
}
