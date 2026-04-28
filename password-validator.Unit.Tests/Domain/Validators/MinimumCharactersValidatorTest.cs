using Microsoft.Extensions.Options;
using password_validator.Configurations;
using password_validator.Domain.Validators;
using password_validator.Domain.Validators.Interface;

namespace password_validator.Unit.Tests.Domain.Validators
{
    public class MinimumCharactersValidatorTest
    {
        private IPasswordValidationStrategy _validator;

        [Theory]
        [InlineData("123456", 6, true)]
        [InlineData("12345", 6, false)]
        [InlineData("abcdef", 6, true)]
        [InlineData("abcde", 6, false)]
        [InlineData("", 1, false)]
        [InlineData("a", 1, true)]
        [InlineData("abc", 0, true)]
        public void Validate_ShouldReturnTrue_WhenPasswordContainsMinimumCharactersLength
            (string password, int minLength, bool expected)
        {
            _validator = new MinimumCharactersValidator(Options.Create(new LengthPasswordOptions { MinimumLength = minLength }));

            // Act
            var result = _validator.Validate(password);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
