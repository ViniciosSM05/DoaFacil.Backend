namespace DoaFacil.Backend.Shared.Dtos.ImagensAnuncio
{
    public class AddImagemAnuncioDto
    {
        public string Nome { get; set; }
        public string Base64 { get; set; }
        public string Tipo { get; set; }
        public bool Principal { get; set; }
    }
}
