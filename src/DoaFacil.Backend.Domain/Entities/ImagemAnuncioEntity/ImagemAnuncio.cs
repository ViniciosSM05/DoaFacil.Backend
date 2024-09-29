using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Entities.Base;

namespace DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity
{
    public class ImagemAnuncio : BaseEntity
    {
        public const int URL_MAX_LENGTH = 100;

        public bool Principal { get; private set; }
        public string Url { get; private set; }
        public Guid AnuncioId { get; private set; } 

        public Anuncio Anuncio { get; private set; }

        public void SetPrincipal(bool principal) => Principal = principal;
        public void SetUrl(string url) => Url = url;
        public void SetAnuncioId(Guid anuncioId) => AnuncioId = anuncioId;
        public void SetAnuncio(Anuncio anuncio) => Anuncio = anuncio;
    }
}
