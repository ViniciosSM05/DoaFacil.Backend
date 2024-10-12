using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Entities.Base;

namespace DoaFacil.Backend.Domain.Entities.CategoriaEntity
{
    public class Categoria : BaseEntity
    {
        public const int NOME_MAX_LENGTH = 40;

        public Categoria()
        {
            
        }

        public Categoria(Guid id, string nome)
        {
            SetId(id);
            SetNome(nome);
        }

        public string Nome { get; private set; }

        public ICollection<Anuncio> Anuncios { get; private set; } = [];

        public void SetNome(string nome) => Nome = nome;
    }
}
