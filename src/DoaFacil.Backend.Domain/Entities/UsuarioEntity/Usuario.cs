using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Entities.Base;
using DoaFacil.Backend.Domain.Entities.DoacaoEntity;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;

namespace DoaFacil.Backend.Domain.Entities.UsuarioEntity
{
    public class Usuario : BaseEntity
    {
        public const int NOME_MAX_LENGTH = 55;
        public const int CPFCNPJ_MAX_LENGTH = 14;
        public const int EMAIL_MAX_LENGTH = 55;
        public const int SENHA_MAX_LENGTH = 255;
        public const int CELULAR_MAX_LENGTH = 11;

        public string Nome { get; private set; }
        public string CpfCnpj { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Celular { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public ICollection<EnderecoUsuario> Enderecos { get; private set; } = [];
        public ICollection<Anuncio> Anuncios { get; private set; } = [];
        public ICollection<Doacao> Doacoes { get; private set; } = [];

        public void SetNome(string nome) => Nome = nome;
        public void SetCpfCnpj(string cpfCnpj) => CpfCnpj = cpfCnpj;
        public void SetEmail(string email) => Email = email;
        public void SetSenha(string senha) => Senha = senha;
        public void SetCelular(string celular) => Celular = celular;
        public void SetDataNascimento(DateTime dataNascimento) => DataNascimento = dataNascimento;
    }
}
