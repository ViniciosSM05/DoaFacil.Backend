using DoaFacil.Backend.Application.Commands.Base;

namespace DoaFacil.Backend.Application.Commands.Cidades.AddCidade
{
    public class AddCidadeCommand : Command<Guid>
    {
        public string Nome { get; set; }
        public Guid? UfId { get; set; }
    }
}
