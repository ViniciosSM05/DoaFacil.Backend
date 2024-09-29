using DoaFacil.Backend.Application.Commands.Base;
using FluentValidation.Results;
using MediatR;

namespace DoaFacil.Backend.Application.Commands.Notifications.AddNotificationValidationResult
{
    public class AddNotificationsFromValidationResultCommand(ValidationResult validationResult, bool includeFieldsOnMessages = true) : Command<Unit>
    {
        public bool IncludeFieldsOnMessages { get; private set; } = includeFieldsOnMessages;
        public ValidationResult ValidationResult { get; private set; } = validationResult;
    }
}