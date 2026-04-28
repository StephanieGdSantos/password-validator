using password_validator.Domain.Validators;
using password_validator.Domain.Validators.Interface;

namespace password_validator.Unit.Tests.Domain.Validators
{
    public class NoRepetitionValidatorTest
    {
        private readonly IPasswordValidationStrategy _validator = new NoRepetitionValidator();

        [Theory]
        [InlineData("abcde", true)]
        [InlineData("abcdeabcde", false)]
        [InlineData("12345", true)]
        [InlineData("1234512345", false)]
        public void Validate_ShouldReturnTrue_WhenPasswordHasNoCharactersRepetition(string password, bool expected)
        {
            // Act
            var result = _validator.Validate(password);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
