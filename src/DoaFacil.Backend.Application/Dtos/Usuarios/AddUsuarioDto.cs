using DoaFacil.Backend.Application.Dtos.EnderecosUsuario;

namespace DoaFacil.Backend.Application.Dtos.Usuarios
{
    public class AddUsuarioDto
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EnderecoUsuarioDto Endereco { get; set; }
    }
}
