using DoaFacil.Backend.Infra.Crosscutting.Extensions;

namespace DoaFacil.Backend.Shared.Dtos.Anuncios
{
    public class AnuncioDetalhesDto
    {
        public Guid Id { get; set; }
        public string NomeCategoria { get; set; }
        public string Titulo { get; set; }
        public int Codigo { get; set; }
        public byte[] ImagemBytes { get; set; }
        public string ImagemTipo { get; set; }
        public string ImagemBase64 => ImagemBytes.ConvertImgToBase64(ImagemTipo);
        public decimal Arrecadado { get; set; }
        public decimal Meta { get; set; }
        public int TotalApoiadores { get; set; }
        public string ChavePix { get; set; }
        public DateTime DataAnuncio { get; set; }
        public string Descricao { get; set; }
        public string Anunciante { get; set; }
    }
}
