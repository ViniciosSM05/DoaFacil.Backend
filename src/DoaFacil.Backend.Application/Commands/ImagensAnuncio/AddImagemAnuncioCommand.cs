using DoaFacil.Backend.Application.Commands.Base;

namespace DoaFacil.Backend.Application.Commands.ImagensAnuncio
{
    public class AddImagemAnuncioCommand : Command<Guid>
    {
        public string Nome { get; set; }
        public string Base64 { get; set; }
        public string Tipo { get; set; }
        public bool Principal { get; set; }
        public Guid AnuncioId { get; set; }
    }
}
