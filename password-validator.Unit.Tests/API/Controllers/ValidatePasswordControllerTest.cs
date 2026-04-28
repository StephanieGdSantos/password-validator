using Microsoft.AspNetCore.Mvc;
using Moq;
using password_validator.API.Controllers;
using password_validator.Application.Adapters.Interface;
using password_validator.Application.DTOs;

namespace password_validator.Unit.Tests.API.Controllers
{
    public class ValidatePasswordControllerTest
    {
        private readonly Mock<IValidateResponseAdapter> _adapterMock;
        private readonly ValidatePasswordController _controller;

        public ValidatePasswordControllerTest()
        {
            _adapterMock = new Mock<IValidateResponseAdapter>();
            _controller = new ValidatePasswordController(_adapterMock.Object);
        }

        [Fact]
        public void Post_ShouldReturnOkWithTrue_WhenPasswordIsValid()
        {
            // Arrange
            var request = new ValidatePasswordRequest { Password = "SenhaValida123!" };
            _adapterMock.Setup(a => a.Validate(request.Password))
                        .Returns(new ValidatePasswordResponse { IsValid = true });

            // Act
            var result = _controller.Post(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public void Post_ShouldReturnOkWithFalse_WhenPasswordIsInvalid()
        {
            // Arrange
            var request = new ValidatePasswordRequest { Password = "invalida" };
            _adapterMock.Setup(a => a.Validate(request.Password))
                        .Returns(new ValidatePasswordResponse { IsValid = false });

            // Act
            var result = _controller.Post(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.False((bool)okResult.Value);
        }

        [Fact]
        public void Post_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Password", "Required");
            var request = new ValidatePasswordRequest { Password = null };

            // Act
            var result = _controller.Post(request);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }
    }
}
