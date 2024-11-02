using AutoMapper;
using DoaFacil.Backend.Application.AppServices.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Commands.Anuncios.AddAnuncio;
using DoaFacil.Backend.Application.Commands.Dispatcher;
using DoaFacil.Backend.Application.Commands.ImagensAnuncio;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Authentication.AuthProviders.User;
using DoaFacil.Backend.Infra.Database.UoW;
using DoaFacil.Backend.Shared.Dtos.Anuncios;

namespace DoaFacil.Backend.Application.AppServices
{
    public class AnuncioAppService : AppService, IAnuncioAppService
    {
        private readonly IUserAuthProvider _userAuthProvider;
        private readonly IAnuncioRepository _anuncioRepository;

        public AnuncioAppService(ICommandDispatcher commandDispatcher
            , INotificationReader notifications
            , IUnitOfWork unitOfWork
            , IMapper mapper
            , IUserAuthProvider userAuthProvider
            , IAnuncioRepository anuncioRepository) : base(commandDispatcher, notifications, unitOfWork, mapper)
        {
            _userAuthProvider = userAuthProvider;
            _anuncioRepository = anuncioRepository;
        }

        public async Task<Guid> AddAnuncioAsync(AddAnuncioDto dto, CancellationToken cancellationToken)
        {
            using (_unitOfWork.Start())
            {
                var addAnuncioCommand = _mapper.Map<AddAnuncioCommand>(dto);
                addAnuncioCommand.UsuarioId = _userAuthProvider.UserId;
                var anuncioId = await _commandDispatcher.DispatchAsync(addAnuncioCommand, cancellationToken);

                var addImagemAnuncioCommand = _mapper.Map<AddImagemAnuncioCommand>(dto.Imagem);
                addImagemAnuncioCommand.AnuncioId = anuncioId;
                await _commandDispatcher.DispatchAsync(addImagemAnuncioCommand, cancellationToken);

                if (!_notifications.IsValid) return Guid.Empty;

                await _unitOfWork.CommitAsync(cancellationToken);
                return anuncioId;
            }
        }

        public async Task<List<AnuncioLista.Data>> GetAnunciosAsync(AnuncioLista.Filtro filtro, CancellationToken cancellationToken)
            => await _anuncioRepository.GetAnunciosAsync(filtro, _userAuthProvider.UserId, cancellationToken);

        public async Task<AnuncioEditDto> GetAnuncioEditAsync(Guid anuncioId, CancellationToken cancellationToken)
            => await _anuncioRepository.GetAnuncioEditAsync(anuncioId, cancellationToken);

        public async Task<AnuncioDetalhesDto> GetAnuncioDetalhesAsync(Guid anuncioId, CancellationToken cancellationToken)
            => await _anuncioRepository.GetAnuncioDetalhesAsync(anuncioId, cancellationToken);
    }
}
