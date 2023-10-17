using learn_programming_services.Apis.Authentications.Dtos;
using learn_programming_services.Businesses.Functions.Authentications;
using Microsoft.AspNetCore.Mvc;

namespace learn_programming_services.Apis.Authentications
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IRegisterFunction _registerFunction;
        private readonly ILoginFunction _loginFunction;
        private readonly IRefreshTokenFunction _refreshTokenFunction;
        private readonly ILogoutFunction _logoutFunction;

        public AuthenticationsController(IRegisterFunction registerFunction, 
            ILoginFunction loginFunction, 
            IRefreshTokenFunction refreshTokenFunction,
            ILogoutFunction logoutFunction)
        {
            _registerFunction = registerFunction;
            _loginFunction = loginFunction;
            _refreshTokenFunction = refreshTokenFunction;
            _logoutFunction = logoutFunction;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            var response = await _registerFunction.Register(new IRegisterFunction.Request(register));
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var response = await _loginFunction.Login(new ILoginFunction.Request(login));
            return Ok(response);
        }

        [HttpPost("RefreshToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken(TokenDto token)
        {
            var response = await _refreshTokenFunction.RefreshToken(new IRefreshTokenFunction.Request(token));
            return Ok(response);
        }

        [HttpPost("Logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Logout(TokenDto token)
        {
            var response = await _logoutFunction.Logout(new ILogoutFunction.Request(token));
            return Ok(response);
        }
    }
}
