using password_validator.Domain.Specifications;
using password_validator.Domain.Validators.Interface;
using Moq;

namespace password_validator.Unit.Tests.Domain.Specifications
{
    public class PasswordSpecificationTest
    {
        private readonly PasswordSpecification _passwordSpecification;
        private readonly Mock<IPasswordValidationStrategy> _passwordValidationStrategy;

        public PasswordSpecificationTest()
        {
            _passwordValidationStrategy = new Mock<IPasswordValidationStrategy>();
            _passwordSpecification = new PasswordSpecification(
                new List<IPasswordValidationStrategy> { _passwordValidationStrategy.Object });
        }

        [Fact]
        public void IsSatisfiedBy_ShouldReturnTrue_WhenPasswordMeetsAllCriteria()
        {
            // Arrange
            var validPassword = "valid";
            _passwordValidationStrategy
                .Setup(v => v
                    .Validate(validPassword))
                .Returns(true);

            // Act
            var result = _passwordSpecification.IsSatisfiedBy(validPassword);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSatisfiedBy_ShouldReturnFalse_WhenPasswordDoesNotMeetCriteria()
        {
            // Arrange
            var invalidPassword = "invalid";
            _passwordValidationStrategy.Setup(v => v
                    .Validate(invalidPassword))
                .Returns(false);

            // Act
            var result = _passwordSpecification.IsSatisfiedBy(invalidPassword);

            // Assert
            Assert.False(result);
        }
    }
}