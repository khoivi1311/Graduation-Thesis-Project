using learn_programming_services.Apis.Discussions.Dtos;
using learn_programming_services.Businesses.Functions.Discussions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace learn_programming_services.Apis.Discussions
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class DiscussionsController : ControllerBase
    {
        private readonly ICreateNewDiscussionFunction _createNewDiscussionFunction;
        private readonly ICreateNewDiscussionCommentFunction _createNewDiscussionCommentFunction;
        private readonly ICreateNewDiscussionReplyCommentFunction _createNewDiscussionReplyCommentFunction;
        private readonly IDeleteDiscussionFunction _deleteDiscussionFunction;
        private readonly IDeleteDiscussionCommentFunction _deleteDiscussionCommentFunction;
        private readonly IDeleteDiscussionReplyCommentFunction _deleteDiscussionReplyCommentFunction;
        private readonly IDiscussionCommentActionFunction _discussionCommentActionFunction;
        private readonly IDiscussionReplyCommentActionFunction _discussionReplyCommentActionFunction;
        private readonly IGetDiscussionsFunction _getDiscussionsFunction;
        private readonly IGetDiscussionDetailsFunction _getDiscussionDetailsFunction;

        public DiscussionsController(ICreateNewDiscussionFunction createNewDiscussionFunction,
            ICreateNewDiscussionCommentFunction createNewDiscussionCommentFunction,
            ICreateNewDiscussionReplyCommentFunction createNewDiscussionReplyCommentFunction,
            IDeleteDiscussionFunction deleteDiscussionFunction,
            IDeleteDiscussionCommentFunction deleteDiscussionCommentFunction,
            IDeleteDiscussionReplyCommentFunction deleteDiscussionReplyCommentFunction,
            IDiscussionCommentActionFunction discussionCommentActionFunction,
            IDiscussionReplyCommentActionFunction discussionReplyCommentActionFunction,
            IGetDiscussionsFunction getDiscussionsFunction,
            IGetDiscussionDetailsFunction getDiscussionDetailsFunction
            ) 
        {
            _createNewDiscussionFunction = createNewDiscussionFunction;
            _createNewDiscussionCommentFunction = createNewDiscussionCommentFunction;
            _createNewDiscussionReplyCommentFunction = createNewDiscussionReplyCommentFunction;
            _deleteDiscussionFunction = deleteDiscussionFunction;
            _deleteDiscussionCommentFunction = deleteDiscussionCommentFunction;
            _deleteDiscussionReplyCommentFunction = deleteDiscussionReplyCommentFunction;
            _discussionCommentActionFunction = discussionCommentActionFunction;
            _discussionReplyCommentActionFunction = discussionReplyCommentActionFunction;
            _getDiscussionsFunction = getDiscussionsFunction;
            _getDiscussionDetailsFunction = getDiscussionDetailsFunction;
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewDiscussion(CreateNewDiscussionDto discussion)
        {
            var response = await _createNewDiscussionFunction.CreateNewDiscussion(new ICreateNewDiscussionFunction.Request(discussion));
            return Ok(response);
        }

        [HttpPut("Comment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewDiscussionComment(CreateNewDiscussionCommentDto discussionComment)
        {
            var response = await _createNewDiscussionCommentFunction.CreateNewDiscussionComment(new ICreateNewDiscussionCommentFunction.Request(discussionComment));
            return Ok(response);
        }

        [HttpPut("ReplyComment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewDiscussionReplyComment(CreateNewDiscussionReplyCommentDto discussionReplyComment)
        {
            var response = await _createNewDiscussionReplyCommentFunction.CreateNewDiscussionReplyComment(new ICreateNewDiscussionReplyCommentFunction.Request(discussionReplyComment));
            return Ok(response);
        }

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteDiscussion(int userId, int discussionId)
        {
            var response = await _deleteDiscussionFunction.DeleteDiscussion(new IDeleteDiscussionFunction.Request(userId, discussionId));
            return Ok(response);
        }

        [HttpDelete("Comment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteDiscussionComment(int userId, int commentId)
        {
            var response = await _deleteDiscussionCommentFunction.DeleteDiscussionComment(new IDeleteDiscussionCommentFunction.Request(userId, commentId));
            return Ok(response);
        }

        [HttpDelete("ReplyComment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteDiscussionReplyComment(int userId, int replyCommentId)
        {
            var response = await _deleteDiscussionReplyCommentFunction.DeleteDiscussionReplyComment(new IDeleteDiscussionReplyCommentFunction.Request(userId, replyCommentId));
            return Ok(response);
        }

        [HttpPost("CommentAction")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DiscussionCommentAction(DiscussionCommentActionDto discussionCommentAction)
        {
            var response = await _discussionCommentActionFunction.DiscussionCommentAction(new IDiscussionCommentActionFunction.Request(discussionCommentAction));
            return Ok(response);
        }

        [HttpPost("ReplyCommentAction")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DiscussionReplyCommentAction(DiscussionCommentActionDto discussionReplyCommentAction)
        {
            var response = await _discussionReplyCommentActionFunction.DiscussionReplyCommentAction(new IDiscussionReplyCommentActionFunction.Request(discussionReplyCommentAction));
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDiscussions(int pageSize, int pageNumber)
        {
            var response = await _getDiscussionsFunction.GetDiscussions(new IGetDiscussionsFunction.Request(pageSize, pageNumber));
            return Ok(response);
        }

        [HttpGet("Details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDiscussionDetails(int discussionId, int userId)
        {
            var response = await _getDiscussionDetailsFunction.GetDiscussionDetails(new IGetDiscussionDetailsFunction.Request(discussionId, userId));
            return Ok(response);
        }
    }
}
