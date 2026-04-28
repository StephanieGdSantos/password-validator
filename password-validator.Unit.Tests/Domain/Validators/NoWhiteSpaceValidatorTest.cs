using password_validator.Domain.Validators;
using password_validator.Domain.Validators.Interface;

namespace password_validator.Unit.Tests.Domain.Validators
{
    public class NoWhiteSpaceValidatorTest
    {
        private readonly IPasswordValidationStrategy _validator = new NoWhiteSpaceValidator();

        [Theory]
        [InlineData("password", true)]
        [InlineData("passw rd", false)]
        [InlineData(" ", false)]
        [InlineData("12 4", false)]
        public void Validate_ShouldReturnTrue_WhenPasswordContainsNoWhiteSpace(string password, bool expected)
        {
            // Act
            var result = _validator.Validate(password);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
