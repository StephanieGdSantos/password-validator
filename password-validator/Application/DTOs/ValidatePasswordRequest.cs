using System.ComponentModel.DataAnnotations;

namespace password_validator.Application.DTOs
{
    public class ValidatePasswordRequest
    {
        public string Password { get; set; }
    }
}
