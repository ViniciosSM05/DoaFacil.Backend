using DoaFacil.Backend.Shared.Dtos.ImagensAnuncio;

namespace DoaFacil.Backend.Shared.Dtos.Anuncios
{
    public class AddAnuncioDto
    {
        public Guid? Id { get; set; }
        public decimal Meta { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid? CategoriaId { get; set; }
        public string ChavePix { get; set; }
        public Guid UsuarioId { get; set; }
        public AddImagemAnuncioDto Imagem { get; set; }
    }
}
