using DoaFacil.Backend.Application.Commands.Base;
using FluentValidation;
using DoaFacil.Backend.Infra.Crosscutting.Extensions;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;

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
        public const string DATA_NASCIMENTO_INVALIDA_ERROR_MESSAGE = "A data de nascimento é inválida";
        public const string CELULAR_INVALIDO_ERROR_MESSAGE = "O número de celular é inválido";

        private readonly IUsuarioRepository usuarioRepository;

        public AddUsuarioCommandValidator(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;

            ApplyRulesToNome();
            ApplyRulesToEmail();
            ApplyRulesToSenha();
            ApplyRulesToDocumento();
            ApplyRulesToDataNascimento();
            ApplyRulesToCelular();
        }

        private void ApplyRulesToNome()
        {
            RuleFor(usuario => usuario.Nome).Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage(NOME_INVALIDO_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(NOME_INVALIDO_ERROR_MESSAGE)
                .MaximumLength(Usuario.NOME_MAX_LENGTH)
                    .WithMessage(NOME_INVALIDO_ERROR_MESSAGE);
        }

        private void ApplyRulesToDataNascimento()
        {
            RuleFor(usuario => usuario.DataNascimento).Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage(DATA_NASCIMENTO_INVALIDA_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(DATA_NASCIMENTO_INVALIDA_ERROR_MESSAGE);
        }

        private void ApplyRulesToCelular()
        {
            RuleFor(usuario => usuario.Celular).Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage(CELULAR_INVALIDO_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(CELULAR_INVALIDO_ERROR_MESSAGE)
                .Length(Usuario.CELULAR_MAX_LENGTH)
                    .WithMessage(CELULAR_INVALIDO_ERROR_MESSAGE);
        }

        private void ApplyRulesToDocumento()
        {
            RuleFor(usuario => usuario.CpfCnpj).Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage(DOCUMENTO_INVALIDO_ERROR_MESSAGE)
                .NotNull()
                    .WithMessage(DOCUMENTO_INVALIDO_ERROR_MESSAGE)
                .MaximumLength(Usuario.CPFCNPJ_MAX_LENGTH)
                    .WithMessage(DOCUMENTO_INVALIDO_ERROR_MESSAGE)
                .Must((_, cpfcnpj) => cpfcnpj.IsValidCpf() || cpfcnpj.IsValidCnpj())
                    .WithMessage(DOCUMENTO_INVALIDO_ERROR_MESSAGE)
                .MustAsync(async (_, cpfcnpj, cancellation) => !await usuarioRepository.ExistsByCpfCnpjAsync(cpfcnpj, cancellation))
                    .WithMessage(DOCUMENTO_JA_CADASTRADO_ERROR_MESSAGE);
        }

        private void ApplyRulesToEmail()
        {
            RuleFor(usuario => usuario.Email).Cascade(CascadeMode.Stop)
                .NotEmpty()
                     .WithMessage(EMAIL_INVALIDO_ERROR_MESSAGE)
                .NotNull()
                     .WithMessage(EMAIL_INVALIDO_ERROR_MESSAGE)
                .MaximumLength(Usuario.EMAIL_MAX_LENGTH)
                     .WithMessage(EMAIL_INVALIDO_ERROR_MESSAGE)
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
    }
}
