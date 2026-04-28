using password_validator.Domain.Validators.Interface;

namespace password_validator.Domain.Validators
{
    public class ContainsSpecialCharacterValidator : IPasswordValidationStrategy
    {
        public bool Validate(string password)
        {
            return password.Any(char.IsPunctuation) || password.Any(char.IsSymbol);
        }
    }
}
