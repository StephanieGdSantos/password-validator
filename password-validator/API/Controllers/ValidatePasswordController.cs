using Microsoft.AspNetCore.Mvc;
using password_validator.Application.Adapters.Interface;
using password_validator.Application.DTOs;

namespace password_validator.API.Controllers
{
    [ApiController]
    [Route("validate-password")]
    public class ValidatePasswordController(IValidateResponseAdapter validationResponseAdapter) : ControllerBase
    {
        private readonly IValidateResponseAdapter _validationResponseAdapter = validationResponseAdapter;

        [HttpPost]
        public ActionResult<ValidatePasswordResponse> Post([FromBody] ValidatePasswordRequest password)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _validationResponseAdapter.Validate(password.Password);
            return Ok(result);
        }
    }
}
