using AutoMapper;
using DoaFacil.Backend.Application.Commands.Dispatcher;
using DoaFacil.Backend.Domain.Notification;
using DoaFacil.Backend.Infra.Database.UoW;

namespace DoaFacil.Backend.Application.AppServices.Base
{
    public abstract class AppService(ICommandDispatcher commandDispatcher
        , INotificationReader notifications
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        protected readonly ICommandDispatcher _commandDispatcher = commandDispatcher;
        protected readonly IMapper _mapper = mapper;
        protected readonly INotificationReader _notifications = notifications;
        protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    }
}
