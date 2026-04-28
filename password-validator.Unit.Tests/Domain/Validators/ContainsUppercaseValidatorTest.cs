using password_validator.Domain.Validators;
using password_validator.Domain.Validators.Interface;

namespace password_validator.Unit.Tests.Domain.Validators
{
    public class ContainsUppercaseValidatorTest
    {
        private IPasswordValidationStrategy _validator = new ContainsUppercaseValidator();

        [Theory]
        [InlineData("Password", true)]
        [InlineData("password", false)]
        [InlineData("passWord", true)]
        [InlineData("123456", false)]
        public void Validate_ShouldReturnTrue_WhenPasswordContainsUppercase(string password, bool expected)
        {
            // Act
            var result = _validator.Validate(password);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
