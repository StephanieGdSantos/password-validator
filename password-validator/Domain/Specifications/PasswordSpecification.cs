using password_validator.Domain.Validators.Interface;
using password_validator.Domain.Specifications.Interface;

namespace password_validator.Domain.Specifications
{
    public class PasswordSpecification(IEnumerable<IPasswordValidationStrategy> passwordValidators) : IPasswordSpecification
    {
        private readonly List<IPasswordValidationStrategy> _passwordValidators = passwordValidators.ToList();

        public bool IsSatisfiedBy(string password)
        {
            foreach (var rule in _passwordValidators)
            {
                if (!rule.Validate(password))
                    return false;
            }

            return true;
        }
    }
}
