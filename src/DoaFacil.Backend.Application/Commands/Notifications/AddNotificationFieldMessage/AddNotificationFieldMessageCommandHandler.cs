using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Notification;
using MediatR;

namespace DoaFacil.Backend.Application.Commands.Notifications.AddNotificationFieldMessage
{
    public class AddNotificationFieldMessageCommandHandler(INotificationWriter notificationWriter) : CommandHandler<AddNotificationFieldMessageCommand, Unit>
    {
        public override Task<Unit> Handle(AddNotificationFieldMessageCommand request, CancellationToken cancellationToken)
        {
            notificationWriter.AddFieldMessage(request.FieldName, request.Message, request.ErrorCode, request.Severity);
            return Task.FromResult(Unit.Value);
        }
    }
}