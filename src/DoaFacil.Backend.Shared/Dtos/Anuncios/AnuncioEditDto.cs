using DoaFacil.Backend.Infra.Crosscutting.Extensions;

namespace DoaFacil.Backend.Shared.Dtos.Anuncios
{
    public class AnuncioEditDto
    {
        public Guid Id { get; set; }
        public decimal Meta { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid CategoriaId { get; set; }
        public string ChavePix { get; set; }
        public ImagemAnuncioEditDto Imagem { get; set; }
    }

    public class ImagemAnuncioEditDto
    {
        public string Nome { get; set; }
        public byte[] Bytes { get; set; }
        public string Base64 => Bytes.ConvertImgToBase64(Tipo);
        public string Tipo { get; set; }
        public bool Principal { get; set; }
    }
}
