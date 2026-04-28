using password_validator.Domain.Validators;
using password_validator.Domain.Validators.Interface;

namespace password_validator.Unit.Tests.Domain.Validators
{
    public class ContainsLowerCaseValidatorTest
    {
        private readonly IPasswordValidationStrategy _validator = new ContainsLowercaseValidator();

        [Theory]
        [InlineData("password", true)]
        [InlineData("PASSWORD", false)]
        [InlineData("PassWord", true)]
        [InlineData("123456", false)]
        [InlineData("!@#$%^", false)]
        public void Validate_ShouldReturnTrue_WhenPasswordContainsLowercaseCharacter(string password, bool expected)
        {
            // Act
            var result = _validator.Validate(password);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
