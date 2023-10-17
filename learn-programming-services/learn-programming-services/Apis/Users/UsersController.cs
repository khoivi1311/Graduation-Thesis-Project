using learn_programming_services.Apis.Users.Dtos;
using learn_programming_services.Businesses.Functions.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace learn_programming_services.Apis.Users
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IGetUserInformationFunction _getUserInformationFunction;
        private readonly IUpdateUserInformationFunction _updateUserInformationFunction;

        public UsersController(IGetUserInformationFunction getUserInformationFunction, 
            IUpdateUserInformationFunction updateUserInformationFunction)
        {
            _getUserInformationFunction = getUserInformationFunction;
            _updateUserInformationFunction = updateUserInformationFunction;
        }

        [HttpGet("{userId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserInformation(int userId)
        {
            var response = await _getUserInformationFunction.GetUserInformation(new IGetUserInformationFunction.Request(userId));
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserInformation(UpdateUserInformationDto updateUserInformation)
        {
            var response = await _updateUserInformationFunction.UpdateUserInformation(new IUpdateUserInformationFunction.Request(updateUserInformation));
            return Ok(response);
        }
    }
}
