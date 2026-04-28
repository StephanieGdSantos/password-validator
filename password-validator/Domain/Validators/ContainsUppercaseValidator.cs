using password_validator.Domain.Validators.Interface;

namespace password_validator.Domain.Validators
{
    public class ContainsUppercaseValidator : IPasswordValidationStrategy
    {
        public bool Validate(string password)
        {
            return password.Any(char.IsUpper);
        }
    }
}
