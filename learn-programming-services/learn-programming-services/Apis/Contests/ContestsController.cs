using learn_programming_services.Businesses.Functions.Contests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace learn_programming_services.Apis.Contests
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class ContestsController : ControllerBase
    {
        private readonly IGetContestsManagementFunction _getContestsManagementFunction;
        private readonly IGetContestStatusesFunction _getContestStatusesFunction;

        public ContestsController(IGetContestsManagementFunction getContestsManagementFunction,
            IGetContestStatusesFunction getContestStatusesFunction)
        {
            _getContestsManagementFunction = getContestsManagementFunction;
            _getContestStatusesFunction = getContestStatusesFunction;
        }

        [HttpGet("Management")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetContestsManagement(int userId, string? keyword)
        {
            var response = await _getContestsManagementFunction.GetContestsManagement(new IGetContestsManagementFunction.Request(userId, keyword));
            return Ok(response);
        }

        [HttpGet("Statuses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetContestStatuses()
        {
            var response = await _getContestStatusesFunction.GetContestStatuses();
            return Ok(response);
        }
    }
}
