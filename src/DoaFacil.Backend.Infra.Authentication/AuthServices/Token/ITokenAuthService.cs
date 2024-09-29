using DoaFacil.Backend.Infra.Authentication.AuthModels.Token;

namespace DoaFacil.Backend.Infra.Authentication.AuthServices.Token
{
    public interface ITokenAuthService
    {
        TokenAuthModel GenerateToken(GenerateTokenAuthModel generateModel);
    }
}
