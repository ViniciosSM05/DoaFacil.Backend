using DoaFacil.Backend.Shared.Dtos.Cidades;

namespace DoaFacil.Backend.Shared.Dtos.EnderecosUsuario
{
    public class EnderecoUsuarioDto
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int? Numero { get; set; }
        public CidadeDto Cidade { get; set; }
    }
}
