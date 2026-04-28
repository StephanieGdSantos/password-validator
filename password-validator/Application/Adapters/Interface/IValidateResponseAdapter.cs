using password_validator.Application.DTOs;

namespace password_validator.Application.Adapters.Interface
{
    public interface IValidateResponseAdapter
    {
        ValidatePasswordResponse Validate(string password);
    }
}
