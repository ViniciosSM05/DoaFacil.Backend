using Newtonsoft.Json;

namespace DoaFacil.Backend.Api.Dtos.Validation
{
    public class ValidationFailureDto
    {
        public ValidationFailureDto(string errorMessage, ValidationFailureSeverity severity)
        {
            ErrorMessage = errorMessage;
            Severity = severity;
        }

        public ValidationFailureDto(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Severity = ValidationFailureSeverity.Error;
        }

        public ValidationFailureDto()
        {
        }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; private set; }

        [JsonProperty("severity")]
        public ValidationFailureSeverity Severity { get; private set; }
    }

    public enum ValidationFailureSeverity
    {
        Error,
        Warning,
        Info
    }
}
