using DoaFacil.Backend.Api.Dtos.Validation;
using Newtonsoft.Json;

namespace DoaFacil.Backend.Api.Dtos.Response
{
    public class DoaFacilResponseDto
    {
        public DoaFacilResponseDto()
        {
            FieldMessages = [];
            MessagesWithoutField = [];
        }

        [JsonProperty("fieldMessages")]
        public IReadOnlyCollection<ValidationPropertyFailureDto> FieldMessages { get; private set; }

        [JsonProperty("fieldMessagesDictionary")]
        public IReadOnlyDictionary<string, string[]> FieldMessagesDictionary { get; private set; }

        [JsonProperty("messagesWithoutField")]
        public IReadOnlyCollection<ValidationFailureDto> MessagesWithoutField { get; private set; }

        [JsonProperty("success")]
        public bool Success => IsValid();

        public void AddError(string erro)
        {
            if (string.IsNullOrWhiteSpace(erro))
                return;

            MessagesWithoutField = [.. MessagesWithoutField, new ValidationFailureDto(erro)];
        }

        public void AddError(IEnumerable<string> errors)
        {
            errors?.ToList()?.ForEach(error => AddError(error));
        }

        public List<string> GetErrors()
        {
            var fieldMessages = FieldMessages.Select(fm => fm.ErrorMessage).ToList();
            var messagesWithoutField = MessagesWithoutField.Select(mwf => mwf.ErrorMessage).ToList();
            return fieldMessages.Concat(messagesWithoutField).Distinct().ToList();
        }

        public bool IsValid() => !GetErrors().Any();

        public void SetException(Exception ex)
        {
            AddError(ex.Message);
        }

        public void SetFieldMessages(IEnumerable<ValidationPropertyFailureDto> fieldMessages)
        {
            FieldMessages = fieldMessages?.ToList() ?? new List<ValidationPropertyFailureDto>();
            FieldMessagesDictionary = FieldMessages
                .GroupBy(x => x.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(x => x.ErrorMessage).ToArray());
        }

        public void SetMessagesWithoutField(IEnumerable<ValidationFailureDto> messagesWithoutField)
        {
            MessagesWithoutField = messagesWithoutField?.ToList() ?? new List<ValidationFailureDto>();
        }
    }
}
