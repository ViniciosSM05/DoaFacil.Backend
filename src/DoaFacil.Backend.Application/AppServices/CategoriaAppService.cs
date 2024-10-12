using AutoMapper;
using DoaFacil.Backend.Application.AppServices.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Commands.Dispatcher;
using DoaFacil.Backend.Application.Dtos.Categorias;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.UoW;

namespace DoaFacil.Backend.Application.AppServices
{
    public class CategoriaAppService(ICommandDispatcher commandDispatcher
        , INotificationReader notifications
        , IUnitOfWork unitOfWork
        , IMapper mapper
        , ICategoriaRepository categoriaRepository) : AppService(commandDispatcher, notifications, unitOfWork, mapper), ICategoriaAppService
    {
        public async Task<List<CategoriaDto>> GetAllCategorias(CancellationToken cancellationToken)
        {
            var ufs = await categoriaRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<CategoriaDto>>(ufs.OrderBy(x => x.Nome));
        }
    }
}
