using DoaFacil.Backend.Application.Commands.Base;

namespace DoaFacil.Backend.Application.Commands.EnderecosUsuario.AddEnderecoUsuario
{
    public class AddEnderecoUsuarioCommand : Command<Guid>
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public Guid CidadeId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
