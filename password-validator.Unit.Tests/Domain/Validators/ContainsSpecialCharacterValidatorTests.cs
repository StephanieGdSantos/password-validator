using password_validator.Domain.Validators;
using password_validator.Domain.Validators.Interface;

namespace password_validator.Unit.Tests.Domain.Validators
{
    public class ContainsSpecialCharacterValidatorTests
    {
        private IPasswordValidationStrategy _validator = new ContainsSpecialCharacterValidator();

        [Theory]
        [InlineData("Password!", true)]
        [InlineData("Pssw rd", false)]
        [InlineData("Password", false)]
        [InlineData("123456", false)]
        public void Validate_ShouldReturnTrue_WhenPasswordContainsSpecialCharacter(string password, bool expected)
        {
            // Act
            var result = _validator.Validate(password);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
