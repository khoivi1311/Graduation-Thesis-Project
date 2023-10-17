using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace learn_programming_services.Apis
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            return Ok("Welcome to my Services!!!");
        }

        [HttpGet("Authentication")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAuthen()
        {
            return Ok("Welcome to my Services With Authentication!!!");
        }
    }
}
