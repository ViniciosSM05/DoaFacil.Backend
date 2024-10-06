using AutoMapper;
using DoaFacil.Backend.Application.Dtos.Usuarios;
using DoaFacil.Backend.Infra.Authentication.AuthModels.Token;

namespace DoaFacil.Backend.Application.Mapper.Converters.AuthConverters
{
    public class TokenAuthModelToAuthInfoResultDtoConverter : ITypeConverter<TokenAuthModel, AuthInfoResultDto>
    {
        public AuthInfoResultDto Convert(TokenAuthModel source, AuthInfoResultDto destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination = new()
            {
                DataEHoraDeExpiracao = source.DataEHoraDeExpiracao,
                Token = source.Token,
                User = new()
            };

            return destination;
        }
    }
}
