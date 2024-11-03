using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Entities.Base;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;

namespace DoaFacil.Backend.Domain.Entities.DoacaoEntity
{
    public class Doacao : BaseEntity
    {
        public const decimal VALOR_MIN_VALUE = 0;

        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public Guid AnuncioId { get; private set; } 
        public Guid UsuarioId { get; private set; }

        public Anuncio Anuncio { get; private set; }
        public Usuario Usuario { get; private set; }

        public void SetValor(decimal valor) => Valor = valor;
        public void SetData(DateTime data) => Data = data;
        public void SetAnuncioId(Guid anuncioId) => AnuncioId = anuncioId;
        public void SetAnuncio(Anuncio anuncio) => Anuncio = anuncio;
        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;
        public void SetUsuario(Usuario usuario) => Usuario = usuario;
    }
}
