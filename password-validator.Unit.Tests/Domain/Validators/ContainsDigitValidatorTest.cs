using password_validator.Domain.Validators;
using password_validator.Domain.Validators.Interface;

namespace password_validator.Unit.Tests.Domain.Validators
{
    public class ContainsDigitValidatorTest
    {
        private readonly IPasswordValidationStrategy _validator = new ContainsDigitValidator();

        [Theory]
        [InlineData("Password1", true)]
        [InlineData("Password", false)]
        [InlineData("123456", true)]
        [InlineData("!@#$%^", false)]
        public void Validate_ShouldReturnTrue_WhenPasswordContainsDigit(string password, bool expected)
        {
            // Act
            var result = _validator.Validate(password);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
