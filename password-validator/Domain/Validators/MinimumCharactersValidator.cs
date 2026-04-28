using Microsoft.Extensions.Options;
using password_validator.Configurations;
using password_validator.Domain.Validators.Interface;

namespace password_validator.Domain.Validators
{
    public class MinimumCharactersValidator(IOptions<LengthPasswordOptions> lengthPasswordOptions) : IPasswordValidationStrategy
    {
        private readonly LengthPasswordOptions _lengthPasswordOptions = lengthPasswordOptions.Value;

        public bool Validate(string password)
        {
            return password.Length >= _lengthPasswordOptions.MinimumLength;
        }
    }
}
