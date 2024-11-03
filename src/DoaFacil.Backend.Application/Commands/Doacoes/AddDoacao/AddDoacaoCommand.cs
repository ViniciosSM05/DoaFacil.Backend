using DoaFacil.Backend.Application.Commands.Base;

namespace DoaFacil.Backend.Application.Commands.Doacoes.AddDoacao
{
    public class AddDoacaoCommand : Command<Guid>
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Guid AnuncioId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
