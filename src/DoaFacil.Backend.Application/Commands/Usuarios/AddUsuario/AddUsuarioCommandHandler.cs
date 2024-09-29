using AutoMapper;
using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using DoaFacil.Backend.Domain.Repositories;

namespace DoaFacil.Backend.Application.Commands.Usuarios.AddUsuario
{
    public class AddUsuarioCommandHandler(IMapper mapper, IUsuarioRepository usuarioRepository) : CommandHandler<AddUsuarioCommand, Guid>
    {
        public override async Task<Guid> Handle(AddUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = mapper.Map<Usuario>(request);
            await usuarioRepository.AddAsync(usuario, cancellationToken);
            return usuario.Id;
        }
    }
}
