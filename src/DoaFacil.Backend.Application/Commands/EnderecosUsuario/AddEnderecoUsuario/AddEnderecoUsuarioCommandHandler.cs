using AutoMapper;
using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;
using DoaFacil.Backend.Domain.Repositories;

namespace DoaFacil.Backend.Application.Commands.EnderecosUsuario.AddEnderecoUsuario
{
    public class AddEnderecoUsuarioCommandHandler(IMapper mapper, IEnderecoUsuarioRepository enderecoUsuarioRepository) : CommandHandler<AddEnderecoUsuarioCommand, Guid>
    {
        public override async Task<Guid> Handle(AddEnderecoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var enderecoUsuario = mapper.Map<EnderecoUsuario>(request);
            await enderecoUsuarioRepository.AddAsync(enderecoUsuario, cancellationToken);
            return enderecoUsuario.Id;
        }
    }
}
