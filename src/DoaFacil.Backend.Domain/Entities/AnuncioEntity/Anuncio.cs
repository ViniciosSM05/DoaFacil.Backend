using DoaFacil.Backend.Domain.Entities.Base;
using DoaFacil.Backend.Domain.Entities.CategoriaEntity;
using DoaFacil.Backend.Domain.Entities.DoacaoEntity;
using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;

namespace DoaFacil.Backend.Domain.Entities.AnuncioEntity
{
    public class Anuncio : BaseEntity
    {
        public const int TITULO_MAX_LENGTH = 40;
        public const int CHAVE_PIX_MAX_LENGTH = 40;

        public int Codigo { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Data { get; private set; }
        public decimal Meta { get; private set; }
        public string ChavePix { get; private set; }
        public Guid CategoriaId { get; private set; } 
        public Guid UsuarioId { get; private set; } 

        public Categoria Categoria { get; private set; }
        public Usuario Usuario { get; private set; }
        public ICollection<ImagemAnuncio> Imagens { get; private set; } = [];
        public ICollection<Doacao> Doacoes { get; private set; } = [];

        public void SetCodigo(int codigo) => Codigo = codigo;
        public void SetTitulo(string titulo) => Titulo = titulo;
        public void SetDescricao(string descricao) => Descricao = descricao;
        public void SetData(DateTime data) => Data = data;
        public void SetMeta(decimal meta) => Meta = meta;
        public void SetChavePix(string chavePix) => ChavePix = chavePix;
        public void SetCategoriaId(Guid categoriaId) => CategoriaId = categoriaId;
        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;
        public void SetCategoria(Categoria categoria) => Categoria = categoria;
        public void SetUsuario(Usuario usuario) => Usuario = usuario;
    }
}
