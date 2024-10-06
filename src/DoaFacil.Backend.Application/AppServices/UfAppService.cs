using AutoMapper;
using DoaFacil.Backend.Application.AppServices.Base;
using DoaFacil.Backend.Application.AppServices.Interfaces;
using DoaFacil.Backend.Application.Commands.Dispatcher;
using DoaFacil.Backend.Application.Dtos.Ufs;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.UoW;

namespace DoaFacil.Backend.Application.AppServices
{
    public class UfAppService(ICommandDispatcher commandDispatcher
        , INotificationReader notifications
        , IUnitOfWork unitOfWork
        , IMapper mapper
        , IUfRepository ufRepository) : AppService(commandDispatcher, notifications, unitOfWork, mapper), IUfAppService
    {
       public async Task<List<UfDto>> GetAllUfs(CancellationToken cancellationToken)
       {
            var ufs = await ufRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<UfDto>>(ufs.OrderBy(x => x.Nome));
       }
    }
}
