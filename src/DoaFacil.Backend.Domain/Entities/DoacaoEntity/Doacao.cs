using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Entities.Base;

namespace DoaFacil.Backend.Domain.Entities.DoacaoEntity
{
    public class Doacao : BaseEntity
    {
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public Guid AnuncioId { get; private set; } 

        public Anuncio Anuncio { get; private set; }

        public void SetValor(decimal valor) => Valor = valor;
        public void SetData(DateTime data) => Data = data;
        public void SetAnuncioId(Guid anuncioId) => AnuncioId = anuncioId;
        public void SetAnuncio(Anuncio anuncio) => Anuncio = anuncio;
    }
}
