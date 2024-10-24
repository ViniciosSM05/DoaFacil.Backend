using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Entities.Base;

namespace DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity
{
    public class ImagemAnuncio : BaseEntity
    {
        public const int NOME_MAX_LENGTH = 150;
        public const int TIPO_MAX_LENGTH = 50;

        public string Nome { get; set; }
        public byte[] Conteudo { get; private set; }
        public string Tipo { get; set; }
        public bool Principal { get; private set; }
        public Guid AnuncioId { get; private set; } 

        public Anuncio Anuncio { get; private set; }

        public void SetNome(string nome) => Nome = nome;
        public void SetTipo(string tipo) => Tipo = tipo;
        public void SetPrincipal(bool principal) => Principal = principal;
        public void SetConteudo(byte[] conteudo) => Conteudo = conteudo;
        public void SetAnuncioId(Guid anuncioId) => AnuncioId = anuncioId;
        public void SetAnuncio(Anuncio anuncio) => Anuncio = anuncio;
    }
}
