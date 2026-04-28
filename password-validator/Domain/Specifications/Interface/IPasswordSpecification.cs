namespace password_validator.Domain.Specifications.Interface
{
    public interface IPasswordSpecification
    {
        bool IsSatisfiedBy(string password);
    }
}
