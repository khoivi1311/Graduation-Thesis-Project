using learn_programming_services.Apis.Practices.Dtos;
using learn_programming_services.Businesses.Functions.Practices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace learn_programming_services.Apis.Practices
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class PracticesController : ControllerBase
    {
        private readonly IGetPracticeLevelsFunction _getPracticeLevelsFunction;
        private readonly ICreateNewPracticeFunction _createNewPracticeFunction;
        private readonly IGetPracticesManagementFunction _getPracticesManagementFunction;
        private readonly IGetPracticeDetailsManagementFunction _getPracticeDetailsManagementFunction;
        private readonly IDeletePracticeFunction _deletePracticeFunction;
        private readonly IHiddenPracticeFunction _hiddenPracticeFunction;
        private readonly IDeletePracticeTestCaseFunction _deletePracticeTestCaseFunction;
        private readonly IUpdatePracticeFunction _updatePracticeFunction;
        private readonly IGetPracticesFunction _getPracticesFunction;
        private readonly IGetPracticeDetailsFunction _getPracticeDetailsFunction;
        private readonly IRunCodePracticeFunction _runCodePracticeFunction;
        private readonly ISubmitCodePracticeFunction _submitCodePracticeFunction;
        private readonly IGetPracticeHistoriesFunction _getPracticeHistoriesFunction;
        private readonly IGetPracticeLeaderboardFunction _getPracticeLeaderboardFunction;

        public PracticesController(IGetPracticeLevelsFunction getPracticeLevelsFunction,
            ICreateNewPracticeFunction createNewPracticeFunction,
            IGetPracticesManagementFunction getPracticesManagementFunction,
            IGetPracticeDetailsManagementFunction getPracticeDetailsManagementFunction,
            IDeletePracticeFunction deletePracticeFunction,
            IHiddenPracticeFunction hiddenPracticeFunction,
            IDeletePracticeTestCaseFunction deletePracticeTestCaseFunction,
            IUpdatePracticeFunction updatePracticeFunction,
            IGetPracticesFunction getPracticesFunction,
            IGetPracticeDetailsFunction getPracticeDetailsFunction,
            IRunCodePracticeFunction runCodePracticeFunction,
            ISubmitCodePracticeFunction submitCodePracticeFunction,
            IGetPracticeHistoriesFunction getPracticeHistoriesFunction,
            IGetPracticeLeaderboardFunction getPracticeLeaderboardFunction)
        {
            _getPracticeLevelsFunction = getPracticeLevelsFunction;
            _createNewPracticeFunction = createNewPracticeFunction;
            _getPracticesManagementFunction = getPracticesManagementFunction;
            _getPracticeDetailsManagementFunction = getPracticeDetailsManagementFunction;
            _deletePracticeFunction = deletePracticeFunction;
            _hiddenPracticeFunction = hiddenPracticeFunction;
            _deletePracticeTestCaseFunction = deletePracticeTestCaseFunction;
            _updatePracticeFunction = updatePracticeFunction;
            _getPracticesFunction = getPracticesFunction;
            _getPracticeDetailsFunction = getPracticeDetailsFunction;
            _runCodePracticeFunction = runCodePracticeFunction;
            _submitCodePracticeFunction = submitCodePracticeFunction;
            _getPracticeHistoriesFunction = getPracticeHistoriesFunction;
            _getPracticeLeaderboardFunction = getPracticeLeaderboardFunction;
        }

        [HttpGet("Levels")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPracticeLevels()
        {
            var response = await _getPracticeLevelsFunction.GetPracticeLevels();
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewPractice(CreateNewPracticeDto newPractice)
        {
            var response = await _createNewPracticeFunction.CreateNewPractice(new ICreateNewPracticeFunction.Request(newPractice));
            return Ok(response);
        }

        [HttpGet("Management")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPracticesManagement(int userId, int pageSize, int pageNumber, string? keyword)
        {
            var response = await _getPracticesManagementFunction.GetPracticesManagement(new IGetPracticesManagementFunction.Request(userId, pageSize, pageNumber, keyword));
            return Ok(response);
        }

        [HttpGet("Management/Details/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPracticeDetailsManagement(int id)
        {
            var response = await _getPracticeDetailsManagementFunction.GetPracticeDetailsManagement(new IGetPracticeDetailsManagementFunction.Request(id));
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePractice(int id)
        {
            var response = await _deletePracticeFunction.DeletePractice(new IDeletePracticeFunction.Request(id));
            return Ok(response);
        }

        [HttpPost("Hidden/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> HiddenPractice(int id)
        {
            var response = await _hiddenPracticeFunction.HiddenPractice(new IHiddenPracticeFunction.Request(id));
            return Ok(response);
        }

        [HttpDelete("TestCase/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePracticeTestCase(int id)
        {
            var response = await _deletePracticeTestCaseFunction.DeletePracticeTestCase(new IDeletePracticeTestCaseFunction.Request(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePractice(UpdatePracticeDto practice)
        {
            var response = await _updatePracticeFunction.UpdatePractice(new IUpdatePracticeFunction.Request(practice));
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPractices(int userId, int pageSize, int pageNumber, string? keyword, int? levelId, bool? isCompleted)
        {
            var response = await _getPracticesFunction.GetPractices(new IGetPracticesFunction.Request(userId, pageSize, pageNumber, keyword, levelId, isCompleted));
            return Ok(response);
        }

        [HttpGet("Details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPracticeDetails(int practiceId, int userId)
        {
            var response = await _getPracticeDetailsFunction.GetPracticeDetails(new IGetPracticeDetailsFunction.Request(practiceId, userId));
            return Ok(response);
        }

        [HttpPost("Run")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RunCodePractice(RunCodePracticeDto runCodePractice)
        {
            var response = await _runCodePracticeFunction.RunCodePractice(new IRunCodePracticeFunction.Request(runCodePractice));
            return Ok(response);
        }

        [HttpPut("Submit")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SubmitCodePractice(SubmitCodePracticeDto submitCodePractice)
        {
            var response = await _submitCodePracticeFunction.SubmitCodePractice(new ISubmitCodePracticeFunction.Request(submitCodePractice));
            return Ok(response);
        }

        [HttpGet("Histories")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPracticeHistories(int practiceId, int userId)
        {
            var response = await _getPracticeHistoriesFunction.GetPracticeHistories(new IGetPracticeHistoriesFunction.Request(practiceId, userId));
            return Ok(response);
        }

        [HttpGet("Leaderboard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPracticeLeaderboard(int practiceId, int pageSize, int pageNumber)
        {
            var response = await _getPracticeLeaderboardFunction.GetPracticeLeaderboard(new IGetPracticeLeaderboardFunction.Request(practiceId, pageSize, pageNumber));
            return Ok(response);
        }
    }
}
