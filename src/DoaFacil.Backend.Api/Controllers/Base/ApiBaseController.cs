using DoaFacil.Backend.Domain.Notification;
using FluentValidation.Results;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using DoaFacil.Backend.Shared.Dtos.Response;
using DoaFacil.Backend.Shared.Enums;
using DoaFacil.Backend.Shared.Dtos.Validation;

namespace DoaFacil.Backend.Api.Controllers.Base
{
    [ApiController]
    [Asp.Versioning.ApiVersion("1")]
    public class ApiBaseController(INotificationReader notifications) : ControllerBase
    {
        protected async Task<ActionResult<DoaFacilDataResponseDto<TData>>> ExecuteAsync<TData>(Func<Task<TData>> action)
        {
            var response = new DoaFacilDataResponseDto<TData>();

            var data = await action();
            response.SetData(data);
            AddNotificationsOnResponse(response);

            return new ObjectResult(response)
            {
                StatusCode = (int)notifications.StatusCode
            };
        }

        protected async Task<ActionResult<DoaFacilResponseDto>> ExecuteAsync(Func<Task> action)
        {
            var response = new DoaFacilResponseDto();

            await action();
            AddNotificationsOnResponse(response);

            return new ObjectResult(response)
            {
                StatusCode = (int)notifications.StatusCode
            };
        }

        private static ValidationFailureSeverity SeverityToValidationFailureSeverity(Severity severity)
            => severity switch
            {
                Severity.Error => ValidationFailureSeverity.Error,
                Severity.Warning => ValidationFailureSeverity.Warning,
                Severity.Info => ValidationFailureSeverity.Info,
                _ => ValidationFailureSeverity.Error
            };

        private static ValidationFailureDto ValidationFailureToValidationFailureDto(ValidationFailure validationFailure)
            => new(validationFailure.ErrorMessage, SeverityToValidationFailureSeverity(validationFailure.Severity));

        private static ValidationPropertyFailureDto ValidationFailureToValidationPropertyFailureDto(ValidationFailure validationFailure)
            => new(validationFailure.ErrorMessage, validationFailure.PropertyName, SeverityToValidationFailureSeverity(validationFailure.Severity));

        private void AddNotificationsOnResponse(DoaFacilResponseDto response)
        {
            response.SetFieldMessages(notifications.FieldMessages.Select(ValidationFailureToValidationPropertyFailureDto));
            response.SetMessagesWithoutField(notifications.MessagesWithoutField.Select(ValidationFailureToValidationFailureDto));
        }
    }
}
