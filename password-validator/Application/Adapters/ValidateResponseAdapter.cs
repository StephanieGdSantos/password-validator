using password_validator.Application.Adapters.Interface;
using password_validator.Application.DTOs;
using password_validator.Domain.Specifications.Interface;

namespace password_validator.Application.Adapters
{
    public class ValidateResponseAdapter(IPasswordSpecification passwordSpecification) : IValidateResponseAdapter
    {
        private readonly IPasswordSpecification _passwordSpecification = passwordSpecification;
        public ValidatePasswordResponse Validate(string password)
        {
            var validationResult = _passwordSpecification.IsSatisfiedBy(password);

            return new ValidatePasswordResponse
            {
                IsValid = validationResult
            };
        }
    }
}
