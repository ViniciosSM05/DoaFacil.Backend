namespace DoaFacil.Backend.Shared.Dtos.Usuarios
{
    public class AuthInfoResultDto
    {
        public DateTime DataEHoraDeExpiracao { get; set; }
        public string Token { get; set; }
        public UserAuthInfoDto User { get; set; }
    }
}
