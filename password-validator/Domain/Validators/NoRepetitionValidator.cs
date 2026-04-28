using password_validator.Domain.Validators.Interface;

namespace password_validator.Domain.Validators
{
    public class NoRepetitionValidator : IPasswordValidationStrategy
    {
        public bool Validate(string password)
        {
            return password.Distinct().Count() == password.Length;
        }
    }
}
