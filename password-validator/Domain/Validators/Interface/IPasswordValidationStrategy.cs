namespace password_validator.Domain.Validators.Interface
{
    public interface IPasswordValidationStrategy
    {
        bool Validate(string password);
    }
}
