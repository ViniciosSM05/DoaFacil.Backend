using DoaFacil.Backend.Domain.Entities.Base;
using DoaFacil.Backend.Domain.Entities.CidadeEntity;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;

namespace DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity
{
    public class EnderecoUsuario : BaseEntity
    {
        public const int CEP_MAX_LENGTH = 8;
        public const int RUA_MAX_LENGTH = 100;
        public const int BAIRRO_MAX_LENGTH = 50;

        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public int Numero { get; private set; }
        public Guid CidadeId { get; private set; } 
        public Guid UsuarioId { get; private set; }

        public Cidade Cidade { get; private set; }
        public Usuario Usuario { get; private set; }

        public void SetCep(string cep) => Cep = cep;
        public void SetRua(string rua) => Rua = rua;
        public void SetBairro(string bairro) => Bairro = bairro;
        public void SetNumero(int numero) => Numero = numero;
        public void SetCidadeId(Guid cidadeId) => CidadeId = cidadeId;
        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;
        public void SetCidade(Cidade cidade) => Cidade = cidade;
        public void SetUsuario(Usuario usuario) => Usuario = usuario;
    }
}
