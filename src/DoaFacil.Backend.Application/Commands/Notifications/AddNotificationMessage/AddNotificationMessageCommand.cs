using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Domain.Constants;
using FluentValidation;
using MediatR;

namespace DoaFacil.Backend.Application.Commands.Notifications.AddNotificationMessage
{
    public class AddNotificationMessageCommand(string message, string errorCode = ErrorCodes.GENERIC, Severity severity = Severity.Error) : Command<Unit>
    {
        public string ErrorCode { get; private set; } = errorCode;
        public string Message { get; private set; } = message;
        public Severity Severity { get; private set; } = severity;
    }
}