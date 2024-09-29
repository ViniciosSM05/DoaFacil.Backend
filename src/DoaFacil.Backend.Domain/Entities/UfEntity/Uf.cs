using DoaFacil.Backend.Domain.Entities.Base;
using DoaFacil.Backend.Domain.Entities.CidadeEntity;

namespace DoaFacil.Backend.Domain.Entities.UfEntity
{
    public class Uf: BaseEntity
    {
        public const int SIGLA_MAX_LENGTH = 2;
        public const int NOME_MAX_LENGTH = 40;

        public string Sigla { get; private set; } 
        public string Nome { get; private set; }

        public ICollection<Cidade> Cidades { get; private set; } = [];

        public void SetSigla(string sigla) => Sigla = sigla;
        public void SetNome(string nome) => Nome = nome;
    }
}
