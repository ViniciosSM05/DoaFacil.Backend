using DoaFacil.Backend.Domain.Entities.Base;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;
using DoaFacil.Backend.Domain.Entities.UfEntity;

namespace DoaFacil.Backend.Domain.Entities.CidadeEntity
{
    public class Cidade : BaseEntity
    {
        public const int NOME_MAX_LENGTH = 40;

        public string Nome { get; private set; }
        public Guid UfId { get; private set; } 

        public Uf Uf { get; private set; }
        public ICollection<EnderecoUsuario> Enderecos { get; private set; } = [];

        public void SetNome(string nome) => Nome = nome;
        public void SetUfId(Guid ufId) => UfId = ufId;
        public void SetUf(Uf uf) => Uf = uf;
    }
}
