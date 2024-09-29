using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Notification;
using MediatR;

namespace DoaFacil.Backend.Application.Commands.Notifications.AddNotificationMessage
{
    public class AddNotificationMessageCommandHandler(INotificationWriter notificationWriter) : CommandHandler<AddNotificationMessageCommand, Unit>
    {
        public override Task<Unit> Handle(AddNotificationMessageCommand request, CancellationToken cancellationToken)
        {
            notificationWriter.AddMessage(request.Message, request.ErrorCode, request.Severity);
            return Task.FromResult(Unit.Value);
        }
    }
}