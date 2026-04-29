using System.Text;
using System.Net.Http.Json;
using password_validator.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace password_validator.Integration.Tests.API.Controllers
{
    public class ValidatePasswordControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ValidatePasswordControllerIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("aa", false)]
        [InlineData("ab", false)]
        [InlineData("AAAbbbCc", false)]
        [InlineData("AbTp9!foo", false)]
        [InlineData("AbTp9!foA", false)]
        [InlineData("AbTp9 fok", false)]
        [InlineData("AbTp9!fok", true)]
        public async Task Post_ShouldReturnExpectedValidationResult(string password, bool expected)
        {
            // Arrange
            var request = new ValidatePasswordRequest { Password = password };

            // Act
            var response = await _client.PostAsJsonAsync("/validate-password", request);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ValidatePasswordResponse>();
            Assert.Equal(expected, result.IsValid);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequest_WhenPasswordIsMissing()
        {
            // Arrange
            var request = new { };

            // Act
            var response = await _client.PostAsJsonAsync("/validate-password", request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequest_WhenPasswordIsNull()
        {
            // Arrange
            var request = new ValidatePasswordRequest { Password = null };

            // Act
            var response = await _client.PostAsJsonAsync("/validate-password", request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Post_ShouldReturnUnsupportedMediaType_WhenContentTypeIsNotJson()
        {
            // Arrange
            var content = new StringContent("Password=AbTp9!fok", Encoding.UTF8, "application/x-www-form-urlencoded");

            // Act
            var response = await _client.PostAsync("/validate-password", content);

            // Assert
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [Fact]
        public async Task Post_ShouldReturnOk_WhenPasswordIsVeryLong()
        {
            // Arrange
            var longPassword = new string('a', 1000);
            var request = new ValidatePasswordRequest { Password = longPassword };

            // Act
            var response = await _client.PostAsJsonAsync("/validate-password", request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ValidatePasswordResponse>();

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task Post_ShouldReturnOkWithFalse_WhenPasswordHasOnlySpecialCharacters()
        {
            // Arrange
            var request = new ValidatePasswordRequest { Password = "!@#$%^&*()" };
            var response = await _client.PostAsJsonAsync("/validate-password", request);
            response.EnsureSuccessStatusCode();

            // Act
            var result = await response.Content.ReadFromJsonAsync<ValidatePasswordResponse>();

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
