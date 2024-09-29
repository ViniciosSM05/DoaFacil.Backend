using DoaFacil.Backend.Application.Commands.Base;
using FluentValidation;
using DoaFacil.Backend.Infra.Crosscutting.Extensions;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;

namespace DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario
{
    public class AddUsuarioCommandValidator : CommandValidator<AddUsuarioCommand>
    {
        public const string NOME_INVALIDO_ERROR_MESSAGE = "Nome é inválido";
        public const string DOCUMENTO_INVALIDO_ERROR_MESSAGE = "Documento é inválido";
        public const string DOCUMENTO_JA_CADASTRADO_ERROR_MESSAGE = "Documento já cadastrado";
        public const string EMAIL_INVALIDO_ERROR_MESSAGE = "E-mail é inválido";
        public const string EMAIL_JA_CADASTRADO_ERROR_MESSAGE = "E-mail já cadastrado";
        public const string SENHA_INVALIDA_ERROR_MESSAGE = "A senha precisa ter entre 8 a 15 caracteres";
        public const string CIDADE_NAO_ECONTRADA_ERROR_MESSAGE = "A cidade não foi encontrada";
        public const string CEP_INVALIDO_ERROR_MESSAGE = "CEP inválido";
        public const string NUMERO_INVALIDO_ERROR_MESSAGE = "Número inválido";
        public const string BAIRRO_INVALIDO_ERROR_MESSAGE = "Bairro inválido";
        public const string CIDADE_INVALIDA_ERROR_MESSAGE = "Cidade inválida";

        private readonly IUsuarioRepository usuarioRepository;
        private readonly ICidadeRepository cidadeRepository;

        public AddUsuarioCommandValidator(IUsuarioRepository usuarioRepository, ICidadeRepository cidadeRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.cidadeRepository = cidadeRepository;

            ApplyRulesToNome();
            ApplyRulesToEmail();
            ApplyRulesToSenha();
            ApplyRulesToDocumento();
            ApplyRulesToEndereco();
        }

        private void ApplyRulesToNome()
        {
            RuleFor(usuario => usuario.Nome).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MaximumLength(Usuario.NOME_MAX_LENGTH)
                .WithMessage(NOME_INVALIDO_ERROR_MESSAGE);
        }

        private void ApplyRulesToDocumento()
        {
            RuleFor(usuario => usuario.CpfCnpj).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MaximumLength(Usuario.CPFCNPJ_MAX_LENGTH)
                .Must((_, cpfcnpj) => cpfcnpj.IsValidCpf() || cpfcnpj.IsValidCnpj())
                    .WithMessage(DOCUMENTO_INVALIDO_ERROR_MESSAGE)
                .MustAsync(async (_, cpfcnpj, cancellation) => !await usuarioRepository.ExistsByCpfCnpjAsync(cpfcnpj, cancellation))
                    .WithMessage(DOCUMENTO_JA_CADASTRADO_ERROR_MESSAGE);
        }

        private void ApplyRulesToEmail()
        {
            RuleFor(usuario => usuario.Email).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MaximumLength(Usuario.EMAIL_MAX_LENGTH)
                .Must((_, email) => email.IsValidEmail())
                    .WithMessage(EMAIL_INVALIDO_ERROR_MESSAGE)
                .MustAsync(async (_, cpfcnpj, cancellation) => !await usuarioRepository.ExistsByEmailAsync(cpfcnpj, cancellation))
                    .WithMessage(EMAIL_JA_CADASTRADO_ERROR_MESSAGE);
        }

        private void ApplyRulesToSenha()
        {
            RuleFor(usuario => usuario.Senha).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8)
                .MaximumLength(15)
                .WithMessage(SENHA_INVALIDA_ERROR_MESSAGE);
        }

        private void ApplyRulesToEndereco()
        {
            RuleFor(usuario => usuario.Cep).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MaximumLength(EnderecoUsuario.CEP_MAX_LENGTH)
                .WithMessage(CEP_INVALIDO_ERROR_MESSAGE);

            RuleFor(usuario => usuario.Numero).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .WithMessage(NUMERO_INVALIDO_ERROR_MESSAGE);

            RuleFor(usuario => usuario.Bairro).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MaximumLength(EnderecoUsuario.BAIRRO_MAX_LENGTH)
                .WithMessage(BAIRRO_INVALIDO_ERROR_MESSAGE);

            RuleFor(usuario => usuario.CidadeId).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MustAsync((_, cidadeId, cancellation) => cidadeRepository.ExistsAsync(cidadeId, cancellation))
                .WithMessage(CIDADE_INVALIDA_ERROR_MESSAGE);
        }
    }
}
