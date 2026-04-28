using Moq;
using password_validator.Domain.Specifications.Interface;
using password_validator.Application.Adapters.Interface;
using password_validator.Application.Adapters;

namespace password_validator.Unit.Tests.Application.Adapters
{
    public class ValidateResponseAdapterTest
    {
        private readonly Mock<IPasswordSpecification> _passwordSpecificationMock;
        private readonly IValidateResponseAdapter _validateResponseAdapter;

        public ValidateResponseAdapterTest()
        {
            _passwordSpecificationMock = new Mock<IPasswordSpecification>();

            _validateResponseAdapter = new ValidateResponseAdapter(_passwordSpecificationMock.Object);
        }

        [Fact]
        public void Validate_ShouldReturnInvalidPassword_WhenHasErrors()
        {
            // Arrange
            var password = "invalid";
            _passwordSpecificationMock
                .Setup(p => p
                    .IsSatisfiedBy(It.IsAny<string>()))
                .Returns(false);

            // Act
            var result = _validateResponseAdapter.Validate(password);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_ShouldReturnValidPassword_WhenHasNoErrors()
        {
            // Arrange
            var password = "valid";
            _passwordSpecificationMock
                .Setup(p => p
                    .IsSatisfiedBy(It.IsAny<string>()))
                .Returns(true);

            // Act
            var result = _validateResponseAdapter.Validate(password);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }
    }
}
