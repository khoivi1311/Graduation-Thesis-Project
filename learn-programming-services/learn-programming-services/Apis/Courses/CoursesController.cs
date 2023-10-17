using learn_programming_services.Apis.Courses.Dtos;
using learn_programming_services.Businesses.Functions.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace learn_programming_services.Apis.Courses
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IGetCoursesFunction _getCoursesFunction;
        private readonly IGetCourseDetailsFunction _getCourseDetailsFunction;
        private readonly ICourseRegisterFunction _courseRegisterFunction;
        private readonly ICourseCommentFunction _courseCommentFunction;
        private readonly ICourseReplyCommentFunction _courseReplyCommentFunction;
        private readonly IGetCourseCommentsFunction _getCourseCommentsFunction;
        private readonly ICourseCommentActionFunction _courseCommentActionFunction;
        private readonly ICourseReplyCommentActionFunction _courseReplyCommentActionFunction;
        private readonly ICreateNewCourseFunction _createNewCourseFunction;
        private readonly IGetCourseLevelsFunction _getCourseLevelsFunction;
        private readonly ICreateNewChapterFunction _createNewChapterFunction;
        private readonly IGetCoursesManagementFunction _getCoursesManagementFunction;
        private readonly IDeleteCourseFunction _deleteCourseFunction;
        private readonly IGetCourseDetailsManagementFunction _getCourseDetailsManagementFunction;
        private readonly IUpdateCourseFunction _updateCourseFunction;
        private readonly IHiddenCourseFunction _hiddenCourseFunction;
        private readonly IGetChapterDetailsFunction _getChapterDetailsFunction;
        private readonly IUpdateChapterFunction _updateChapterFunction;
        private readonly IDeleteChapterFunction _deleteChapterFunction;
        private readonly IHiddenChapterFunction _hiddenChapterFunction;
        private readonly ICreateNewLessonFunction _createNewLessonFunction;
        private readonly IGetLessonManagementDetailsFunction _getLessonManagementDetailsFunction;
        private readonly IGetLessonDetailsFunction _getLessonDetailsFunction;
        private readonly IGetChaptersManagementFunction _getChaptersManagementFunction;
        private readonly IUpdateLessonFunction _updateLessonFunction;
        private readonly IDeleteLessonFunction _deleteLessonFunction;
        private readonly IHiddenLessonFunction _hiddenLessonFunction;
        private readonly IGetLessonManagementFunction _getLessonManagementFunction;
        private readonly IRunCodeLessonFunction _runCodeLessonFunction;
        private readonly ISubmitCodeLessonFunction _submitCodeLessonFunction;
        private readonly IGetThemesFunction _getThemesFunction;
        private readonly IGetCodeLanguagesFunction _getCodeLanguagesFunction;
        private readonly IGetLessonHistoriesFunction _getLessonHistoriesFunction;
        private readonly ILessonCommentFunction _lessonCommentFunction;
        private readonly ILessonReplyCommentFunction _lessonReplyCommentFunction;
        private readonly IGetLessonCommentsFunction _getLessonCommentsFunction;
        private readonly ILessonCommentActionFunction _lessonCommentActionFunction;
        private readonly ILessonReplyCommentActionFunction _lessonReplyCommentActionFunction;
        private readonly IDeleteCourseCommentFunction _deleteCourseCommentFunction;
        private readonly IDeleteCourseReplyCommentFunction _deleteCourseReplyCommentFunction;
        private readonly IDeleteLessonCommentFunction _deleteLessonCommentFunction;
        private readonly IDeleteLessonReplyCommentFunction _deleteLessonReplyCommentFunction;
        private readonly IGetLessonLeaderboardFunction _getLessonLeaderboardFunction;
        private readonly IDeleteLessonTestCaseFunction _deleteLessonTestCaseFunction;

        public CoursesController(IGetCoursesFunction getCoursesFunction, 
            IGetCourseDetailsFunction getCourseDetailsFunction, 
            ICourseRegisterFunction courseRegisterFunction, 
            ICourseCommentFunction courseCommentFunction,
            ICourseReplyCommentFunction courseReplyCommentFunction,
            IGetCourseCommentsFunction getCourseCommentsFunction,
            ICourseCommentActionFunction courseCommentActionFunction,
            ICourseReplyCommentActionFunction courseReplyCommentActionFunction,
            ICreateNewCourseFunction createNewCourseFunction,
            IGetCourseLevelsFunction getCourseLevelsFunction,
            ICreateNewChapterFunction createNewChapterFunction,
            IGetCoursesManagementFunction getCoursesManagementFunction,
            IDeleteCourseFunction deleteCourseFunction,
            IGetCourseDetailsManagementFunction getCourseDetailsManagementFunction,
            IUpdateCourseFunction updateCourseFunction,
            IHiddenCourseFunction hiddenCourseFunction,
            IGetChapterDetailsFunction getChapterDetailsFunction,
            IUpdateChapterFunction updateChapterFunction,
            IDeleteChapterFunction deleteChapterFunction,
            IHiddenChapterFunction hiddenChapterFunction,
            ICreateNewLessonFunction createNewLessonFunction,
            IGetLessonManagementDetailsFunction getLessonManagementDetailsFunction,
            IGetLessonDetailsFunction getLessonDetailsFunction,
            IGetChaptersManagementFunction getChaptersManagementFunction,
            IUpdateLessonFunction updateLessonFunction,
            IDeleteLessonFunction deleteLessonFunction,
            IHiddenLessonFunction hiddenLessonFunction,
            IGetLessonManagementFunction getLessonManagementFunction,
            IRunCodeLessonFunction runCodeLessonFunction,
            ISubmitCodeLessonFunction submitCodeLessonFunction,
            IGetThemesFunction getThemesFunction,
            IGetCodeLanguagesFunction getCodeLanguagesFunction,
            IGetLessonHistoriesFunction getLessonHistoriesFunction,
            ILessonCommentFunction lessonCommentFunction,
            ILessonReplyCommentFunction lessonReplyCommentFunction,
            IGetLessonCommentsFunction getLessonCommentsFunction,
            ILessonCommentActionFunction lessonCommentActionFunction,
            ILessonReplyCommentActionFunction lessonReplyCommentActionFunction,
            IDeleteCourseCommentFunction deleteCourseCommentFunction,
            IDeleteCourseReplyCommentFunction deleteCourseReplyCommentFunction,
            IDeleteLessonCommentFunction deleteLessonCommentFunction,
            IDeleteLessonReplyCommentFunction deleteLessonReplyCommentFunction,
            IGetLessonLeaderboardFunction getLessonLeaderboardFunction,
            IDeleteLessonTestCaseFunction deleteLessonTestCaseFunction)
        {
            _getCoursesFunction = getCoursesFunction;
            _getCourseDetailsFunction = getCourseDetailsFunction;
            _courseRegisterFunction = courseRegisterFunction;
            _courseCommentFunction = courseCommentFunction;
            _courseReplyCommentFunction = courseReplyCommentFunction;
            _getCourseCommentsFunction = getCourseCommentsFunction;
            _courseCommentActionFunction = courseCommentActionFunction;
            _courseReplyCommentActionFunction = courseReplyCommentActionFunction;
            _createNewCourseFunction = createNewCourseFunction;
            _getCourseLevelsFunction = getCourseLevelsFunction;
            _createNewChapterFunction = createNewChapterFunction;
            _getCoursesManagementFunction = getCoursesManagementFunction;
            _deleteCourseFunction = deleteCourseFunction;
            _getCourseDetailsManagementFunction = getCourseDetailsManagementFunction;
            _updateCourseFunction = updateCourseFunction;
            _hiddenCourseFunction = hiddenCourseFunction;
            _getChapterDetailsFunction = getChapterDetailsFunction;
            _updateChapterFunction = updateChapterFunction;
            _deleteChapterFunction = deleteChapterFunction;
            _hiddenChapterFunction = hiddenChapterFunction;
            _createNewLessonFunction = createNewLessonFunction;
            _getLessonManagementDetailsFunction = getLessonManagementDetailsFunction;
            _getLessonDetailsFunction = getLessonDetailsFunction;
            _getChaptersManagementFunction = getChaptersManagementFunction;
            _updateLessonFunction = updateLessonFunction;
            _deleteLessonFunction = deleteLessonFunction;
            _hiddenLessonFunction = hiddenLessonFunction;
            _getLessonManagementFunction = getLessonManagementFunction;
            _runCodeLessonFunction = runCodeLessonFunction;
            _submitCodeLessonFunction = submitCodeLessonFunction;
            _getThemesFunction = getThemesFunction;
            _getCodeLanguagesFunction = getCodeLanguagesFunction;
            _getLessonHistoriesFunction = getLessonHistoriesFunction;
            _lessonCommentFunction = lessonCommentFunction;
            _lessonReplyCommentFunction = lessonReplyCommentFunction;
            _getLessonCommentsFunction = getLessonCommentsFunction;
            _lessonCommentActionFunction = lessonCommentActionFunction;
            _lessonReplyCommentActionFunction = lessonReplyCommentActionFunction;
            _deleteCourseCommentFunction = deleteCourseCommentFunction;
            _deleteCourseReplyCommentFunction = deleteCourseReplyCommentFunction;
            _deleteLessonCommentFunction = deleteLessonCommentFunction;
            _deleteLessonReplyCommentFunction = deleteLessonReplyCommentFunction;
            _getLessonLeaderboardFunction = getLessonLeaderboardFunction;
            _deleteLessonTestCaseFunction = deleteLessonTestCaseFunction;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCourses(int userId, string? keyword)
        {
            var response = await _getCoursesFunction.GetCourses(new IGetCoursesFunction.Request(userId, keyword));
            return Ok(response);
        }

        [HttpGet("Details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCourseDetails(int courseId, int userId)
        {
            var response = await _getCourseDetailsFunction.GetCourseDetails(new IGetCourseDetailsFunction.Request(courseId, userId));
            return Ok(response);
        }

        [HttpPut("Register")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CourseRegister(CourseRegisterDto courseRegister)
        {
            var response = await _courseRegisterFunction.CourseRegister(new ICourseRegisterFunction.Request(courseRegister));
            return Ok(response);
        }

        [HttpPut("Comment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CourseComment(CourseCommentDto courseComment)
        {
            var response = await _courseCommentFunction.CourseComment(new ICourseCommentFunction.Request(courseComment));
            return Ok(response);
        }

        [HttpPut("ReplyComment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CourseReplyComment(CourseReplyCommentDto courseReplyComment)
        {
            var response = await _courseReplyCommentFunction.CourseReplyComment(new ICourseReplyCommentFunction.Request(courseReplyComment));
            return Ok(response);
        }

        [HttpGet("Comments")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCourseComments(int courseId, int userId)
        {
            var response = await _getCourseCommentsFunction.GetCourseComments(new IGetCourseCommentsFunction.Request(courseId, userId));
            return Ok(response);
        }

        [HttpPost("CommentAction")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CourseCommentAction(CourseCommentActionDto courseCommentAction)
        {
            var response = await _courseCommentActionFunction.CourseCommentAction(new ICourseCommentActionFunction.Request(courseCommentAction));
            return Ok(response);
        }

        [HttpPost("ReplyCommentAction")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CourseReplyCommentAction(CourseCommentActionDto courseReplyCommentAction)
        {
            var response = await _courseReplyCommentActionFunction.CourseReplyCommentAction(new ICourseReplyCommentActionFunction.Request(courseReplyCommentAction));
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewCourse(CreateNewCourseDto newCourseDto)
        {
            var response = await _createNewCourseFunction.CreateNewCourse(new ICreateNewCourseFunction.Request(newCourseDto));
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto courseDto)
        {
            var response = await _updateCourseFunction.UpdateCourse(new IUpdateCourseFunction.Request(courseDto));
            return Ok(response);
        }

        [HttpGet("Management")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCoursesManagement(int userId, string? keyword)
        {
            var response = await _getCoursesManagementFunction.GetCoursesManagement(new IGetCoursesManagementFunction.Request(userId, keyword));
            return Ok(response);
        }

        [HttpGet("Management/Details/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCourseDetailsManagement(int id)
        {
            var response = await _getCourseDetailsManagementFunction.GetCourseDetailsManagement(new IGetCourseDetailsManagementFunction.Request(id));
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var response = await _deleteCourseFunction.DeleteCourse(new IDeleteCourseFunction.Request(id));
            return Ok(response);
        }

        [HttpPost("Management/Hidden/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> HiddenCourse(int id)
        {
            var response = await _hiddenCourseFunction.HiddenCourse(new IHiddenCourseFunction.Request(id));
            return Ok(response);
        }

        [HttpGet("CourseLevels")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCourseLevels()
        {
            var response = await _getCourseLevelsFunction.GetCourseLevels();
            return Ok(response);
        }

        [HttpPut("Chapters")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewChapter(CreateNewChapterDto newChapterDto)
        {
            var response = await _createNewChapterFunction.CreateNewChapter(new ICreateNewChapterFunction.Request(newChapterDto));
            return Ok(response);
        }

        [HttpPost("Chapters")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateChapter(UpdateChapterDto chapterDto)
        {
            var response = await _updateChapterFunction.UpdateChapter(new IUpdateChapterFunction.Request(chapterDto));
            return Ok(response);
        }

        [HttpDelete("Chapters/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            var response = await _deleteChapterFunction.DeleteChapter(new IDeleteChapterFunction.Request(id));
            return Ok(response);
        }

        [HttpPost("Chapters/Hidden/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> HiddenChapter(int id)
        {
            var response = await _hiddenChapterFunction.HiddenChapter(new IHiddenChapterFunction.Request(id));
            return Ok(response);
        }

        [HttpGet("Chapters/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetChapterDetails(int id)
        {
            var response = await _getChapterDetailsFunction.GetChapterDetails(new IGetChapterDetailsFunction.Request(id));
            return Ok(response);
        }

        [HttpGet("Chapters/Management")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetChaptersManagement(int courseId)
        {
            var response = await _getChaptersManagementFunction.GetChaptersManagement(new IGetChaptersManagementFunction.Request(courseId));
            return Ok(response);
        }

        [HttpPut("Lessons")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewLesson(CreateNewLessonDto newLessonDto)
        {
            var response = await _createNewLessonFunction.CreateNewLesson(new ICreateNewLessonFunction.Request(newLessonDto));
            return Ok(response);
        }

        [HttpPost("Lessons")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            var response = await _updateLessonFunction.UpdateLesson(new IUpdateLessonFunction.Request(updateLessonDto));
            return Ok(response);
        }

        [HttpDelete("Lessons/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var response = await _deleteLessonFunction.DeleteLesson(new IDeleteLessonFunction.Request(id));
            return Ok(response);
        }

        [HttpPost("Lessons/Hidden/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> HiddenLesson(int id)
        {
            var response = await _hiddenLessonFunction.HiddenLesson(new IHiddenLessonFunction.Request(id));
            return Ok(response);
        }

        [HttpGet("Lessons/Management")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLessonManagement(int chapterId)
        {
            var response = await _getLessonManagementFunction.GetLessonManagement(new IGetLessonManagementFunction.Request(chapterId));
            return Ok(response);
        }

        [HttpGet("Lessons/Management/Details/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLessonManagementDetails(int id)
        {
            var response = await _getLessonManagementDetailsFunction.GetLessonManagementDetails(new IGetLessonManagementDetailsFunction.Request(id));
            return Ok(response);
        }

        [HttpGet("Lessons/Details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLessonDetails(int userId, int lessonId)
        {
            var response = await _getLessonDetailsFunction.GetLessonDetails(new IGetLessonDetailsFunction.Request(userId, lessonId));
            return Ok(response);
        }

        [HttpPost("Lessons/Run")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RunCodeLesson(RunCodeLessonDto runCodeLesson)
        {
            var response = await _runCodeLessonFunction.RunCodeLesson(new IRunCodeLessonFunction.Request(runCodeLesson));
            return Ok(response);
        }

        [HttpPut("Lessons/Submit")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SubmitCodeLesson(SubmitCodeLessonDto submitCodeLesson)
        {
            var response = await _submitCodeLessonFunction.SubmitCodeLesson(new ISubmitCodeLessonFunction.Request(submitCodeLesson));
            return Ok(response);
        }

        [HttpGet("Themes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetThemes()
        {
            var response = await _getThemesFunction.GetThemes();
            return Ok(response);
        }

        [HttpGet("CodeLanguages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCodeLanguages()
        {
            var response = await _getCodeLanguagesFunction.GetCodeLanguages();
            return Ok(response);
        }

        [HttpGet("Lessons/Histories")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLessonHistories(int lessonId, int userId)
        {
            var response = await _getLessonHistoriesFunction.GetLessonHistories(new IGetLessonHistoriesFunction.Request(lessonId, userId));
            return Ok(response);
        }

        [HttpPut("Lessons/Comment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LessonComment(LessonCommentDto lessonComment)
        {
            var response = await _lessonCommentFunction.LessonComment(new ILessonCommentFunction.Request(lessonComment));
            return Ok(response);
        }

        [HttpPut("Lessons/ReplyComment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LessonReplyComment(LessonReplyCommentDto lessonReplyComment)
        {
            var response = await _lessonReplyCommentFunction.LessonReplyComment(new ILessonReplyCommentFunction.Request(lessonReplyComment));
            return Ok(response);
        }

        [HttpGet("Lessons/Comments")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLessonCommentsFunction(int lessonId, int userId)
        {
            var response = await _getLessonCommentsFunction.GetLessonComments(new IGetLessonCommentsFunction.Request(lessonId, userId));
            return Ok(response);
        }

        [HttpPost("Lessons/CommentAction")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LessonCommentAction(LessonCommentActionDto lessonCommentAction)
        {
            var response = await _lessonCommentActionFunction.LessonCommentAction(new ILessonCommentActionFunction.Request(lessonCommentAction));
            return Ok(response);
        }

        [HttpPost("Lessons/ReplyCommentAction")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LessonReplyCommentAction(LessonCommentActionDto lessonReplyCommentAction)
        {
            var response = await _lessonReplyCommentActionFunction.LessonReplyCommentAction(new ILessonReplyCommentActionFunction.Request(lessonReplyCommentAction));
            return Ok(response);
        }

        [HttpDelete("Comment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCourseComment(int commentId, int userId)
        {
            var response = await _deleteCourseCommentFunction.DeleteCourseComment(new IDeleteCourseCommentFunction.Request(commentId, userId));
            return Ok(response);
        }

        [HttpDelete("ReplyComment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCourseReplyComment(int replyCommentId, int userId)
        {
            var response = await _deleteCourseReplyCommentFunction.DeleteCourseReplyComment(new IDeleteCourseReplyCommentFunction.Request(replyCommentId, userId));
            return Ok(response);
        }

        [HttpDelete("Lessons/Comment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteLessonComment(int commentId, int userId)
        {
            var response = await _deleteLessonCommentFunction.DeleteLessonComment(new IDeleteLessonCommentFunction.Request(commentId, userId));
            return Ok(response);
        }

        [HttpDelete("Lessons/ReplyComment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteLessonReplyComment(int replyCommentId, int userId)
        {
            var response = await _deleteLessonReplyCommentFunction.DeleteLessonReplyComment(new IDeleteLessonReplyCommentFunction.Request(replyCommentId, userId));
            return Ok(response);
        }

        [HttpGet("Lessons/Leaderboard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLessonLeaderboard(int lessonId, int pageSize, int pageNumber)
        {
            var response = await _getLessonLeaderboardFunction.GetLessonLeaderboard(new IGetLessonLeaderboardFunction.Request(lessonId, pageSize, pageNumber));
            return Ok(response);
        }

        [HttpDelete("Lessons/TestCase/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteLessonTestCase(int id)
        {
            var response = await _deleteLessonTestCaseFunction.DeleteLessonTestCase(new IDeleteLessonTestCaseFunction.Request(id));
            return Ok(response);
        }
    }
}
