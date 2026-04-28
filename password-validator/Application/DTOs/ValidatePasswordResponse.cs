using System.Text.Json.Serialization;

namespace password_validator.Application.DTOs
{
    public class ValidatePasswordResponse
    {
        public bool IsValid { get; set; }
    }
}
