using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Notification;
using MediatR;

namespace DoaFacil.Backend.Application.Commands.Notifications.AddNotificationValidationResult
{
    public class AddNotificationsFromValidationResultCommandHandler(INotificationWriter notificationWriter) : CommandHandler<AddNotificationsFromValidationResultCommand, Unit>
    {
        public override Task<Unit> Handle(AddNotificationsFromValidationResultCommand request, CancellationToken cancellationToken)
        {
            notificationWriter.AddValidationResult(request.ValidationResult, request.IncludeFieldsOnMessages);
            return Task.FromResult(Unit.Value);
        }
    }
}