using Newtonsoft.Json;

namespace DoaFacil.Backend.Api.Dtos.Validation
{
    public class ValidationPropertyFailureDto : ValidationFailureDto
    {
        public ValidationPropertyFailureDto(string errorMessage, string propertyName, ValidationFailureSeverity severity)
            : base(errorMessage, severity)
        {
            PropertyName = propertyName;
        }

        public ValidationPropertyFailureDto(string errorMessage, string propertyName)
            : base(errorMessage)
        {
            PropertyName = propertyName;
        }

        public ValidationPropertyFailureDto()
        {
        }

        [JsonProperty("propertyName")]
        public string PropertyName { get; private set; }
    }
}
