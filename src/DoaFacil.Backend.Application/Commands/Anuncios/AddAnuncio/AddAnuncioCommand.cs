using DoaFacil.Backend.Application.Commands.Base;

namespace DoaFacil.Backend.Application.Commands.Anuncios.AddAnuncio
{
    public class AddAnuncioCommand : Command<Guid>
    {
        public Guid? Id { get; set; } 
        public decimal Meta { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid? CategoriaId { get; set; } 
        public string ChavePix { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
