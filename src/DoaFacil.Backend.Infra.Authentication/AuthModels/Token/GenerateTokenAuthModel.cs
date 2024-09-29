namespace DoaFacil.Backend.Infra.Authentication.AuthModels.Token
{
    public class GenerateTokenAuthModel
    {
        public string UserEmail { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
    }
}
