namespace DoaFacil.Backend.Infra.Authentication.AuthProviders.User
{
    public interface IUserAuthProvider
    {
        public string UserEmail { get; }
        public Guid UserId { get; }
        public string UserName { get; }
        public string UserRole { get; }
        bool IsAuthenticated { get; }
    }
}
